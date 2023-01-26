using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public static List<GameObject> preCubes = new List<GameObject>();

    
    void Start(){
        //큐브 프리펩 찾아서 넣음
        for(int i=1;i<=11;i++){
            preCubes.Add(Resources.Load<GameObject>("Prefeb/"+(Mathf.Pow(2,i)).ToString()));
            Debug.Log(preCubes[i-1]);
        } 
    }
    /// <summary>
    /// 큐브둘을 합쳐서 다음큐브를 만들고 큐브둘을 삭제함
    /// </summary>
    /// <param name="cube1">큐브1 자리에 다음큐브 생성, 큐브1 삭제</param>
    /// <param name="cube2">큐브2 삭제</param>
    /// <param name="cubeName">큐브이름</param>
    public static void MergeCube(GameObject cube1,GameObject cube2,  string cubeName){
        //int cubeNum = int.Parse(cubeName);
        int cubeNum = StringToInt(cubeName);    
        //cubeNum = (int)(Mathf.Log(2,cubeNum));// 2부터 시작하므로
        Debug.Log("#"+ cubeName);
        Debug.Log("*" + cubeNum);
        GameObject mergedCube = Instantiate(preCubes[cubeNum], cube1.transform.position, Quaternion.identity);

        Destroy(cube1); Destroy(cube2);
    }

    public static int StringToInt(string a){
        int b = 0;
        switch(a) {
				case "2(Clone)": //->1
                    b = 1;
					break;
				case "4(Clone)": //->2
                    b = 2;
					break;
				case "8(Clone)": //8->3
                    b = 3;
					break;
		}
        return b;
    }
}
