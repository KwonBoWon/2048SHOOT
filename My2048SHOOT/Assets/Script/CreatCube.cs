using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class CreatCube : MonoBehaviour
{
    public static bool onClick = true; 
    public static GameObject nowCube;
    public GameObject cube2;
    public GameObject cubeParents;
    public static int nextCube;

    //public List<GameObject> cubeList = new List<GameObject>();

    void Start(){
        onClick = true; 
    }
    /// <summary>
    /// 큐브를 생성함
    /// </summary>
    /// <returns>생성한큐브 리턴</returns>
    public void CubeSpawn(){
        //Debug.Log("random"+MakeRandomCube(CubeManager.LargestCube));

        nowCube = Instantiate(CubeManager.preCubes[nextCube], gameObject.transform.position, Quaternion.identity);
        //Debug.Log(this.transform.position);
  
        nowCube.transform.SetParent(cubeParents.transform);
        nowCube.transform.SetAsLastSibling();
        //cubeList.Add(nowCube);

        Gravity(nowCube, false);
    }

    public static void MakeRandomCube(int max){
        //CubeManager.LargestCube
        //nextCube = Random.Range(0, max + 1 - 2); //1/4까지중에 랜덤생성
        max = max - 2; //가장 큰 숫자의 1/4
        int cnt = 0;
        while (cnt < max) //랜덤 요소
        {
            if (Random.Range(0, 2) == 1) //50%
            {
                cnt++;
                continue;
            }
            else
            {
                nextCube = cnt;
                return;
            }
        }
        nextCube = cnt;
        return;

    }
    
    public void Gravity(GameObject obj ,bool gra){
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.useGravity = gra;
    }


}
