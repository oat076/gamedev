using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreHandler : MonoBehaviour
{
    public GameObject currentScore;
    public GameObject highScore;
    

    private TMP_Text currentScoreText;
    private TMP_Text highScoreText;

    private int current;
    private int high;

    // Start is called before the first frame update
    void Start()
    {
        // targeting the text mesh components
        currentScoreText = currentScore.GetComponent<TMP_Text>();
        highScoreText = highScore.GetComponent<TMP_Text>();

        //changing the current score
        currentScoreText.text = PlayerPrefs.GetString("currentScore");

        //check whether the current score is more than the highscore
        current = System.Convert.ToInt32(PlayerPrefs.GetString("currentScore"));
        high = System.Convert.ToInt32(PlayerPrefs.GetString("highScore"));

        if(current > high)
        {
            PlayerPrefs.SetString("highScore", System.Convert.ToString(current));
        }

        highScoreText.text = PlayerPrefs.GetString("highScore");
    }

}
