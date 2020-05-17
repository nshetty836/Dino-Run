using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemPickup : MonoBehaviour
{
    private Text scoreText;
    public float boosterSpeedAmount = 15f;
    public int gemCount = 0;
    //public GameObject PauseButton, GameOver, RestartButton;

    private void Start()
    {
        scoreText = GameObject.Find("ScoreNumText").GetComponent<Text>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "Booster Gem")
        {
            //gemCount++;
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<PlayerController>().hasBooster = true;
            scoreText.GetComponent<ScoreController>().score += 20;
            scoreText.GetComponent<ScoreController>().UpdateScore();
            collision.gameObject.GetComponent<PlayerController>().boosterSpeedAmount = boosterSpeedAmount;
        }
        else if (collision.gameObject.tag == "Player")
        {
            //gemCount++;
            Destroy(this.gameObject);
            scoreText.GetComponent<ScoreController>().score += 10;
            scoreText.GetComponent<ScoreController>().UpdateScore();
        }
        //collision.gameObject.GetComponent<PlayerController>().gemCount = gemCount;

    }
}
