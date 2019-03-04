using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        bool allControllersNull = controllers.All(s => s == "");

        if (Input.GetJoystickNames().Length > 0 && !allControllersNull)
        {
             //controller connected
             IsControllerConnected = true;
             Debug.Log("Controller is connected");
        }
        else
        {
            //controller disconnected
            IsControllerConnected = false;
             Debug.Log("Controller is disconnected");
        }

        //switchKeys();

    }

    private void switchKeys()
    {
        if (IsControllerConnected)
        {
            KeysToUse = new List<string>(controllerKeys);
        }
        else
        {
            KeysToUse = new List<string>(keyboardKeys);
        }
    }
}
