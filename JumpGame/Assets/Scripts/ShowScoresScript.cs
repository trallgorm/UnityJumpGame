using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowScoresScript : MonoBehaviour {
    public Text scoreText;
    public Text highScoreText;
    // Use this for initialization
    void Start () {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreText.text = "High Score: "+ PlayerPrefs.GetInt("HighScore");
        }
        if (PlayerPrefs.HasKey("Score"))
        {
            scoreText.text = "Score: " + PlayerPrefs.GetInt("Score");
        }
        
    }
	
}
