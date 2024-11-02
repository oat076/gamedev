using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameWin : MonoBehaviour
{
    public TMP_Text scoreText;

    [SerializeField] private Transform player;

    private void OnTriggerEnter(Collider Portal)
    {

        if (ScoreScript.scoreValue >= 100000)
        {

            if (Portal.tag == "Player")           // checks to see if player has hit the portal
            {
                Cursor.lockState = CursorLockMode.None; // Unlock the cursor
                Cursor.visible = true; // Show the cursor

                PlayerPrefs.SetString("playerScore", scoreText.text);
                SceneManager.LoadScene(5, LoadSceneMode.Additive);
                SceneManager.LoadScene(3, LoadSceneMode.Additive);          // if yes load win scene
                
            }

        }
    }

}
