using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject HowToMenu;
    public GameObject Pausemenu, PauseButton;
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void HowToPlay()
    {
        HowToMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void BackToStart()
    {
        HowToMenu.SetActive(false);
        Time.timeScale = 1;
        
    }

    public void Pause()
    {
        Pausemenu.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0;

    }
    public void Resume()
    {

        Pausemenu.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;

    }

}
