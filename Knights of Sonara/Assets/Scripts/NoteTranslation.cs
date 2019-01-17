using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTranslation : MonoBehaviour {

    public float noteVelocity = 4.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate((new Vector3(-1, 0, 0) * noteVelocity) * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
