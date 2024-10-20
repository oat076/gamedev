using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreHandler : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text highScore;
    public TMP_Text timer;

    public void Start()
    {
        int currentScore = ScoreScript.scoreValue;
        score.text = currentScore.ToString();

        if (currentScore > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", currentScore);
            highScore.text = currentScore.ToString();
        }

        highScore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();

        PlayerPrefs.Save();

        string currentTime = PlayerPrefs.GetString("Timer", "0"); // getting time

        float elapsedTime = float.Parse(currentTime);  // making time into a float

        int minutes = Mathf.FloorToInt(elapsedTime / 60);  // making it display in minutes and seconds
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
