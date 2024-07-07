using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject SubMenu;

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void GoToWin()
    {
        SceneManager.LoadScene("Win");
    }
    public void GoToControls()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void GoToLose()
    {
        SceneManager.LoadScene("Lose");
    }
    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnSubMenu()
    {
        SubMenu.SetActive(true);
    }
    public void OffSubMenu()
    {
        SubMenu.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }


}
