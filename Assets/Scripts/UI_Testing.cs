using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;
using UnityEngine.SceneManagement;

public class UI_Testing : MonoBehaviour
{
    private HighscoreTable highscoreTable;

    private void Start()
    {

        GameObject highscoreTableObject = GameObject.FindWithTag("HighscoreTable");
        if (highscoreTableObject != null)
        {
            highscoreTable = highscoreTableObject.GetComponent<HighscoreTable>();
        }

        transform.Find("submitScoreBtn").GetComponent<Button_UI>().ClickFunc = () =>
        {
            UI_Blocker.Show_Static();

            UI_InputWindow.Show_Static("Score", 0, () =>
            {
                // Clicked Cancel
                UI_Blocker.Hide_Static();
            }, (int score) =>
            {
                // Clicked OK
                UI_InputWindow.Show_Static("Player Name (Initials)", "", "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", 3, () =>
                {
                    // Cancel
                    UI_Blocker.Hide_Static();
                }, (string nameText) => {
                    // Ok
                    UI_Blocker.Hide_Static();
                    highscoreTable.AddHighscoreEntry(score, nameText);
                });
            });

        };

    }
}