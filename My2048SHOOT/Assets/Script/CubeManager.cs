using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public static List<GameObject> preCubes = new List<GameObject>();

    
    void Start(){
        //preCubes[] = Resources.LoadAll<GameObject>("Prefeb/");

    }
    /// <summary>
    /// 큐브둘을 합쳐서 다음큐브를 만들고 큐브둘을 삭제함
    /// </summary>
    /// <param name="cube1">큐브1 자리에 다음큐브 생성, 큐브1 삭제</param>
    /// <param name="cube2">큐브2 삭제</param>
    /// <param name="cubeName">큐브이름</param>
    public static void MergeCube(GameObject cube1,GameObject cube2,  string cubeName){
        int cubeNum = int.Parse(cubeName);
        cubeNum = (int)(Mathf.Log(2,cubeNum)) -1;// 2부터 시작하므로
        GameObject mergedCube = Instantiate(preCubes[cubeNum], cube1.transform.position, Quaternion.identity);

        Destroy(cube1); Destroy(cube2);
    }
}
