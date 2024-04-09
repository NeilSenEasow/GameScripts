using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerMovement movement;

    public void GameEnds()
    {
        movement.enabled = false;
        Debug.Log("Character stopped");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Restart()
    {
        Debug.Log("Restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void EndGame() //this function has some errors
    {
        Debug.Log("GAME OVER");
        Invoke("Restart", 2f);
    }
    public void CompleteLevel()
    {
        Debug.Log("Game Won");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //This loads the next level which is the level Complete page
    }
}
