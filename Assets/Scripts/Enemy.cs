using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private float enemyHP = 150f;
    public Slider healthBar;                    // variables
    public GameObject projectile;
    public Transform projectilePoint;

    public Animator animator;

    private void Update()
    {
        healthBar.value = enemyHP; // healthbar for the enemy
    }

    public void Shoot()             // makes the enemy be able to shoot
    {
        Rigidbody rb = Instantiate(projectile, projectilePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 30f, ForceMode.Impulse);
        rb.AddForce(transform.up * 7, ForceMode.Impulse);
    }


    public void TakeDamage(float amount)          // animations for the enemy getting hit and dying
    {
        enemyHP -= amount;
        if (enemyHP <= 0)
        {
            ScoreScript.scoreValue += Random.Range(800, 1000);

            //Play Death Animation
            animator.SetTrigger("death");
            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(gameObject, 15f);
        }
        else
        {
            // Play Damage Animation
            animator.SetTrigger("damage");
        }
    }
}
