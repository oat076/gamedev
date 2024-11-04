using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    public Animator animator;
    private bool isScoped = false;
    public Camera fpsCam;
    InputAction scope;

    // Start is called before the first frame update
    void Start()
    {
        scope = new InputAction("Scope", binding: "<mouse>/rightButton");

        scope.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        GunV2 gun = FindObjectOfType<GunV2>();
        if (gun.isReloading || gun.currentAmmo == 0)
        {
            StartCoroutine(OnUnscoped());
        }
        else
        {
            if (scope.triggered)
            {
                isScoped = !isScoped;

                if (isScoped)
                {
                    StartCoroutine(OnScoped());
                }
                else
                {
                    StartCoroutine(OnUnscoped());
                }
            }
        }


    }

    IEnumerator OnScoped()
    {
        animator.SetBool("isAimed", true);
        yield return new WaitForSeconds(0f);
        fpsCam.fieldOfView = 40;


    }

    IEnumerator OnUnscoped()
    {
        animator.SetBool("isAimed", false);
        yield return new WaitForSeconds(0f);
        fpsCam.fieldOfView = 60;


    }
}
