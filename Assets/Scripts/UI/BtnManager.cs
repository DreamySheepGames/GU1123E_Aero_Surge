using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    [SerializeField] string mainMenu = "MainMenu";
    [SerializeField] string lv1 = "Level1";
    [SerializeField] string lv2 = "Level2";

    public void PlayBtn()
    {
        SceneManager.LoadScene(lv1);
    }

    public void Level2()
    {
        SceneManager.LoadScene(lv2);
    }

    public void ReloadLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void Menu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
