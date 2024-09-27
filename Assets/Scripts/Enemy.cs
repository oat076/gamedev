using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int enemyHP = 150;
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


    public void TakeDamage(int damageAmount)          // animations for the enemy getting hit and dying
    {
        enemyHP -= damageAmount;
        if (enemyHP <= 0)
        {
            ScoreScript.scoreValue += 800;

            //Play Death Animation
            animator.SetTrigger("death");
            GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            // Play Damage Animation
            animator.SetTrigger("damage");
        }
    }
}
