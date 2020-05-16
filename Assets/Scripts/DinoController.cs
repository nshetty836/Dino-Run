using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public Transform[] waypoints;
    int current = 0;
    public bool facingRight = true;

    public float speed = 0.3f;
    void FixedUpdate()
    {
        // Waypoint not reached yet? then move closer
        if (transform.position != waypoints[current].position)
        {
            Vector3 dino = transform.position = Vector3.MoveTowards(transform.position,
                                            waypoints[current].transform.position,
                                            speed * Time.deltaTime);
            if (waypoints[current].position.x > transform.position.x && !facingRight)
            {
                Flip();
            }
            else if (waypoints[current].position.x < transform.position.x && facingRight)
            {
                Flip();
            }
            GetComponent<Rigidbody2D>().MovePosition(dino);
        }
        // Waypoint reached, select next one
        else
            current = (current + 1) % waypoints.Length;
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;    
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameController.health -= 1;
            if (GameController.health == 0)
                Destroy(collision.gameObject);
        }

    }
}
