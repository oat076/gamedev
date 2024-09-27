using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform cam;

    // Update is called once per frame
    void LateUpdate()
    {                               // makes enemy health bar visible to player from every angle
        transform.LookAt(cam);
    }
}
