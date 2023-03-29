using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gtpScript : MonoBehaviour
{
    // The player object that the enemy will move towards
    public Transform player;

    // The speed at which the enemy will move
    public float speed = 1.0f;

    // The force with which the enemy will jump
    public float jumpForce = 10.0f;

    // A reference to the enemy's Rigidbody2D component
    private Rigidbody2D rb;

    void Start()
    {
        // Get the enemy's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Calculate the direction from the enemy to the player
        Vector2 direction = player.position - transform.position;
        // Normalize the direction to get a unit vector (a vector with length 1)
        direction = direction.normalized;
        // Check if the player is in an unreachable position
        if (direction.y > 0)
        {
            // If the player is above the enemy, add a jump force to the enemy
            rb.AddForce(direction * jumpForce, ForceMode2D.Impulse);
        }
        // Move the enemy in the direction of the player at the specified speed
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}