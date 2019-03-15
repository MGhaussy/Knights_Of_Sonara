using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool isGameStarted = false;

    public bool IsGameStarted
    {
        get { return isGameStarted; }
        set
        {
            if (isGameStarted != value)
            {
                isGameStarted = value;
                manageScripts();
            }
        }
    }

    private MonoBehaviour[] components;

    // Start is called before the first frame update
    void Start()
    {
        components = GetComponents<MonoBehaviour>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void manageScripts()
    {
        switch (isGameStarted)
        {
            case true:
                foreach (MonoBehaviour c in components)
                {
                    c.enabled = true;
                }
                break;
            case false:
                foreach (MonoBehaviour c in components)
                {
                    if (c.GetType() != typeof(GameManager))
                    {
                        c.enabled = false;
                    }
                }
                break;
        }
    }
}
