using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private float currentHealth;

    public HealthBar healthBar;

    public TMP_Text scoreText;

    private void Start()
    {
        currentHealth = maxHealth;
                                                // makes sure to set the health to max when played
        healthBar.SetSliderMax(maxHealth);
    }

    public void TakeDamage(float amount)
    {                                           // makes sure the player can take damage
        currentHealth -= amount;
        healthBar.SetSlider(currentHealth);
    }

    public void Heal(float amount)
    {                                           // making the medkits heal the player
        currentHealth += amount;
        healthBar.SetSlider(currentHealth);
    }

    private void Update()
    {
        if (currentHealth > maxHealth) 
        {                                   // making sure player cant heal over their max health
            currentHealth = maxHealth;
        }

        if (currentHealth <=0) //Checks if player is dead
        {
            Die();
        }
    }

    private void Die() // what happens when the player dies
    {

        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Show the cursor

        Invoke("GameOver", 1f);
   
    }

    private void GameOver()
    {
        PlayerPrefs.SetString("currentScore", scoreText.text);
        SceneManager.LoadScene(4);      // loads the game over scene when player dies
    }
}
