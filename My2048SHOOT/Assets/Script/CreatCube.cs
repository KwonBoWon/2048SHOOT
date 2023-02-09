using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatCube : MonoBehaviour
{
    public static bool onClick = true; 
    public static GameObject nowCube;
    public GameObject cube2;
    public GameObject cubeParents;

    public List<GameObject> cubeList = new List<GameObject>();
    void Start()
    {
        
    }
    /// <summary>
    /// 큐브를 생성함
    /// </summary>
    /// <returns>생성한큐브 리턴</returns>
    public void CubeSpawn(){
        nowCube = Instantiate(cube2, gameObject.transform.position, Quaternion.identity);
        Debug.Log(this.transform.position);
        
        nowCube.transform.SetParent(cubeParents.transform);
        nowCube.transform.SetAsLastSibling();
        cubeList.Add(nowCube);

        Gravity(nowCube, false);

    }
    
    public void Gravity(GameObject obj ,bool gra){
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.useGravity = gra;
    }


    void Update()
    {
        if(Input.GetKeyDown("mouse 0") && onClick){
            onClick = false;
            CubeSpawn();
            Debug.Log(nowCube);
        }
    }

}
