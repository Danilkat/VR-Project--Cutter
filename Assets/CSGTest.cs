using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Parabox.CSG;
using UnityEngine.ProBuilder;
using UnityEngine.ProBuilder.MeshOperations;

public class CSGTest : MonoBehaviour
{
    public GameObject plane;
    
    // Start is called before the first frame update
    void Start()
    {
        //Model result = CSG.TestBuild(plane, this.gameObject);
        //var materials = result.materials.ToArray();
        //ProBuilderMesh pb = ProBuilderMesh.Create();
        //pb.gameObject.name = name;
        //pb.GetComponent<MeshFilter>().sharedMesh = (Mesh)result;
        //pb.GetComponent<MeshRenderer>().sharedMaterials = materials;
        //MeshImporter importer = new MeshImporter(pb.gameObject);
        //importer.Import(new MeshImportSettings() { quads = true, smoothing = true, smoothingAngle = 1f });
        //pb.ToMesh(); pb.Refresh();
        //pb.CenterPivot(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
