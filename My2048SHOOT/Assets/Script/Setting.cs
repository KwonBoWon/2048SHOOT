using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject settingUI;
    public static bool isSettingOn = false;
    /// <summary>
    /// Setting On/Off
    /// </summary>
    public void SettingButton()
    {
        if (isSettingOn)
        {
            settingUI.SetActive(false);
            Time.timeScale = 1.0F;
            isSettingOn = false;
        }
        else{
            settingUI.SetActive(true);
            Time.timeScale = 0.0F;
            isSettingOn=true;
        }
    }
    /// <summary>
    /// Quit
    /// </summary>
    public void QuitButton()
    {
        Application.Quit();
    }


}