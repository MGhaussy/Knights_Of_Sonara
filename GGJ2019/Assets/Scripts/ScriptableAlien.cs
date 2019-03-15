using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AlienData", menuName = "Alien/Data", order = 1)]
public class ScriptableAlien : ScriptableObject {
    public string objectName = "New MyScriptableObject";
    public Mesh model;
    public Color thisColor = Color.white;
    public Vector3[] spawnPoints;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
