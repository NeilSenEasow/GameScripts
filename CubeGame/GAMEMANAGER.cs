using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //bool gameEnded  = false
    public GameObject levelComplete;
    public Playermovement movement;
    //This function is called when the player collides with an object as of now and displays GameOver

    public void CompleteLevel()
    {
        levelComplete.SetActive(true);
        GameEnds();
    }

    public void GameEnds()
    {
        movement.enabled = false;
        Debug.Log("Character stopped");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EndGame() //this function has some errors
    {
        Debug.Log("GAME OVER");
        Invoke("Restart", 2f);
    }

    public void Restart()
    {
        Debug.Log("Restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
