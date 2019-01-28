using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (this.gameObject.name == "Note A Hitbox")
        {
            if (Input.GetKeyDown("1") == true)
            {
                Destroy(collision.gameObject);
                Debug.Log("Nice Hit!");
            }
            else
            {
                Debug.Log("You missed!");
                //Harm Player or something
            }
        }

        if (this.gameObject.name == "Note B Hitbox")
        {
            if (Input.GetKeyDown("2") == true)
            {
                Destroy(collision.gameObject);
                Debug.Log("Nice Hit!");
            }

        }

        if (this.gameObject.name == "Note C Hitbox")
        {
            if (Input.GetKeyDown("3") == true)
            {
                Destroy(collision.gameObject);
                Debug.Log("Nice Hit!");
            }

        }

        if (this.gameObject.name == "Note D Hitbox")
        {
            if (Input.GetKeyDown("4") == true)
            {
                Destroy(collision.gameObject);
                Debug.Log("Nice Hit!");
            }

        }

        if (this.gameObject.name == "Note E Hitbox")
        {
            if (Input.GetKeyDown("5") == true)
            {
                Destroy(collision.gameObject);
                Debug.Log("Nice Hit!");
            }

        }
        //Debug.Log(this.gameObject.name);
    }
}
