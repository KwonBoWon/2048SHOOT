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
    void Start()
    {
        theSceneChange = FindObjectOfType<SceneChange>();

    }

    /// <summary>
    /// è´?? ??????????? ?????? è´?°Î???
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.collider.CompareTag("cube"))
        {
            float hp = float.Parse(hpText.text);
            string cubeNum = collision.gameObject.name;

            float cubeNumf =  CubeManager.StringToInt(cubeNum) ;
            cubeNumf = Mathf.Pow(2, cubeNumf);
            
            hpText.text = (hp - cubeNumf).ToString();

            //è´???? 0???????? ???????
            if ((hp - cubeNumf) <= 0f && !GameOver)
            {
                GameOver = true;
                theSceneChange.ParamSceneChange("GameOver");
            }
            
            

            Destroy(collision.gameObject);
        }
    }


}
