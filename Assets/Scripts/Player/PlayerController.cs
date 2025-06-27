using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 5f;
    public float runSpeed = 7f;
    public float rotationSpeed = 10f;

    private float currentSpeed;
    private Vector3 moveInput;

    void Update()
    {
        keyboardInput();
        Move();
        Rotate();
    }

    //  keyboard input
    private void keyboardInput()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        moveInput = new Vector3(h, 0, v).normalized;

        // Set speed based on input
        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
    }

    // move player
    private void Move()
    {
        if (moveInput.magnitude > 0.1f)
        {
            transform.position += moveInput * currentSpeed * Time.deltaTime;
        }
    }

    // Rotate Player
    private void Rotate()
    {
        if (moveInput.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveInput);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}