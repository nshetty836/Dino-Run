using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public bool facingRight = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        BoundMovement();
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        float moveX = x * speed;
        float moveY = y * speed;

        rb.velocity = new Vector2(moveX, moveY);

        if (x > 0 && !facingRight)
        {
            Flip();
        }
        else if (x < 0 && facingRight)
        {
            Flip();
        }
 

    }

    void BoundMovement()
    {
        float dist = (this.transform.position - Camera.main.transform.position).z;

        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        float topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

        Vector3 playerSize = GetComponent<Renderer>().bounds.size;

        this.transform.position = new Vector3(
        Mathf.Clamp(this.transform.position.x, leftBorder + playerSize.x / 2, rightBorder - playerSize.x / 2),
        Mathf.Clamp(this.transform.position.y, topBorder + playerSize.y / 2, bottomBorder - playerSize.y / 2),
        this.transform.position.z
        );
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

    //public float speed = 0.4f;
    //Vector2 dest = Vector2.zero;
    //private bool m_FacingRight = true;

    //void Start()
    //{
    //    dest = transform.position;
    //}

    //void FixedUpdate()
    //{
    //    // Move closer to Destination
    //    Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
    //    GetComponent<Rigidbody2D>().MovePosition(p);

    //    // Check for Input if not moving
    //    if ((Vector2)transform.position == dest)
    //    {
    //        if (Input.GetKey(KeyCode.UpArrow) && Valid(Vector2.up))
    //            dest = (Vector2)transform.position + Vector2.up;
    //        if (Input.GetKey(KeyCode.RightArrow) && Valid(Vector2.right))
    //            dest = (Vector2)transform.position + Vector2.right;
    //        if (Input.GetKey(KeyCode.DownArrow) && Valid(-Vector2.up))
    //            dest = (Vector2)transform.position - Vector2.up;
    //        if (Input.GetKey(KeyCode.LeftArrow) && Valid(-Vector2.right))
    //            dest = (Vector2)transform.position - Vector2.right;
    //    }
    //}

    //bool Valid(Vector2 dir)
    //{
    //    Vector2 pos = transform.position;
    //    RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
    //    return (hit.collider == GetComponent<Collider2D>());
    //}

    //// If the input is moving the player right and the player is facing left...
    //            if (move > 0 && !m_FacingRight)
    //            {
    //                // ... flip the player.
    //                Flip();
    //            }
    //            // Otherwise if the input is moving the player left and the player is facing right...
    //            else if (move< 0 && m_FacingRight)
    //            {
    //                // ... flip the player.
    //                Flip();
    //            }

    //
}
