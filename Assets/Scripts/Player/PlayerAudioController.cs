using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    public AudioManager audioManager;

    public void PlayerAudioExplode()
    {
        audioManager.PlaySFX(audioManager.playerExplode);
    }

    public void PlayerAudioRevive()
    {
        audioManager.PlaySFX(audioManager.playerRevive);
    }

}
