using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    //public GameObject Credits;
    //public GameObject MainMenu;

	// Use this for initialization
	void Start () {
   //     Credits.SetActive(false);
	}

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    //public void CreditsMenu() {
    //    MainMenu.SetActive(false);
    //    Credits.SetActive(true);
    //}

    //public void ShowMenu() {
    //    MainMenu.SetActive(true);
    //    Credits.SetActive(false);
    //}

    public void Exit() {
        Application.Quit();
    }

    public void Restart() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
