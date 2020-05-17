using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void StartPause()
    {
        // how many seconds to pause the game
        StartCoroutine(PauseGame(5f));
    }
    public IEnumerator PauseGame(float pauseTime)
    {
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1f;
    }
}
