using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;


    public int maxHealth = 100;
    int currentHealth;
    [SerializeField] private Collider2D ground;
    void Start()
    {
        ground.enabled = false;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
     
        animator.SetBool("isDead", true);
        GetComponent<enemyNew>().Die();
        GetComponent<BoxCollider2D>().enabled = false;
        ground.enabled = true;
        this.enabled = false;
        
    }
}
