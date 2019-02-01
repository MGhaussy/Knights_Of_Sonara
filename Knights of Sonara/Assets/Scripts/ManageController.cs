using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageController : MonoBehaviour
{
    private bool isControllerConnected = false;
    public List<string> keyboardKeys;
    public List<string> controllerKeys;
    private List<string> keysToUse;

    public List<string> KeysToUse
    {
        get { return keysToUse; }
        set { keysToUse = value; }
    }

    public bool IsControllerConnected
    {
        get { return isControllerConnected; }
        set
        {
            if (isControllerConnected != value)
            {
                isControllerConnected = value;
                Debug.Log("Keys Switched!");
                switchKeys();
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        switchKeys();
    }

    // Update is called once per frame
    void Update()
    {
        string[] controllers = Input.GetJoystickNames();

        for (int i = 0; i < controllers.Length; i++)
        {
            if (!string.IsNullOrEmpty(controllers[i]))
            {
                //controller connected
                IsControllerConnected = true;
                Debug.Log("Controller " + i + " is connected using: " + controllers[i]);
            }
            else
            {
                //controller disconnected
                isControllerConnected = false;
                Debug.Log("Controller " + i + " is disconnected");
            }
        }
    }

    private void switchKeys()
    {
        if (isControllerConnected)
        {
            KeysToUse = new List<string>(controllerKeys);
        }
        else
        {
            KeysToUse = new List<string>(keyboardKeys);
        }
    }
}
