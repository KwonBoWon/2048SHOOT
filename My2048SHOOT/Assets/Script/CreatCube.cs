using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class CreatCube : MonoBehaviour
{
    public static bool onClick = true; 
    public static GameObject nowCube;
    public GameObject cube2;
    public GameObject cubeParents;

    //public List<GameObject> cubeList = new List<GameObject>();

    void Start(){
        onClick = true; 
    }
    /// <summary>
    /// 큐브를 생성함
    /// </summary>
    /// <returns>생성한큐브 리턴</returns>
    public void CubeSpawn(){
        Debug.Log("random"+MakeRandomCube(CubeManager.LargestCube));

        nowCube = Instantiate(CubeManager.preCubes[MakeRandomCube(CubeManager.LargestCube-2)], gameObject.transform.position, Quaternion.identity);
        //Debug.Log(this.transform.position);
  
        
        nowCube.transform.SetParent(cubeParents.transform);
        nowCube.transform.SetAsLastSibling();
        //cubeList.Add(nowCube);

        Gravity(nowCube, false);

    }

    public int MakeRandomCube(int max){
        //CubeManager.LargestCube
        return Random.Range(0, max+1);        
    }
    
    public void Gravity(GameObject obj ,bool gra){
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.useGravity = gra;
    }


}
