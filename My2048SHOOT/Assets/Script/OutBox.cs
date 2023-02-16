using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OutBox : MonoBehaviour
{
    //public List<GameObject> outObj = new List<GameObject>();
    public GameObject hpTextobj;
    public TextMeshProUGUI hpText;

    SceneChange theSceneChange;
    void Start()
    {
        theSceneChange = FindObjectOfType<SceneChange>();

    }

    /// <summary>
    /// 큐브가 밖에떨어지면 삭제후 체력감소
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

            //체력이 0이하가되면 게임오버
            if ((hp - cubeNumf) <= 0f)
            {
                theSceneChange.ParamSceneChange("GameOver");
            }
            
            

            Destroy(collision.gameObject);
        }
    }


}
