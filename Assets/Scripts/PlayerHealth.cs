using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHealth : MonoBehaviour 
{
	public int health;    // Variables

	public void TakeDamage(int damage)
	{
		health -= damage;                               // making the player take damage
		Debug.Log("Health = " + health.ToString());
	}
}