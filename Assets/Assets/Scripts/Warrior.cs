using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Character   //Character
{
    public int maxHealth = 100;
    public int currentHealth;
    public int strength = 10;

    public HealthBar healthBar;
    public Animator animator;

    public Warrior(int maxHealth, int currentHealth, int strength, HealthBar healthBar, Animator animator) : base(maxHealth, currentHealth, strength)
    {
        this.healthBar = healthBar;
        this.animator = animator;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
        if (currentHealth <= 0)
        {
            // Implement game over logic or character death here
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("Die");
    }

    public void Attack(Enemy enemy)
    {
        int damage = strength; // You can add more complex calculations
        enemy.TakeDamage(damage);
    }
}
