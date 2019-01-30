using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTranslation : MonoBehaviour {

    //scrolling speed
    public float noteVelocity = 4.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //scrolling function
        transform.Translate((Vector2.left * noteVelocity) * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        //Destroy note when out of camera range
        Destroy(gameObject);
    }
}
