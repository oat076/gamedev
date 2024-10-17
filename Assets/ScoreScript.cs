using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;       // Variables
    TMP_Text score;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;                         // resrts the score to 0 everytime you play
        score = GetComponent<TMP_Text>();       
    }

    // Update is called once per frame
    void Update()
    {
        score.text = " " + scoreValue;      // displays the score on the screen

        PlayerPrefs.SetInt("playerScore", scoreValue);
        PlayerPrefs.Save();                                 // saves score to be displayed later

        
    }

    
}
