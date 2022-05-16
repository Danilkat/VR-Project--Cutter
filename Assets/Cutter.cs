using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.ProBuilder.MeshOperations;
using Parabox.CSG;

public class Cutter : MonoBehaviour
{
    public GameObject Subtractee, Plane;
    ProBuilderMesh TreeWithCut, UpperHalfTree;
    // Start is called before the first frame update
    void Start()
    {
        TreeWithCut = 
            Perform(
                CSG.BooleanOp.Subtraction,
                this.gameObject,
                Subtractee,
                "TreeWithCut"
                );

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

        Perform(
            CSG.BooleanOp.Subtraction,
            TreeWithCut.gameObject,
            UpperHalfTree.gameObject,
            "LowerHalfTree"
            );
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
