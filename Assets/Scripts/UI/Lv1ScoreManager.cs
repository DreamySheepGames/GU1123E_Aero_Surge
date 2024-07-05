using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lv1ScoreManager : MonoBehaviour
{
    public Text scoreTxt;
    public Text highScoreTxt;

    public static int scoreCount;
    public static int highScoreCount;

    private string saveKey = "Lv1HighScore";

    private void Start()
    {
        scoreCount = 0;

        // update high score with PlayerPrefs
        if (PlayerPrefs.HasKey(saveKey))
        {
            highScoreCount = PlayerPrefs.GetInt(saveKey);
        }
    }

    public void Update()
    {
        // Set high score save with PlayerPrefs, only set high score if player is not in Practice mode
        // Player can't score in Adventure mode, the code is put in Enemy.cs
        if (!GameManager.isPracticeMode && scoreCount >= highScoreCount)
        {
            PlayerPrefs.SetInt(saveKey, highScoreCount);
            highScoreCount = scoreCount;
        }

        scoreTxt.text = "SCORE: " + Mathf.Round(scoreCount);
        highScoreTxt.text = "HIGH SCORE: " + Mathf.Round(highScoreCount);
    }
}
