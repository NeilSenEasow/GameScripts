using UnityEngine;

public class Trigger : MonoBehaviour
{
 
    //public GameObject levelComplete;
    public void OnTriggerEnter()
    {
        FindAnyObjectByType<GameManager>().CompleteLevel();
        //levelComplete.SetActive(true);
        Debug.Log("Level Complete");
    }
}
