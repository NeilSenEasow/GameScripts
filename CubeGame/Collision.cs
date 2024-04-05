using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Score scoreText;
    public Playermovement movement;
    void OnCollisionEnter(Collision collisionInfo) //this function ensures that collision is marked
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            Debug.Log("Hit an obstacle!");
            movement.enabled = false;
            scoreText.enabled = false;
            Debug.Log("GAME OVER");
            FindAnyObjectByType<GameManager>().EndGame();
            //FindAnyObjectByType<GameManager>().Restart();
        }

    }
}
