using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject HowToMenu;
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void HowToPlay()
    {
        HowToMenu.SetActive(true);
    }

    public void BackToStart()
    {
        HowToMenu.SetActive(false);
    }

}
