using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienLogic : MonoBehaviour {

    private float speed = 10.0f;
    private Rigidbody blackHoleRB;
    public bool isAlienShooted = false;
    public AudioClip scream;
    public AudioClip happyScream;
    public AudioClip bounceSound;
    // Use this for initialization
    void Start () {
        if (!isAlienShooted)
        {
            blackHoleRB = GameObject.FindGameObjectWithTag("BlackHoleOrbitCollider").transform.parent.GetComponent<Rigidbody>();
            GetComponent<Rigidbody>().velocity = (GameObject.Find("BlackHole").transform.position - transform.position).normalized * speed;
            GetComponent<AudioSource>().PlayOneShot(scream);
        }
    }
	
	// Update is called once per frame
	void Update () {



    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BlackHoleOrbitCollider")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            SpawnManager.Instance.alienCounter++;
            GetComponent<Orbit>().enabled = true;
        }

        if (other.tag == "DeathCollider")
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().score > 0)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().score -= 5;
            }
            SpawnManager.Instance.alienCounter--;
            SpawnManager.Instance.changeSadFace();
            
            Destroy(this.gameObject);
        }

        if (isAlienShooted)
        {
            if (other.tag == "GreenAlienHome" && this.GetComponent<Renderer>().material.color.g == 1)
            {
               SoundManager.Instance.PlaySound(happyScream);
                GameObject.Find("GameManager").GetComponent<GameManager>().score += 30;                
                Destroy(this.gameObject);
            }
            else if (other.tag == "RedAlienHome" && this.GetComponent<Renderer>().material.color.r == 1)
            {
                SoundManager.Instance.PlaySound(happyScream);
                GameObject.Find("GameManager").GetComponent<GameManager>().score += 30;
                Destroy(this.gameObject);
            }
            else if (other.tag == "BlueAlienHome" && this.GetComponent<Renderer>().material.color.b == 1)
            {
                SoundManager.Instance.PlaySound(happyScream);
                GameObject.Find("GameManager").GetComponent<GameManager>().score += 30;
                Destroy(this.gameObject);
            }
            else if (other.tag != "DeathCollider" && other.tag != "BlackHoleOrbitCollider" && other.tag != "Alien" && other.tag != "Untagged")
            {
                GetComponent<AudioSource>().PlayOneShot(bounceSound);
                GetComponent<Rigidbody>().velocity = (GameObject.Find("BlackHole").transform.position - transform.position).normalized * (speed * 3);
                
            }
        }

    }
}
