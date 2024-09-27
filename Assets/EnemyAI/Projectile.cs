using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float damage;        // variables

    private void Start()
    {
        Destroy(gameObject, 10f);           // destroying the bullet after 10 seconds
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {                                                           // checking if bullet hits player
            other.GetComponent<PlayerStats>().TakeDamage(damage);
            Destroy(gameObject);       // destroys bullet if hits player
        }
    }

}
