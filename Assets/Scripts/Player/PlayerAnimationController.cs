using System;
using UnityEngine;
// Player animation Controller
[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Update player animation Acording To Moments
    public void UpdateMovement(Vector3 direction, bool isRunning)
    {
        bool isMoving = direction.magnitude > 0.1f;
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isRunning", isRunning);
    }
    // Trigger player animatio of attack
    public void TriggerAttack()
    {
        animator.SetTrigger("isAttacking");
    }
    // Trigger player animatio of Jump
    public void SetJumping(bool jumping)
    {
        animator.SetBool("isJumping", jumping);
    }
}