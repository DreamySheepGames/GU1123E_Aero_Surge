using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lv2ScoreManager : MonoBehaviour
{
    public Text scoreTxt;
    public Text highScoreTxt;

    public static int scoreCount;
    public static int highScoreCount;

    private string saveKey = "Lv2HighScore";

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
        // Set high score save with PlayerPrefs
        if (scoreCount >= highScoreCount)
        {
            PlayerPrefs.SetInt(saveKey, highScoreCount);
            highScoreCount = scoreCount;
        }

        scoreTxt.text = "SCORE: " + Mathf.Round(scoreCount);
        highScoreTxt.text = "HIGH SCORE: " + Mathf.Round(highScoreCount);
    }
}
