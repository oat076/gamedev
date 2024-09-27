using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour
{



        public Transform shootPoint;
        public GameObject bullet;
        public Animator gunAnimator;
        [Range(0, 1)]
        public float disperseBullet;
        public AudioSource p_shootingSound;
        public int damageAmount = 20;

    private void Update()
        {
            if (Input.GetButton("Fire1"))
            {
                gunAnimator.SetBool("IsShooting", true);
                p_shootingSound = GetComponent<AudioSource>();
            }
        }

        public void Shoot()
        {
            StopShootingAn();
            GameObject newBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(shootPoint.forward * 2000 + new Vector3(Random.Range(disperseBullet, -disperseBullet), Random.Range(disperseBullet, -disperseBullet), 0) * 100);
            StopShootingAn();
            p_shootingSound.Play();

    }

        public void StopShootingAn()
        {
            gunAnimator.SetBool("IsShooting", false);
        }



}