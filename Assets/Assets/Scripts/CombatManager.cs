using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    //public Character playerCharacter;
    //public Enemy enemy;

    //private bool playerTurn = true; // Player starts first

    public Elena elena;
    public Warrior warrior;

    private bool elenaTurn = true ;


    private float attackCooldown = 3.0f; // The time in seconds between attacks
    private float nextAttackTime = 0.0f; // The time when the next attack can occur
    private Vector3 elenaStartPosition;
    private Vector3 warriorStartPosition;
    private bool elenaOnAttack = false;
    private bool warriorOnAttack = false;
    private Animator elenaAnimator;
    private Animator warriorAnimator;


    // Start is called before the first frame update
    void Start()
    {
        // Set the initial nextAttackTime to the current time
        nextAttackTime = Time.time + 5.0f;
        elenaStartPosition = elena.transform.position;
        warriorStartPosition = warrior.transform.position;
        elenaAnimator = elena.GetComponentInChildren<Animator>();
        warriorAnimator = warrior.GetComponentInChildren<Animator>();
    }
    
    // Update is called once per frame
    private void Update()
    {
        warriorAnimator.SetFloat("velocityX", warrior.GetComponent<Rigidbody2D>().velocity.x);
        elenaAnimator.SetFloat("velocityX", elena.GetComponent<Rigidbody2D>().velocity.x);
        if(elenaTurn && Mathf.Abs(elena.transform.position.x - warriorStartPosition.x) < 0.9f && elena.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            Debug.Log("1");
            elena.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            ElenaPerformMeleeAttack();
        }
        else if (!elenaTurn && Mathf.Abs(warrior.transform.position.x - elenaStartPosition.x ) < 0.9f && warrior.GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            Debug.Log("2");
            warrior.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            WarriorPerformMeleeAttack();
        }
        else if (elenaTurn && Mathf.Abs(elena.transform.position.x - elenaStartPosition.x) < 0.1f && elena.GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            Debug.Log("3");
            elena.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            elenaTurn = false;
        }
        else if (!elenaTurn && Mathf.Abs(warrior.transform.position.x - warriorStartPosition.x) < 0.1f && warrior.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            Debug.Log("4");
            warrior.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            elenaTurn = true;
        }

        /*
        if (playerTurn)
        {
            /*
            // Player's turn
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerCharacter.Attack(enemy);
                playerTurn = false;
            }
            * /

            playerCharacter.Attack(enemy);
            playerTurn = false;

        }
        else
        {
            // Enemy's turn
            enemy.Attack(playerCharacter);
            playerTurn = true;
        }
        */

        /*
        if (elenaTurn)
        {
            Debug.Log("warrior got hurt");
            int damage = 20;//some business codes
            warrior.TakeDamage(damage);
            
            elenaTurn = false;
        }
        else
        {
            Debug.Log("elena got hurt");
            elena.TakeDamage(10);

            elenaTurn = true;
        }
        */

        if (Time.time >= nextAttackTime)
        {
            // Perform the player's attack action here

            if (elenaTurn && elena.GetComponent<Rigidbody2D>().velocity.x == 0)
            {
                //depending on the item, ElenaInitiateMeleeAttack() or ElenaInitiateBowAttack()
                ElenaInitiateMeleeAttack();
            }
            else if (!elenaTurn && warrior.GetComponent<Rigidbody2D>().velocity.x == 0)
            {
                Debug.Log("Time initiate");
                WarriorInitiateMeleeAttack();
            }

            // Update nextAttackTime for the next attack
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    private void ElenaInitiateMeleeAttack()
    {
        elenaOnAttack = true;
        elena.GetComponent<Rigidbody2D>().velocity = new Vector3(5, 0, 0);
    }

    private void ElenaInitiateBowAttack()
    {
        //bow animation trigger here
        elenaAnimator.SetTrigger("bow");
        int damage = 20;//some business codes
        warrior.TakeDamage(damage);

        elenaTurn = false;
    }

    private void ElenaPerformMeleeAttack()
    {
        //hit animation trigger here
        int damage = 20;//some business codes
        elenaAnimator.SetTrigger("hit");
        warrior.TakeDamage(damage);

    }

    private void WarriorInitiateMeleeAttack()
    {
        Debug.Log("Attack Initiated");
        warriorOnAttack = true;
        warrior.GetComponent<Rigidbody2D>().velocity = new Vector3(-5, 0, 0);
    }

    private void WarriorPerformMeleeAttack()
    {
        //hit animation trigger here
        warriorAnimator.SetTrigger("hit");
        elena.TakeDamage(10);
    }
}
