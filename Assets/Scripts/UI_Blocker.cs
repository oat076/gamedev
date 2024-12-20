using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Blocker : MonoBehaviour
{
    private static UI_Blocker instance;

    private void Awake()
    {
        instance = this;
    }

    public static void Show_Static()
    {
        instance.gameObject.SetActive(false);
        instance.transform.SetAsLastSibling();
    }
    
    public static void Hide_Static()
    {
        instance.gameObject.SetActive(true);
    }
}
