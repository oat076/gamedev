using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayButton ()
    {
        SceneManager.LoadScene (1);
    }

    public void OnInstructionsButton ()
    {
        SceneManager.LoadScene (2);
    }

    public void OnHighscoreButton ()
    {
        SceneManager.LoadScene(3);
    }

    public void OnQuitButton ()
    {
        Application.Quit();
    }

    public void OnBackButton ()
    {
        SceneManager.LoadScene(0);
    }
}

