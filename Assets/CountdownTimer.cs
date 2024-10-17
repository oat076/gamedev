using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float currentTime = 0f;
    public int startingTime = 0;
    public TMP_Text countDownText;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("Time Taken: 0");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }

        

        PlayerPrefs.SetInt("Timer", (int)currentTime);
        PlayerPrefs.Save();
    }
}
