using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static int scoreValue = 0;
    public Text score;
    public Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Highscore", 0);
        scoreValue = 0;
        score.text = "Score: " + 0;
        UpdateHighScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue;
        CheckHighScore();
        UpdateHighScoreText();
    }

    void CheckHighScore ()
    {
        if(scoreValue > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", scoreValue);
        }
    }
    
    void UpdateHighScoreText()
    {
        Debug.Log(highScore.text);
        highScore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0);
    }
}
