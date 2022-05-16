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
    float timer = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Cutter = GameObject.Find("Cylinder").GetComponent<Cutter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stopFlag)
        {
            if (timer < 0.5f)
            {
                timer += Time.deltaTime;
            } else
            {
                Cutter.StartCut(Vector3.forward * gap * iteration);
                Cutter.StartCutCube(Vector3.forward * gap * iteration);
                Cutter.StartCutCubes(Vector3.forward * gap * iteration++);
                timer = 0f;
                PrismNPlane.transform.position += Vector3.up * 0.01f;
            }
            Debug.Log("StopFlag is false!");
        }
        Debug.Log(timer);
    }
}
