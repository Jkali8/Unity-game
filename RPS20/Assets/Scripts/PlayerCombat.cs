using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Player player;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int maxHealth = 100;
    public int Health;
    public HealthBar healthBar;
    

    public int attackDamage = 40;
    public float attackRate = 2;
    float nextAttackTime = 0;
    // Update is called once per frame

    public void Start()
    {
        
        Health = maxHealth;
        healthBar.SetMaxhealth(Health);
    }


    void Update()
    {
        if(Time.time >=  nextAttackTime )
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        
    }

    void Attack()
    {

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Run2"))
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("We hit " + enemy.name);
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
            animator.SetTrigger("Attack");

        }


    }

    public void takeDamage(int Damage)
    {
        Health -= Damage;
        healthBar.setHealth(Health);
        
        if(Health <= 0)
        {
            Die();
        }
        animator.SetTrigger("hurt");
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    public void Die()
    {
        ScoreCounter.scoreValue = 0;
        animator.SetBool("isDead", true);
        GetComponent<Player>().Die();
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
