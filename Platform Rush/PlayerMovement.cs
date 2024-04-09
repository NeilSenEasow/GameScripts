using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 3f;

    Vector3 moveDirection = new Vector3 (0, 0, 0);

    // Update is called once per frame
    public void Update()
    {

        Vector3 moveDirection = new Vector3(0, 0, 0);

        //rb.AddForce(0, 0, 10 * Time.deltaTime);

        if (Input.GetKey(KeyCode.W)) {
            moveDirection.z = moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.z = -moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x = -moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x = moveSpeed;
        }

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

    }
}
