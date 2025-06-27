using UnityEngine;

public class BossEnemy : EnemyBase
{
    public override void Attack()
    {
        Debug.Log("BossEnemy unleashes powerful attack!");
    }

    public override void Die()
    {
        base.Die();
        Debug.Log("BossEnemy plays custom death animation!");
    }
}
