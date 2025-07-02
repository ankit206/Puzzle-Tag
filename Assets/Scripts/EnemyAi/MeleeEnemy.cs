using System;
using UnityEngine;
using UnityEngine.UI;
//  
public class MeleeEnemy : EnemyBase
{
    [Header("ui")]
    public Slider healthSlider;

    public bool HasBow;
    public Transform ShootPostion;
    public GameObject mProjectile;
    public int takeDameage = 10;
    public bool EventAssine=false;
    public override void Attack()
    {
        animator?.SetBool("running", false);
        animator?.SetBool("walking", false);
        animator?.SetBool("Attack", true);
        if (HasBow && !EventAssine)
        {
            EventAssine=true;
            EventSystem.FireArrow += FireArro;
        }
        Debug.Log("MeleeEnemy swings sword!");
    }

    public void FireArro()
    {
        Instantiate(mProjectile, ShootPostion.position, ShootPostion.rotation);
        Debug.Log("Fire Arrow");
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

    private void OnDisable()
    {
        EventSystem.FireArrow -= FireArro;
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