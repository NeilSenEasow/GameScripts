using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    //public Playermovement playermovement;

    // Update is called once per frame
    void Update()   
    {
        //Debug.Log(player.position);
        transform.position = player.position + offset;
    }
}
