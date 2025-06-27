using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 3f;
    public Transform[] waypoints;
    protected int currentWaypoint = 0;

    [Header("Stats")]
    public float health = 100f;

    [Header("Health and power")]
    public float attackRange = 2f;
    public float AttackPower;
    public Animator animator;
    [Header( "Player")]
    public GameObject player;
    public float detectionRange = 10f;
    public float attackCooldown = 2f;
    private float lastAttackTime;
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        player= GameManager.Instance.GetPlayer();
    }
    protected virtual void Update()
    {
        Patrol();
        CheckPlayerDistance();
    }
    // Enemy Patrol 
    protected void Patrol()
    {
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
        if (player && Vector3.Distance(transform.position, player.transform.position) < detectionRange)
        {
            Vector3 dir = (player.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 5);

            if (Time.time > lastAttackTime + attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0) Die();
    }

    public virtual void Die()
    {
        Debug.Log($"{gameObject.name} died.");
        Destroy(gameObject);
    }
   
    public abstract void Attack(); // must be overridden in child classes
}