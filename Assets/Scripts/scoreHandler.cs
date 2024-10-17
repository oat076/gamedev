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

        timer.text = PlayerPrefs.GetInt("Timer").ToString();
    }

}
