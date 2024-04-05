using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPScontroller : MonoBehaviour
{
    public Camera playerCamera;

    private CharacterController charController;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0f;

    public float walkSpeed = 2.0f;
    public float runSpeed = 4f;
    public float jumpPower = 5f;
    public float gravity = 9.8f;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    public bool canMove = true;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    private void Update()
    {
        Movement();
        Rotation();
    }

    private void Movement()
    {
        // Calculate movement direction based on input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;

        // Apply speed based on whether the player is walking or running
        float speed = canMove ? Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed : 0;
        charController.Move(move * speed * Time.deltaTime);

        // Apply gravity
        if (!charController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        else
        {
            moveDirection.y = 0f; // Reset vertical movement if grounded
        }

        // Jumping
        if (charController.isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpPower;
        }

        // Apply vertical movement
        charController.Move(moveDirection * Time.deltaTime);
    }

    private void Rotation()
    {
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
