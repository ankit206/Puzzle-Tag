using UnityEngine;
using UnityEngine.UI;

// bose level Enamy 
public class BossEnemy : EnemyBase
{
    public int takeDameage = 10;
    [Header("ui")]
    public Slider healthSlider;
    // Attack spacific to Boss Enamy
    public override void Attack()
    {
        Debug.Log("BossEnemy unleashes powerful attack!");
    }
    // Reduce Health
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
    // Make Enamy Die
    public override void Die()
    {
        base.Die();
        Debug.Log("BossEnemy plays custom death animation!");
    }
}
