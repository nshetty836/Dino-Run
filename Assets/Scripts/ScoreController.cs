using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int score = 0;

    public void UpdateScore()
    {
        GetComponent<Text>().text = "" + score;

        //if the player has won, end game
        if (score == 3350)
        {
            LivesController.health = 4;
        }
    }
}
