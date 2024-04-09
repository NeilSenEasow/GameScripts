using UnityEngine;

public class Collision : MonoBehaviour
{
    public PlayerMovement movement;
    //private object colliderInfo;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("We hit an obstacle");
            FindAnyObjectByType<GameManager>().Restart();
        }
    }
}
