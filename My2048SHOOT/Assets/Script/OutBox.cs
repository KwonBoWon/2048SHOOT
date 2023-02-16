using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OutBox : MonoBehaviour
{
    //public List<GameObject> outObj = new List<GameObject>();
    public GameObject hpTextobj;
    public TextMeshProUGUI hpText;
    
    
    

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.collider.CompareTag("cube"))
        {
            Debug.Log("Drop");
            float hp = float.Parse(hpText.text);
            string cubeNum = collision.gameObject.name;

            float cubeNumf =  CubeManager.StringToInt(cubeNum) ;
            cubeNumf = Mathf.Pow(2, cubeNumf);

            hpText.text = (hp - cubeNumf).ToString();

            Cube cube2 = collision.gameObject.GetComponent<Cube>();
            Destroy(collision.gameObject);
        }
    }


}
