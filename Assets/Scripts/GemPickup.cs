using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemPickup : MonoBehaviour
{
    private Text scoreText;
    public float boosterSpeedAmount = 15f;
    private void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "Booster Gem")
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<PlayerController>().hasBooster = true;
            scoreText.GetComponent<ScoreController>().score += 20;
            scoreText.GetComponent<ScoreController>().UpdateScore();
            collision.gameObject.GetComponent<PlayerController>().boosterSpeedAmount = boosterSpeedAmount;
        }
        else if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            scoreText.GetComponent<ScoreController>().score += 10;
            scoreText.GetComponent<ScoreController>().UpdateScore();
        }
    }
}
