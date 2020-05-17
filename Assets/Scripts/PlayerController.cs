using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed; //speed of the player
    private Rigidbody2D rb;
    public bool facingRight = true;  //if player is facing right or not
    public bool hasBooster = false;  //if player has picked up a booster gem or not
    public float boosterSpeedAmount = 0f;
    private float boosterTimeMax = 10f;
    private float boosterTimeCur = 0f;
    public int gemCount;
    public GameObject PauseButton, GameOver, RestartButton;

    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
    }

    //update method to call Move method
    void Update()
    {
        Move();

        Debug.Log(gemCount);
        //if the player has won, end came from LivesController class
        if (gemCount == 5)
        {
            PauseButton.SetActive(false);
            GameOver.SetActive(true);
            RestartButton.SetActive(true);
            Time.timeScale = 0;
        }
    }

    //Allows the user to move the player up, down, left, and right
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
    
        float moveX = x * speed;
        float moveY = y * speed;

        rb.velocity = new Vector2(moveX, moveY);

        //decides when to flip character to face the right direction
        if (x > 0 && !facingRight)
        {
            Flip();
        }
        else if (x < 0 && facingRight)
        {
            Flip();
        }
    }

    //flips the character to face the direction it's moving
    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void FixedUpdate()
    {
        //if boosterGem is picked up and it has been less than 10 seconds
        if (hasBooster && boosterTimeCur < boosterTimeMax)
        {
            speed = boosterSpeedAmount;
            boosterTimeCur += Time.fixedDeltaTime;

        }
        else
        {
            boosterTimeCur = 0f;
            speed = 10f;
            hasBooster = false;
        }

    }

    //Method called when player collides with a dinosaur
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //decreases amount of lives left
            LivesController.health -= 1;
            if (LivesController.health > 0)
            {
                StartCoroutine(Respawn());
            }
        }
    }

    //respawns the character at the middle of the maze and freezes screen for 2 seconds
    IEnumerator Respawn()
    {
        GetComponent<Renderer>().enabled = false;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(2);
        GetComponent<Renderer>().enabled = true;
        this.transform.position = new Vector3(14.5f, 14, 0);
        Time.timeScale = 1f;

    }
}
