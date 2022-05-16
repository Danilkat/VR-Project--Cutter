using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.ProBuilder.MeshOperations;
using Parabox.CSG;

public class Cutter : MonoBehaviour
{
    public GameObject Subtractee, Plane, Cube1, Cube2;
    ProBuilderMesh TreeWithCut, UpperHalfTree, LowerHalfTree, SubtractedPieceWood;
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
                Plane,
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
