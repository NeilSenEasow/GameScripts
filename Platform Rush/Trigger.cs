using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public void OnTriggerEnter()
    {
        Debug.Log("Level Complete");
        FindAnyObjectByType<GameManager>().CompleteLevel();
    }
}
