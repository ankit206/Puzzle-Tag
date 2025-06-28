using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void UpdateMovement(Vector3 direction, bool isRunning)
    {
        bool isMoving = direction.magnitude > 0.1f;
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isRunning", isRunning);
    }

    public void TriggerAttack()
    {
        animator.SetTrigger("isAttacking");
    }

    public void SetJumping(bool jumping)
    {
        animator.SetBool("isJumping", jumping);
    }
}