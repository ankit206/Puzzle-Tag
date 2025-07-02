using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 3f;
    public float ChaseSpedd = 6f;
    public Transform[] waypoints;
    protected int currentWaypoint = 0;

    [Header("Stats")]
    public int  health = 100;

    [Header("Health and power")]
    public float attackRange = 2f;
    public float AttackPower;
    public Animator animator;
    [Header( "Player")]
    public GameObject player;
    public float detectionRange = 10f;
    public float AttackRange = 3f;
    public float attackCooldown = 2f;
    private float lastAttackTime;
    public bool Playerisinrange;

    protected NavMeshAgent agent;
    
    protected virtual void Start()
    {
       
        player= GameManager.Instance.GetPlayer();
    }
    protected virtual void Update()
    {
        
            CheckPlayerDistance();
       
    }
    // Enemy Patrol 
    protected void Patrol()
    {
        animator?.SetBool("running", false);
        animator?.SetBool("walking", true);
        animator?.SetBool("Attack", false);
            if (waypoints == null || waypoints.Length == 0) return;

            Vector3 targetPos = waypoints[currentWaypoint].position;
            Vector3 direction = (targetPos - transform.position).normalized;

            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 5f * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPos) < 0.5f)
            {
                currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            }
    }

    public void CheckPlayerDistance()
    {
        if (!player)
        {
            return;
        }
        var CurrentDistance = Vector3.Distance(transform.position, player.transform.position);
        if ( CurrentDistance< detectionRange)
        {
            Playerisinrange = true;
            if (CurrentDistance > attackRange)
            {
                ChasePlayer();
            }
            else
            {
                if (Time.time > lastAttackTime + attackCooldown)
                {
                    Attack();
                    lastAttackTime = Time.time;
                } 
            }
        }
        else
        {
            Patrol();
            Playerisinrange = false;
        }
    }
    protected void ChasePlayer()
    {
        animator?.SetBool("running", false);
        animator?.SetBool("walking", false);
        animator?.SetBool("Attack", false);
        if (player == null) return;

        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, ChaseSpedd * Time.deltaTime);
        FaceTarget(player.transform);
        animator?.SetBool("running", true);
    }
    void FaceTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0f; // ✅ Ignore vertical difference
        if (direction.magnitude > 0.01f)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0) Die();
    }

    public virtual void Die()
    {
        Debug.Log($"{gameObject.name} died.");
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Heathdegrade();
        }
    }
    

    public abstract void Attack();  
    public abstract void Heathdegrade(); // must be overridden in child classes
}