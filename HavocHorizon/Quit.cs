using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quit Button was pressed!");
    }
}
