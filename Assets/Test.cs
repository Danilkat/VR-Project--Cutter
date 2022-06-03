using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject PrismNPlane;
    Cutter Cutter;
    float gap = 1.5f;
    int iteration = 1;
    bool stopFlag = true;
    public float timer = 0.5f;
    float _timer = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        _timer = timer;
        Cutter = GameObject.Find("Cylinder").GetComponent<Cutter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stopFlag)
        {
            if (_timer < timer)
            {
                _timer += Time.deltaTime;
            } else
            {
                //Cutter.StartCut(Vector3.forward * gap * iteration);
                //Cutter.StartCutCube(Vector3.forward * gap * iteration);
                //Cutter.StartCutPlanes(Vector3.forward * gap * iteration++);
                //try
                //{
                if (iteration == 165)
                    Cutter.StartCutSlice(Vector3.forward * gap * 5, ++iteration);
                iteration++;
                //} catch (System.Exception ex)
                //{
                    //Debug.LogError("Bruh coplanars at " + iteration + "!!");
                //}
                //Cutter.StartCutCubes(Vector3.forward * gap * iteration++);

                _timer = 0f;
                PrismNPlane.transform.position += Vector3.up * 0.01f;
            }
        }
    }
}
