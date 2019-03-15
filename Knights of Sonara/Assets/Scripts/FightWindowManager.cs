using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightWindowManager : MonoBehaviour
{
    public GameObject fightPanel;
    public MainUIManager mainUIManager;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onConfirmButtonPress()
    {
        fightPanel.SetActive(false);
        mainUIManager.activateButtonsUI();
        gameManager.IsGameStarted = true;
    }
}
