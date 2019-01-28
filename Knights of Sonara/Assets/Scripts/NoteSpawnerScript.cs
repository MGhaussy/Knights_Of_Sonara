using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawnerScript : MonoBehaviour {

    public GameObject note;
    public float noteTempo = 1.0f; //in seconds
    public GameObject row1;
    public GameObject row2;
    public GameObject row3;
    public GameObject row4;
    public GameObject row5;

    private Transform pos1;
    private Transform pos2;
    private Transform pos3;
    private Transform pos4;
    private Transform pos5;

    private List<Transform> spawnPoints;

    // Use this for initialization
    void Start ()
    {
        spawnPoints = new List<Transform>();
        pos1 = row1.transform;
        spawnPoints.Add(pos1);
        pos2 = row2.transform;
        spawnPoints.Add(pos2);
        pos3 = row3.transform;
        spawnPoints.Add(pos3);
        pos4 = row4.transform;
        spawnPoints.Add(pos4);
        pos5 = row5.transform;
        spawnPoints.Add(pos5);

        InvokeRepeating("spawnNote", 0.1f, noteTempo);
        //spawnNote();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void spawnNote()
    {
        int index = Random.Range(0, spawnPoints.Count);
        Instantiate(note, spawnPoints[index]);
    }

}
