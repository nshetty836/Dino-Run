using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public bool facingRight = true;
    //GameManager gm = new GameManager();
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            LivesController.health -= 1;
            if (LivesController.health > 0)
            {
                StartCoroutine(Dead());
            }
        }
    }

    IEnumerator Dead()
    {
        GetComponent<Renderer>().enabled = false;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(2);
        GetComponent<Renderer>().enabled = true;
        this.transform.position = new Vector3(14.5f, 14, 0);
        Time.timeScale = 1f;

    }
}
