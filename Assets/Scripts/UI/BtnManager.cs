using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    [SerializeField] string mainMenu = "MainMenu";
    [SerializeField] string chooseLevel = "ChooseLevel";
    [SerializeField] string howToPlay = "HowToPlay";
    [SerializeField] string lv1 = "Level1";
    [SerializeField] string lv2 = "Level2";

    public void PlayBtn()
    {
        Time.timeScale = 1f;
        PauseMenu.isPause = false;
        GameManager.isAdventureMode = false;
        SceneManager.LoadScene(lv1);
    }

    public void AdventureBtn()
    {
        GameManager.isAdventureMode = true;
        SceneManager.LoadScene(lv1);
    }

    public void Level1()
    {
        SceneManager.LoadScene(lv1);
    }

    public void Level2()
    {
        SceneManager.LoadScene(lv2);
    }

    public void ReloadLevel()
    {
        // reset
        Time.timeScale = 1f;
        PauseMenu.isPause = false;

        string levelName = SceneManager.GetActiveScene().name;
        switch (levelName)
        {
            case "Level1":
                Lv1ScoreManager.scoreCount = 0;
                break;

            case "Level2":
                Lv2ScoreManager.scoreCount = 0;
                break;
        }


        // reload scene
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        PauseMenu.isPause = false;
        SceneManager.LoadScene(mainMenu);
    }

    public void Practice()
    {
        GameManager.isAdventureMode = false;
        SceneManager.LoadScene(chooseLevel);
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene(howToPlay);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
