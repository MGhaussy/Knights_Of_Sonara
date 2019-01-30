using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject GameOverPanel;
    public Text textTime;
    public Text HighScore;
    public int score = 0;
	// Use this for initialization
	void Start () {
    
        GameOverPanel.SetActive(false);
        HighScore.text = PlayerPrefs.GetString("Score");
    }
	
	// Update is called once per frame
	void Update () { 
         textTime.text = score.ToString();
      //  Debug.Log(int.Parse(HighScore.text));

    }

    public void GameOver() {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
        int tmp;
        int.TryParse(HighScore.text, out tmp);
        if (score > tmp) {
            PlayerPrefs.SetString("Score", score.ToString());
            PlayerPrefs.Save();
        }
    }
}
