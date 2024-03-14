using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OutBox : MonoBehaviour
{
    //public List<GameObject> outObj = new List<GameObject>();
    public GameObject hpTextobj;
    public TextMeshProUGUI hpText;
    bool GameOver = false;
    SceneChange theSceneChange;
    public static int hp;
    void Start()
    {
        theSceneChange = FindObjectOfType<SceneChange>();
        hp = 100;
    }

    /// <summary>
    /// ��?? ??????????? ?????? ��?��???
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.collider.CompareTag("cube"))
        {
            hp = int.Parse(hpText.text);
            string cubeNum = collision.gameObject.name;

            float cubeNumf =  CubeManager.StringToInt(cubeNum) ;
            cubeNumf = Mathf.Pow(2, cubeNumf);
            hp = hp - (int)cubeNumf;
            hpText.text = (hp).ToString();

            
            if ((hp - cubeNumf) <= 0f && !GameOver)
            {
                GameOver = true;
                theSceneChange.ParamSceneChange("GameOver");
            }


            CubeManager.cubeList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }


}
