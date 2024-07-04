using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPause = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
                ResumeGame();
            else
                PauseGame();

        }
    }

    public void PauseGame()
    {
        // Only pause if the player is still alive
        if (GameManager.livesCounter > 0)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            AudioManager.Instance.PauseMusic();
            isPause = true;
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        AudioManager.Instance.ResumeMusic();
        isPause = false;
    }
}
