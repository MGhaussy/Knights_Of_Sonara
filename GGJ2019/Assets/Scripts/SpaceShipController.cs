using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour {

    [SerializeField]
    private float speed;
    private Rigidbody m_rigidBody;
    public Renderer[] windows;
    public LayerMask whatIsDeath;
    private int slot;
    public GameObject redAlien;
    public GameObject greenAlien;
    public GameObject blueAlien;
    public Transform shootingPoint;
    public GameObject planetEmoji;
    public Material MAT_planet1Emoji;
    public Material MAT_planet2Emoji;
    public Material MAT_planet3Emoji;

    public Material BlankMaterial;
    //private GameObject _redAlien;
    //private GameObject _greenAlien;
    //private GameObject _blueAlien;

    // Use this for initialization
    void Start () {
        m_rigidBody = GetComponent<Rigidbody>();
        windows = transform.GetChild(0).GetComponentsInChildren<Renderer>();
        planetEmoji.GetComponent<Renderer>().material = BlankMaterial;
        slot = -1;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = Vector3.zero;

        // movement.x = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Vertical") > 0)
        {
            movement.y = Input.GetAxis("Vertical");
            m_rigidBody.AddForce(transform.TransformDirection(movement * speed/2));
            m_rigidBody.drag = 0f;
            m_rigidBody.angularDrag = 0f;
            transform.GetChild(3).GetComponent<AudioSource>().Play(0);
        }

        movement *= speed * Time.deltaTime;

        if (Input.GetAxis("Horizontal") != 0) {
            Vector3 rotation = Vector3.zero;
            rotation.z = Input.GetAxis("Horizontal") * (speed * 1.8f) * Time.deltaTime;
            //m_rigidBody.AddTorque(- (rotation.normalized));
            m_rigidBody.angularVelocity -= Vector3.zero;
            m_rigidBody.drag = 1.5f;
            m_rigidBody.angularDrag = 1.5f;
            transform.Rotate(rotation);
        }
        //if ((Mathf.Abs(m_rigidBody.velocity.x) < 10.0f || Mathf.Abs(m_rigidBody.velocity.y) < 10.0f)) {
        //    m_rigidBody.AddForce(transform.TransformDirection(movement));
        //}

        if (windows[0].material.color.r == 1 && windows[0].material.color.b != 1 && windows[0].material.color.g != 1)
        {
            planetEmoji.GetComponent<Renderer>().material = MAT_planet2Emoji;
        }
        else if (windows[0].material.color.b == 1 && windows[0].material.color.r != 1 && windows[0].material.color.g != 1)
        {
            planetEmoji.GetComponent<Renderer>().material = MAT_planet1Emoji;
        }
        else if (windows[0].material.color.g == 1 && windows[0].material.color.b != 1 && windows[0].material.color.r != 1)
        {
            planetEmoji.GetComponent<Renderer>().material = MAT_planet3Emoji;
        }
        else if (windows[0].material.color.r == 1 && windows[0].material.color.b == 1 && windows[0].material.color.g == 1)
        {
            planetEmoji.GetComponent<Renderer>().material = BlankMaterial;
        }

        if (Input.GetKeyDown(KeyCode.Space) && slot > -1 ) {
            transform.GetChild(1).GetComponent<AudioSource>().Play(0);
            if (windows[0].material.color.r == 1) {

                GameObject _tmp = GameObject.Instantiate(redAlien as GameObject, shootingPoint.position, transform.rotation);
                _tmp.GetComponent<AlienLogic>().isAlienShooted = true;
                _tmp.GetComponent<Rigidbody>().velocity = speed * transform.up;

            } else if (windows[0].material.color.b == 1) {

                GameObject _tmp = GameObject.Instantiate(blueAlien as GameObject, shootingPoint.position, transform.rotation);
                _tmp.GetComponent<AlienLogic>().isAlienShooted = true;
                _tmp.GetComponent<Rigidbody>().velocity = speed * transform.up;

            }else if(windows[0].material.color.g == 1) {

                GameObject _tmp = GameObject.Instantiate(greenAlien as GameObject, shootingPoint.position, transform.rotation);
                _tmp.GetComponent<AlienLogic>().isAlienShooted = true;
                _tmp.GetComponent<Rigidbody>().velocity = speed * transform.up;

            }
            
            //windows[0].material.color = Color.white;
            if (slot > 0)
            {
                

                for (int i = 0; i < windows.Length - 1; i++) {
                        Color tmp = windows[i].material.color;
                        windows[i].material.color = windows[i + 1].material.color;
                        windows[i + 1].material.color = tmp;
                }

                
            }
            for(int i = slot; i < windows.Length; i++)
                windows[i].material.color = Color.white;

            slot--;
            
            //GameObject tmp = GameObject.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere), transform.position, transform.rotation);
            //tmp.transform.TransformDirection(transform.forward * speed);

           // Debug.Log(slot);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Alien") {
            Color color = other.GetComponent<Renderer>().material.color;
            if (slot < 4)
            {
                windows[++slot].material.color = color;
                transform.GetChild(2).GetComponent<AudioSource>().Play(0);
                Destroy(other.gameObject);
                SpawnManager.Instance.alienCounter--;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
            GetComponent<AudioSource>().Play(0);
            //Destroy(this.gameObject);
        }
    }
}
