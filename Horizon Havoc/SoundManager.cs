using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    //public AudioSource shootingSoundPistol;
    public AudioSource shootingSoundPistol;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this alive between scenes if needed
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance of SoundManager exists
        }
    }
}
