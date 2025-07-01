using UnityEngine;
using UnityEngine.UI;
//  
public class MeleeEnemy : EnemyBase
{
    [Header("ui")]
    public Slider healthSlider;
    
    public int takeDameage = 10;
    public override void Attack()
    {
        Debug.Log("MeleeEnemy swings sword!");
    }

    public override void Heathdegrade()
    {
        health = health - takeDameage;
        if (health<=0)
        {
            Die();
        }
        updateHealth();
        Debug.Log("health degrade");
    }

    public void updateHealth()
    {
        healthSlider.value = health;
    }
    
    public override void Die()
    {
        base.Die();
        Debug.Log("mEnemy plays custom death animation!");
    }
}