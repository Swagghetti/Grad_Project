using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elena : Character
{
    public int maxHealth = 100;
    public int currentHealth;
    public int strength = 10;

    public HealthBar healthBar;
    public Animator animator;

    public Elena(int maxHealth, int currentHealth, int strength, HealthBar healthBar, Animator animator) : base(maxHealth, currentHealth, strength)
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
        /*
        //on mobile devices, you don't have a physical keyboard, so the Input.GetKeyDown(KeyCode.Space) check won't work.
        if (Input.GetKeyDown(KeyCode.Space))
		{
            Debug.Log("Space entered.");
			TakeDamage(20);
		}
        */

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Touch detected.");
                TakeDamage(20);
            }
        }
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
