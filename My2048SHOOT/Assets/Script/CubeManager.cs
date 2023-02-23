using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public static List<GameObject> preCubes = new List<GameObject>();
    public static CubeManager instance;
    SceneChange theSceneChange;
    
    void Awake() {
        instance = this;    
    }
    void Start(){
        
        //큐브 프리펩 찾아서 넣음
        for(int i=1;i<=11;i++){
            preCubes.Add(Resources.Load<GameObject>("Prefeb/"+(Mathf.Pow(2,i)).ToString()));
            Debug.Log(preCubes[i-1]);
        }
        theSceneChange = FindObjectOfType<SceneChange>();
    }
    /// <summary>
    /// 큐브둘을 합쳐서 다음큐브를 만들고 큐브둘을 삭제함
    /// </summary>
    /// <param name="cube1">큐브1 자리에 다음큐브 생성, 큐브1 삭제</param>
    /// <param name="cube2">큐브2 삭제</param>
    /// <param name="cubeName">큐브이름</param>
    public void MergeCube(GameObject cube1,GameObject cube2,  string cubeName){
        Cube cube1Cube = cube1.GetComponent<Cube>();
        Cube cube2Cube = cube2.GetComponent<Cube>();
        Effect.audioSoure.Play();
        Vector3 core = new Vector3(0.1f, -2f, 8f);
        if(!cube1Cube.isUsed){
            if((cube1.transform.transform.position - core).magnitude  < (cube2.transform.transform.position - core).magnitude){
                //int cubeNum = int.Parse(cubeName);
                int cubeNum = StringToInt(cubeName);
                if (cubeNum== 11)
                {
                    SceneChange theSceneChange;
                    theSceneChange = FindObjectOfType<SceneChange>();
                    theSceneChange.ParamSceneChange("Clear");
                }
                //cubeNum = (int)(Mathf.Log(2,cubeNum));// 2부터 시작하므로
                GameObject mergedCube = Instantiate(preCubes[cubeNum], cube1.transform.position, Quaternion.identity);
                
                Destroy(cube1); Destroy(cube2);
            }
            cube1Cube.isUsed = true;
                
            StartCoroutine(IsUsedBack(cube1));

        }
        else {
            cube2Cube.isUsed = true;
            StartCoroutine(IsUsedBack(cube2));
            return;
        }
    }

    IEnumerator IsUsedBack( GameObject cube){
    
        yield return new WaitForSeconds(0.5f);
    
        if(cube!=null){
            Cube cubeCube = cube.GetComponent<Cube>();
            cubeCube.isUsed = false;
        }
    }

    public static int StringToInt(string param){//mathf log함수가 왜 오류나는지 모르겠음
        int answer = 0;
        switch(param) {
				case "2(Clone)": //->1
                    answer = 1;
					break;
				case "4(Clone)": //->2
                    answer = 2;
					break;
				case "8(Clone)": //->3
                    answer = 3;
					break;
                case "16(Clone)": //->3
                    answer = 4;
					break;
                case "32(Clone)": //->3
                    answer = 5;
					break;
                case "64(Clone)": //->3
                    answer = 6;
					break;
                case "128(Clone)": //->3
                    answer = 7;
					break;
                case "256(Clone)": //->3
                    answer = 8;
					break;
                case "512(Clone)": //->3
                    answer = 9;
					break;
                case "1024(Clone)": //->3
                    answer = 10;
					break;
                case "2048(Clone)": //->3
                    answer = 11;
                    
					break;
                
		}
        return answer;
    }
}
