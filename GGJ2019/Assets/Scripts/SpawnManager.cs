using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public int alienCounter = 0;
    public int maxAliensAllowed = 9;
    public GameObject[] listOfSpawner;
    public GameObject[] aliensToSpawn;

    public GameObject SadEmojiQuad;
    public Material BlankMaterial;
    public Material MAT_SadEmoji;
    public Material MAT_ScaredEmoji;
    private bool changedFace = false;

    public float repeatRateMin = 2.0f;
    public float repeatRateMax = 7.0f;

    private static SpawnManager _instance;

    public static SpawnManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Use this for initialization
    void Start () {

        InvokeRepeating("spawnAliens", 3.0f, Random.Range(repeatRateMin, repeatRateMax));
        SadEmojiQuad.GetComponent<Renderer>().material = BlankMaterial;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeSadFace()
    {
        float randomChanceOfSpawnFace = Random.Range(0.0f, 1.0f);
        float randomFace = Random.Range(0.0f, 1.0f);

        if (randomChanceOfSpawnFace <= 0.2f && !changedFace)
        {
            
            pickTheFace(randomFace);
            changedFace = true;
            Invoke("blankTheFace", 4);

        }
    }

    void pickTheFace(float whichFace)
    {
        if (whichFace > 0.5f)
        {
            SadEmojiQuad.GetComponent<Renderer>().material = MAT_SadEmoji;
        }
        else
        {
            SadEmojiQuad.GetComponent<Renderer>().material = MAT_ScaredEmoji;
        }
    }

    void blankTheFace()
    {
        if (changedFace)
        {
            SadEmojiQuad.GetComponent<Renderer>().material = BlankMaterial;
            changedFace = false;
        }
    }

    void spawnAliens()
    {
        if (alienCounter < maxAliensAllowed)
        {
            for (int i = 0; i < aliensToSpawn.Length; i++)
            {
                Instantiate(aliensToSpawn[i], new Vector3(listOfSpawner[i].transform.position.x, listOfSpawner[i].transform.position.y, 0), new Quaternion(0, 0, 0, 0));
            }
        }
    }
}
