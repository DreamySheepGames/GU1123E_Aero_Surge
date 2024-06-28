using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsBtnController : MonoBehaviour
{
    public GameObject settingsPopup;

    public void SettingsPopupOn()
    {
        settingsPopup.SetActive(true);
    }

    public void SettingsPopupOff()
    {
        settingsPopup.SetActive(false);
    }
}
