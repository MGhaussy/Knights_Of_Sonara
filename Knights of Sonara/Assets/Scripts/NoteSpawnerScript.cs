using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawnerScript : MonoBehaviour {

    public float noteTempo = 1.0f; //in seconds

    public GameObject note;
    //all spawners for each row
    public GameObject row1;
    public GameObject row2;
    public GameObject row3;
    public GameObject row4;
    public GameObject row5;

    //List holding spawners' positions
    private List<Transform> spawnPoints;

    // Use this for initialization
    void Start ()
    {
        //adding spawners' positions to list
        spawnPoints = new List<Transform>();
        spawnPoints.Add(row1.transform);
        spawnPoints.Add(row2.transform);
        spawnPoints.Add(row3.transform);
        spawnPoints.Add(row4.transform);
        spawnPoints.Add(row5.transform);

        //caling the spawnNote method every "noteTempo" seconds
        InvokeRepeating("spawnNote", 0.1f, noteTempo);
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void spawnNote()
    {
        //Getting one of the spawners, randomly
        int index = Random.Range(0, spawnPoints.Count);
        //generate a new GameObject Note at the random spawners' position
        Instantiate(note, spawnPoints[index]);
    }

}
