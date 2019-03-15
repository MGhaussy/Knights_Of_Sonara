using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainUIManager : MonoBehaviour
{

    public List<Button> UIButtons;
    public GameObject fightWindowPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFightButtonPressed()
    {
        fightWindowPanel.SetActive(true);
        deactivateButtonsUI();
    }

    private void deactivateButtonsUI()
    {
        foreach (Button button in UIButtons)
        {
            button.interactable = false;
        }
    }

    public void activateButtonsUI()
    {
        foreach (Button button in UIButtons)
        {
            button.interactable = true;
        }
    }
}
