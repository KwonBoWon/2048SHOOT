using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Setting : MonoBehaviour
{
    public GameObject settingUI;
    public static bool isSettingOn;

    void Start(){
        isSettingOn = false;
    }
    /// <summary>
    /// Setting On/Off
    /// </summary>
    public void SettingButton()
    {
        CreatCube.onClick = true; //클릭시 큐브발사 방지
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
    public void Restart(){
        Time.timeScale = 1.0F;
        SceneManager.LoadScene("Main");

    }

}
/*

큐브 큰거 

*/