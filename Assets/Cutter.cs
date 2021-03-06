using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.ProBuilder.MeshOperations;
using Parabox.CSG;
using System;

public class Cutter : MonoBehaviour
{
    public GameObject Subtractee, Plane1, Plane2, Cube1, Cube2;
    ProBuilderMesh TreeWithCut, UpperHalfTree, LowerHalfTree, SubtractedPieceWood, Slice1, Slice2, UpperNotSliced, LowerNotSliced;
    // Start is called before the first frame update
    void Start()
    {
        //StartCut();
    }

    public void StartCut(Vector3 posShift) {
        TreeWithCut =
            Perform(
                CSG.BooleanOp.Subtraction,
                this.gameObject,
                Subtractee,
                "TreeWithCut"
            );

        SubtractedPieceWood =
            Perform(
                CSG.BooleanOp.Intersection,
                this.gameObject,
                Subtractee,
                "SubtractedPieceWood"
            );

        UpperHalfTree =
            Perform(
                CSG.BooleanOp.Subtraction,
                TreeWithCut.gameObject,
                Plane1,
                "UpperHalfTree"
            );

        LowerHalfTree = 
            Perform(
                CSG.BooleanOp.Subtraction,
                TreeWithCut.gameObject,
                UpperHalfTree.gameObject,
                "LowerHalfTree"
            );

        Destroy(TreeWithCut.gameObject);

        SubtractedPieceWood.gameObject.transform.position += posShift + Vector3.right * 2;
        LowerHalfTree.gameObject.transform.position += posShift;
        UpperHalfTree.gameObject.transform.position += posShift + Vector3.up * 2;
    }

    internal void StartCutSlice(Vector3 posShift, int number)
    {
        try
        {
            TreeWithCut =
                Perform(
                    CSG.BooleanOp.Subtraction,
                    this.gameObject,
                    Subtractee,
                    "TreeWithCut" + number
                );

            SubtractedPieceWood =
                Perform(
                    CSG.BooleanOp.Intersection,
                    this.gameObject,
                    Subtractee,
                    "SubtractedPieceWood" + number
                );

            Slice1 =
                Perform(
                    CSG.BooleanOp.MakeSlice,
                    Plane1,
                    TreeWithCut.gameObject,
                    "SliceForUpper" + number
                );

            Slice2 =
                Perform(
                    CSG.BooleanOp.MakeSlice,
                    Plane2,
                    TreeWithCut.gameObject,
                    "SliceForLower" + number
                );

            UpperHalfTree =
                Perform(
                    CSG.BooleanOp.MakeHalfOfTheTree,
                    TreeWithCut.gameObject,
                    Slice1.gameObject,
                    "UpperHalfTree" + number
                );
            LowerHalfTree =
                Perform(
                    CSG.BooleanOp.MakeHalfOfTheTree,
                    TreeWithCut.gameObject,
                    Slice2.gameObject,
                    "LowerHalfTree" + number
                );

        } catch
        {
            if (SubtractedPieceWood) { Destroy(SubtractedPieceWood); }
            if (Slice1) { Destroy(Slice1); }
            if (Slice2) { Destroy(Slice2); }
            if (UpperHalfTree) { Destroy(UpperHalfTree); }
            if (LowerHalfTree) { Destroy(LowerHalfTree); }
            Destroy(TreeWithCut.gameObject);
            return;
        }
        Destroy(TreeWithCut.gameObject);
        posShift += Vector3.right * 17;
        SubtractedPieceWood.gameObject.transform.position += posShift + Vector3.right * 2;
        Slice1.gameObject.transform.position += posShift;
        Slice2.gameObject.transform.position += posShift;
        LowerHalfTree.gameObject.transform.position += posShift;
        UpperHalfTree.gameObject.transform.position += posShift + Vector3.up * 2;

    }

