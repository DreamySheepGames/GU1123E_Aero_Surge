using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text livesTxt;
    public static int livesCounter = 1;

    private void Start()
    {
        if (livesCounter == 0)
            livesCounter = 1;
    }

    private void Update()
    {
        livesTxt.text = livesCounter.ToString();
    }

}
