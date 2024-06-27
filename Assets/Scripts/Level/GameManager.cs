using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public AudioManager audioManager;

    [Header("PLAYER UI")]
    public Text livesTxt;
    public static int livesCounter = 1;
    public static int playerLevel = 1;
    public static int killBeforeLevelUp = 10;
    public static int killCount = 0;

    public static int playerLevelCap = 3;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        if (livesCounter == 0)
            livesCounter = 1;
    }

    private void Update()
    {
        livesTxt.text = livesCounter.ToString();
    }

    public void PlayPlayerLevelUpAudio()
    {
        audioManager.PlaySFX(audioManager.playerRevive);
    }
}
