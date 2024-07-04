using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    public void PlayerAudioExplode()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.playerExplode);
    }

    public void PlayerAudioRevive()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.playerRevive);
    }

}
