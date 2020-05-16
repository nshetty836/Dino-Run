using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemPickup : MonoBehaviour
{
    private Text scoreText;
    private void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //AudioSource.PlayClipAtPoint(pickupClip, transform.position);
            Destroy(this.gameObject);
            scoreText.GetComponent<ScoreController>().score += 10;
            scoreText.GetComponent<ScoreController>().UpdateScore();
        }

    }
}
