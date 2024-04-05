using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    public void Next()
    {
        Debug.Log("NextButton was clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
