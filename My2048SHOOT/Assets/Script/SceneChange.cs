using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject panel;
    public Image image;

    public string sceneName;
    float fadeCount = 0;

    public void FadeOut(){
        panel.SetActive(true);
        StartCoroutine(FadeCoroutine());
    }

    IEnumerator FadeCoroutine(){
        fadeCount = 0;
        while(fadeCount <1.5f){
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
           
        }
    }
    
    public void SceneChanges(){
        FadeOut();  
    }

    public void ParamSceneChange(string name)
    {
        FadeOut();
        sceneName = name;
    }

    void Start(){
        fadeCount = 0;
    }
    void Update()
    {
        if(fadeCount>=1.5f){
            SceneManager.LoadScene(sceneName);
        }
    }

}
