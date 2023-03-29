using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyNew : MonoBehaviour
{
    public float moveSpeed;
    public GameObject player;
    public float attackDistance;
    public float attackRange = 0.7f;
    public Transform attackPoint;
    public int attackDamage = 20;
    public LayerMask playerLayer;

    private Animator anim;
    private bool inRangeToAttack;
    Rigidbody2D rb;
    public float attackRate = 0.8f;
    float nextAttackTime = 0;
    [SerializeField] private Collider2D enemy;
    [SerializeField] private Collider2D enemyBlocker;



    // Start is called before the first frame update
    void Awake()
    {
        Physics2D.IgnoreCollision(enemy, enemyBlocker, true);
        Physics2D.IgnoreCollision(enemy, enemy, true);
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("spawn"))
        {
            if (Vector2.Distance(player.transform.position, rb.position) <= attackDistance)
            {
                if (Time.time >= nextAttackTime)
                {
                    anim.SetBool("canWalk", false);
                    anim.SetTrigger("Attack");
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
            else Move(playerPosition);
        }
        
    }
    void Move(Vector3 playerPosition) {

        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("AttackSkel"))
        {
            anim.SetBool("canWalk", true);
            if (transform.position.x < playerPosition.x)
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            }
            else if (transform.position.x > playerPosition.x)
            {
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }
    

    }
    void Attack()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<PlayerCombat>().takeDamage(attackDamage);
        }
    }

    public void Die()
    {
        enemyBlocker.enabled = false;
        ScoreCounter.scoreValue += 10;
        this.enabled = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
