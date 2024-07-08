using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static bool isAdventureMode = false;
    public static bool isPracticeMode = false;

    [Header("PLAYER UI")]
    public Text livesTxt;
    public static int livesCounter = 1;
    public static int playerLevel = 1;
    public static int killCount = 0;

    public static int killBeforeLevelUp = 10;
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
        if (livesCounter <= 0 || SceneManager.GetActiveScene().name == "MainMenu")
        {
            livesCounter = 1;
        }
    }

    private void Update()
    {
        livesTxt.text = livesCounter.ToString();
    }
}
