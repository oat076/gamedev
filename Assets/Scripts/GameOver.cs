using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text scoreText;

    void OnCollisionEnter(Collision collision)
    {

        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Show the cursor

        if (collision.gameObject.tag == "Player")           // checks to see if player has hit the world border
        {
            PlayerPrefs.SetString("playerScore", scoreText.text);
            SceneManager.LoadScene(4);          // if yes load game over scene
        }

        PlayerPrefs.Save();
    }

    public void RestartGame()       // making restart button work
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()  // making back to menu button work
    {
        SceneManager.LoadScene(0);
    }
}
