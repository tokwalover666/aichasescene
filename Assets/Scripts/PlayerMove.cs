using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 4.0f;
    public float lookSensitivity = 2.0f;
    public float jumpForce = 10.0f;
    public float groundCheckRadius = 0.15f;
    public float gravityScale = -9.8f;
    public Vector2 lookRange = new Vector2(-85.0f, 85.0f);
    public KeyCode jumpKeyCode = KeyCode.Space;

    private float verticalLookAngle;
    private CharacterController characterController;
    private Camera cam;
    private Vector3 velocity;
    private bool isGrounded;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckRadius);

        HandleMovement();



        HandleGravity();
        HandleLook();
        HandleJumping();

    }

    private void HandleMovement()
    {
        var movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        movement = transform.TransformDirection(movement);
        movement *= moveSpeed;

        characterController.Move(movement * Time.deltaTime);
    }
    private void HandleLook()
    {
        var delta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        delta *= lookSensitivity;

        transform.Rotate(Vector3.up, delta.x);

        verticalLookAngle -= delta.y;
        verticalLookAngle = Mathf.Clamp(verticalLookAngle, lookRange.x, lookRange.y);
        cam.transform.localEulerAngles = new Vector3(verticalLookAngle, 0.0f, 0.0f);
    }

    private void HandleJumping()
    {
        if (Input.GetKeyDown(jumpKeyCode) && isGrounded)
        {
            velocity.y += jumpForce;

        }
    }

    private void HandleGravity()
    {
        velocity.y += gravityScale * Time.deltaTime;

        if (isGrounded && velocity.y < 0.0f)
        {
            velocity.y = gravityScale * 0.25f;

        }

        characterController.Move(velocity * Time.deltaTime);
    }
}
