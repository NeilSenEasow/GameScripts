using System;
using UnityEngine;

public class Playermovement : MonoBehaviour
{

    public Rigidbody rb;

    // Start is called before the first frame update
    /*void Start()
    {
        rb.useGravity = false;
    }*/

    public float forwardforce = 2000f;
    public float sideforce = 1000f;
    public float backforce = 2000f;
    /*void Start()
    {
        rb.AddForce(0, 20, 100);
    }*/

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0, 0, forwardforce * Time.deltaTime );

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce( sideforce * Time.deltaTime, 0, 0);
            Debug.Log("D key was pressed!");
        }
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce( -sideforce * Time.deltaTime, 0, 0);
            Debug.Log("A key was pressed!");
        }
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce( 0, 0, forwardforce * Time.deltaTime);
            Debug.Log("W key was pressed!");
        }
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(0, 0, -backforce * Time.deltaTime);
            Debug.Log("s key was pressed!");
        }

        if ( rb.position.y < 0 )
        {
            Debug.Log("GAME OVER");
            FindAnyObjectByType<GameManager>().EndGame();
            //FindAnyObjectByType<GameManager>().Restart();
        }
    }
}
