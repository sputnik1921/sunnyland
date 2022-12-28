using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pressStart : MonoBehaviour
{
    public GameObject info;
    public GameObject mainMenu;
    private void Awake()
    {
        info.SetActive(false);
    }

    public void PressStart()
    {
        SceneManager.LoadScene(1);
    }
    public void PressQuit()
    {
        Application.Quit();
    }
    public void Info()
    {
        info.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void back()
    {
        info.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
