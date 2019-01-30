using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

    private Transform target;
    public float circleSpeed = 100f;

    // Use this for initialization
    void Start () {
		target = GameObject.FindGameObjectWithTag("BlackHoleOrbitCollider").transform.parent.GetComponent<Transform>();
        circleSpeed = Random.Range(circleSpeed/2, circleSpeed*2);
    }
	
	// Update is called once per frame
	void Update () {
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, 0.01f);
        transform.RotateAround(Vector3.zero, transform.forward, circleSpeed * Time.deltaTime); 
     
    }
}
