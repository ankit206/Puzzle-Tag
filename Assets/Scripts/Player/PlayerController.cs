using System;
using UnityEngine;
// Player Moment Controller
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 5f;
    public float runSpeed = 7f;
    public float rotationSpeed = 10f;

    private float currentSpeed;
    private Vector3 moveInput;
    public int Health=100;
    
    public int damage=10;
    public PlayerAnimationController animationController;

    public bool GamePaused=true;
    private void Start()
    {
        animationController = GetComponent<PlayerAnimationController>();
        EventSystem.OnHealthPostionused += OnHealthPostionused;
    }
    // Use health Potion to fix damage done by enamy
    private void OnHealthPostionused()
    {
        Health = Health + damage;
        EventSystem.OnHealthChanged?.Invoke(Health);
        Debug.Log("player used health posion");
    }

    void Update()
    {
        if (!GamePaused)
        {
            keyboardInput();
            Move();
            Rotate();
        }
    }

    // handel keyboard input
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
        animationController.UpdateMovement(moveInput,Input.GetKey(KeyCode.LeftShift));
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
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "damage")
        {
            Debug.Log("Took damage");
            TakeDamage(10);
            other.gameObject.SetActive(false);
        }
    }
    
    // handel take damage from enamy
    public void TakeDamage(int damage)
    {
        Health = Health-damage;
        Health = Mathf.Clamp(Health, 0, Health);

        // 🔥 This triggers EventBus for UI update
        EventSystem.OnHealthChanged?.Invoke(Health);

        if (Health <= 0)
        {
            
            // Add death logic
        }
    }
}