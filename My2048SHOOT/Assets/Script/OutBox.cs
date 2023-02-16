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
    /// ť�갡 �ۿ��������� ������ ü�°���
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

            //ü���� 0���ϰ��Ǹ� ���ӿ���
            if ((hp - cubeNumf) <= 0f)
            {
                theSceneChange.ParamSceneChange("GameOver");
            }
            
            

            Destroy(collision.gameObject);
        }
    }


}
