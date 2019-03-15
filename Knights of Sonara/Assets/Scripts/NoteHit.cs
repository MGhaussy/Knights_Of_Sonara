using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHit : MonoBehaviour
{
    public HealthBar healthBar;
    public ManageController inputManager;


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
        if (this.gameObject.name == "Note Hitbox A")
        {
            if (Input.GetKeyDown(inputManager.KeysToUse[0]) == true)
            {
                Destroy(collision.gameObject);
                Debug.Log("Nice Hit!");
            }
            else
            {
                healthBar.subtractHealth(1);
                healthBar.IsSubtractingHealth = true;
            }
        }

        if (this.gameObject.name == "Note Hitbox B")
        {
            if (Input.GetKeyDown(inputManager.KeysToUse[1]) == true)
            {
                Destroy(collision.gameObject);
                Debug.Log("Nice Hit!");
            }
            else
            {
                healthBar.subtractHealth(1);
                healthBar.IsSubtractingHealth = true;
            }

        }

        if (this.gameObject.name == "Note Hitbox C")
        {
            if (Input.GetKeyDown(inputManager.KeysToUse[2]) == true)
            {
                Destroy(collision.gameObject);
                Debug.Log("Nice Hit!");
            }
            else
            {
                healthBar.subtractHealth(1);
                healthBar.IsSubtractingHealth = true;
            }

        }

        if (this.gameObject.name == "Note Hitbox D")
        {
            if (Input.GetKeyDown(inputManager.KeysToUse[3]) == true)
            {
                Destroy(collision.gameObject);
                Debug.Log("Nice Hit!");
            }
            else
            {
                healthBar.subtractHealth(1);
                healthBar.IsSubtractingHealth = true;
            }

        }

        if (this.gameObject.name == "Note Hitbox E")
        {
            if (Input.GetKeyDown(inputManager.KeysToUse[4]) == true)
            {
                Destroy(collision.gameObject);
                Debug.Log("Nice Hit!");
            }
            else
            {
                healthBar.subtractHealth(1);
                healthBar.IsSubtractingHealth = true;
            }

        }
        //Debug.Log(this.gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (this.gameObject.name == "Note Hitbox A" || this.gameObject.name == "Note Hitbox B" || this.gameObject.name == "Note Hitbox C"
            || this.gameObject.name == "Note Hitbox D" || this.gameObject.name == "Note Hitbox E")
        {
            healthBar.IsSubtractingHealth = false;
        }
    }
}
