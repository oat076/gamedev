using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunV2 : MonoBehaviour
{
    public float damage = 100f;
    public float range = 200f; 
    public float fireRate = 15f;  
    public float impactForce = 30f; 

    public Camera fpsCam; 
    public ParticleSystem muzzleFlash; 
    public GameObject impactEffect; 
    public AudioSource P_Shoot; 
    public AudioClip P_Shoot_Clip; 
    public AudioSource Reloads; 
    public AudioClip Reloads_Clip; 
    public TextMeshProUGUI Ammoinfo; 
                                                // Variables

    public int maxAmmo = 10; 
    public int currentAmmo; 
    public int magazineSize;
    public float reloadTime = 1f;  
    public bool isReloading = false; 

    private float nextTimeToFire = 0f; 
    public Animator animator;


    void Start()
    {


        currentAmmo = maxAmmo; 
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("isReloading", false);
    }

    void Update()
    {

        FindObjectOfType<GunV2>();
        Ammoinfo.text = currentAmmo + " / " + maxAmmo;  // Ammo Counter


        if (isReloading)
            return;


        if (currentAmmo <= 0 && magazineSize > 0) 
        {
            StartCoroutine(Reload());
            return;

        }

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo) 
        {
            StartCoroutine(Reload());
        }




        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) 
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();



        }
    }


    // Reload when out of ammo
    IEnumerator Reload()
    {

        Reloads.PlayOneShot(Reloads_Clip, 4f); 


        isReloading = true;
        Debug.Log("Reloading..");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f); 

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false;


    }

    // Shooting the gun
    void Shoot()
    {

        muzzleFlash.Play();
        P_Shoot.PlayOneShot(P_Shoot_Clip);
        currentAmmo--;
        RaycastHit hit; 
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy HP = hit.transform.GetComponent<Enemy>();
            if (HP != null)
            {
                HP.TakeDamage(damage); 
            }


            if (hit.rigidbody != null) 
            {
                hit.rigidbody.AddForce(hit.normal);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }

}