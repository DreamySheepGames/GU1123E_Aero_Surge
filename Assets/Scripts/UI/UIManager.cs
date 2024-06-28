using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; set; }

    [Header("PLAYER LOST")]
    public GameObject loseTxt;
    public GameObject reloadBtn;

    [Header("PLAYER WON")]
    public GameObject winTxt;
    public GameObject nextLvBtn;        // last level has main menu btn as next lv button

    private void Start()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public void AfterLosing()
    {
        loseTxt.SetActive(true);
        reloadBtn.SetActive(true);
    }

    public void AfterWinning()
    {
        // avoid boss and player are dead at the same time
        if (GameManager.livesCounter > 0)
        {
            nextLvBtn.SetActive(true);
            winTxt.SetActive(true);
        }
    }
}
