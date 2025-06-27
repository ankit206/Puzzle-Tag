using UnityEngine;

public class MeleeEnemy : EnemyBase
{
   
    public override void Attack()
    {
        Debug.Log("MeleeEnemy swings sword!");
    }
}