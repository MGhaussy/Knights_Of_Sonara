using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoSpawner : MonoBehaviour
{
    public float lineTempo = 1.0f; //in seconds

    public GameObject TempoLine;
    //Center spawner
    public GameObject row3;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnLine", 0.1f, lineTempo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnLine()
    {
        Instantiate(TempoLine, row3.transform);
    }
}
