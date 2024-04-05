using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float elapsedTime;
    public Text timerText;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        Debug.Log(elapsedTime.ToString("0"));
        timerText.text = elapsedTime.ToString("0");     
    }
}
