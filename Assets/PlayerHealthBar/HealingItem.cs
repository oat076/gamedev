using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public float healAmount;        // variables

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {                                                               // checking if player used medkit
            other.GetComponent<PlayerStats>().Heal(healAmount);
            Destroy(gameObject);    // destroys medkit if used
        }
    }
}
