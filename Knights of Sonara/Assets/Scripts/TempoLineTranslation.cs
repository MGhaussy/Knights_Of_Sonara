using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoLineTranslation : MonoBehaviour
{
    //scrolling speed
    public float tempoLineVelocity = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //scrolling function
        transform.Translate((Vector2.left * tempoLineVelocity) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when entering collision box, destroy line
        if (collision.gameObject.name == "Note Hitbox C")
        {
            Destroy(gameObject);
        }
    }

}
