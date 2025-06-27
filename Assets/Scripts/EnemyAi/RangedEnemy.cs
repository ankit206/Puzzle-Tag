using UnityEngine;

public class RangedEnemy : EnemyBase
{
    public GameObject projectilePrefab;
    public Transform firePoint;

    public override void Attack()
    {
        Debug.Log("RangedEnemy fires projectile!");
        if (projectilePrefab != null)
        {
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
    }
}
