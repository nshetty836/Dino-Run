using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject HowToMenu;
    public GameObject Pausemenu, PauseButton;
    //loads the given scene name
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    //opens the how to play menu
    public void HowToPlay()
    {
        HowToMenu.SetActive(true);
        Time.timeScale = 0;
    }

    //goes back to the start menu
    public void BackToStart()
    {
        HowToMenu.SetActive(false);
        Time.timeScale = 1;
        
    }

    //pauses the game
    public void Pause()
    {
        Pausemenu.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0;

    }

    //resumes the game
    public void Resume()
    {

        Pausemenu.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;

    }

}
