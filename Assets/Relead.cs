using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;

public class Relead : MonoBehaviour
{
    public TextMeshProUGUI ammoInfoText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GunV2 currentGun = FindObjectOfType<GunV2>();
        ammoInfoText.text = currentGun.currentAmmo + " / " + currentGun.magazineSize;
    }
}