    internal void StartCutSuper(Vector3 posShift, int number)
    {
        TreeWithCut =
            Perform(
                CSG.BooleanOp.Subtraction,
                this.gameObject,
                Subtractee,
                "TreeWithCut" + number
            );

        SubtractedPieceWood =
            Perform(
                CSG.BooleanOp.Intersection,
                this.gameObject,
                Subtractee,
                "SubtractedPieceWood" + number
            );

        UpperNotSliced =
            Perform(
                CSG.BooleanOp.Subtraction,
                this.gameObject,
                Plane1,
                "UpperNotSliced" + number
            );

        LowerNotSliced =
            Perform(
                CSG.BooleanOp.Subtraction,
                this.gameObject,
                Plane2,
                "LowerNotSliced" + number
            );

        UpperHalfTree =
            Perform(
                CSG.BooleanOp.Subtraction,
                UpperNotSliced.gameObject,
                Subtractee.gameObject,
                "UpperHalfTree" + number
            );
        LowerHalfTree =
            Perform(
                CSG.BooleanOp.Subtraction,
                LowerNotSliced.gameObject,
                Subtractee.gameObject,
                "LowerHalfTree" + number
            );
        Destroy(TreeWithCut.gameObject);
        Destroy(UpperNotSliced.gameObject);
        Destroy(LowerNotSliced.gameObject);
        posShift += Vector3.right * 17;
        SubtractedPieceWood.gameObject.transform.position += posShift + Vector3.right * 2;
        //Slice1.gameObject.transform.position += posShift;
        //Slice2.gameObject.transform.position += posShift;
        LowerHalfTree.gameObject.transform.position += posShift;
        UpperHalfTree.gameObject.transform.position += posShift + Vector3.up * 2;

    }
    public void StartCutCube(Vector3 posShift)
    {
        TreeWithCut =
            Perform(
                CSG.BooleanOp.Subtraction,
                this.gameObject,
                Subtractee,
                "TreeWithCut"
            );

        SubtractedPieceWood =
            Perform(
                CSG.BooleanOp.Intersection,
                this.gameObject,
                Subtractee,
                "SubtractedPieceWood"
            );

        UpperHalfTree =
            Perform(
                CSG.BooleanOp.Intersection,
                TreeWithCut.gameObject,
                Cube1,
                "UpperHalfTree"
            );

        LowerHalfTree =
            Perform(
                CSG.BooleanOp.Subtraction,
                TreeWithCut.gameObject,
                UpperHalfTree.gameObject,
                "LowerHalfTree"
            );

        Destroy(TreeWithCut.gameObject);
        posShift += Vector3.right * 4;
        SubtractedPieceWood.gameObject.transform.position += posShift + Vector3.right * 2;
        LowerHalfTree.gameObject.transform.position += posShift;
        UpperHalfTree.gameObject.transform.position += posShift + Vector3.up * 2;
    }

    public void StartCutCubes(Vector3 posShift)
    {
        TreeWithCut =
            Perform(
                CSG.BooleanOp.Subtraction,
                this.gameObject,
                Subtractee,
                "TreeWithCut"
            );

        SubtractedPieceWood =
            Perform(
                CSG.BooleanOp.Intersection,
                this.gameObject,
                Subtractee,
                "SubtractedPieceWood"
            );

        UpperHalfTree =
            Perform(
                CSG.BooleanOp.Intersection,
                TreeWithCut.gameObject,
                Cube1,
                "UpperHalfTree"
            );

        LowerHalfTree =
            Perform(
                CSG.BooleanOp.Intersection,
                TreeWithCut.gameObject,
                Cube2,
                "LowerHalfTree"
            );

        Destroy(TreeWithCut.gameObject);

        posShift += Vector3.right * 8;
        SubtractedPieceWood.gameObject.transform.position += posShift + Vector3.right * 2;
        LowerHalfTree.gameObject.transform.position += posShift;
        UpperHalfTree.gameObject.transform.position += posShift + Vector3.up * 2;
    }



    public void StartCutPlanes(Vector3 posShift)
    {
        TreeWithCut =
            Perform(
                CSG.BooleanOp.Subtraction,
                this.gameObject,
                Subtractee,
                "TreeWithCut"
            );

        SubtractedPieceWood =
            Perform(
                CSG.BooleanOp.Intersection,
                this.gameObject,
                Subtractee,
                "SubtractedPieceWood"
            );

        UpperHalfTree =
            Perform(
                CSG.BooleanOp.Subtraction,
                TreeWithCut.gameObject,
                Plane1,
                "UpperHalfTree"
            );

        LowerHalfTree =
            Perform(
                CSG.BooleanOp.Subtraction,
                TreeWithCut.gameObject,
                Plane2,
                "LowerHalfTree"
            );

        Destroy(TreeWithCut.gameObject);

        posShift += Vector3.right * 12;
        SubtractedPieceWood.gameObject.transform.position += posShift + Vector3.right * 2;
        LowerHalfTree.gameObject.transform.position += posShift;
        UpperHalfTree.gameObject.transform.position += posShift + Vector3.up * 2;
    }
    ProBuilderMesh Perform(CSG.BooleanOp booleanOp, GameObject lhs, GameObject rhs, string name)
    {

        Model result = CSG.Perform(booleanOp, lhs, rhs);
        var materials = result.materials.ToArray();
        ProBuilderMesh pb = ProBuilderMesh.Create();
        pb.gameObject.name = name;
        pb.GetComponent<MeshFilter>().sharedMesh = (Mesh)result;
        pb.GetComponent<MeshRenderer>().sharedMaterials = materials;
        MeshImporter importer = new MeshImporter(pb.gameObject);
        importer.Import(new MeshImportSettings() { quads = true, smoothing = true, smoothingAngle = 1f });
        pb.ToMesh(); pb.Refresh();
        pb.CenterPivot(null);
        return pb;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
