using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public static List<GameObject> preCubes = new List<GameObject>();
    public static CubeManager instance;
    SceneChange theSceneChange;
    public GameObject cubeParents;
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

/*
현재 버그생기는 이유(추측)
코루틴으로 0.5초후 false를 리턴함
이 0.5초사이 -> 0.49초쯤 함수가실행되면 false로 풀리고 이과정에서 큐브에서 에러가나는것으로 추정
-> 코루틴이 실행중이면 코루틴을 중지하고 다시 코루틴을 시작해야함
*/
    /// <summary>
    /// 큐브둘을 합쳐서 다음큐브를 만들고 큐브둘을 삭제함
    /// </summary>
    /// <param name="cube1">큐브1 자리에 다음큐브 생성, 큐브1 삭제</param>
    /// <param name="cube2">큐브2 삭제</param>
    /// <param name="cubeName">큐브이름</param>
    public void MergeCube(GameObject cube1,GameObject cube2,  string cubeName){
        Cube cube1Cube = cube1.GetComponent<Cube>();
        Cube cube2Cube = cube2.GetComponent<Cube>();

        Vector3 core = new Vector3(0f, -3.7f, 11f);

        if(!cube1Cube.isUsed){
            if((cube1.transform.transform.position - core).magnitude  < (cube2.transform.transform.position - core).magnitude){//두큐브중 core가까운 큐브위치에서 생성
                Effect.audioSoure.Play(); //큐브 합치기 사운드
                int cubeNum = StringToInt(cubeName);
                if (cubeNum== 11) //큐브가 2048일때 엔딩씬으로
                {
                    SceneChange theSceneChange;
                    theSceneChange = FindObjectOfType<SceneChange>();
                    theSceneChange.ParamSceneChange("Clear");
                }
                GameObject mergedCube = Instantiate(preCubes[cubeNum], cube1.transform.position, Quaternion.identity); //큐브생성
                mergedCube.transform.SetParent(cubeParents.transform);
                mergedCube.transform.SetAsLastSibling();
                
                Destroy(cube1); Destroy(cube2); //합쳐진큐브 삭제
            }
            cube1Cube.isUsed = true; //여러개 같이 합쳐지는것 방지(cube1)
            if(cube1Cube.isCoroutineOn){//코루틴이 실행중이면 중지하고 다시 실행
                StopCoroutine(IsUsedBack(cube1));
                StartCoroutine(IsUsedBack(cube1));
            }
            else{
                StartCoroutine(IsUsedBack(cube1));
            }
            return;

        }
        else {
            cube2Cube.isUsed = true; //여러개 같이 합쳐지는것 방지(cube2)
            if(cube2Cube.isCoroutineOn){//코루틴이 실행중이면 중지하고 다시 실행
                StopCoroutine(IsUsedBack(cube2));
                StartCoroutine(IsUsedBack(cube2));
            }
            else{
                StartCoroutine(IsUsedBack(cube2));
            }
            return;
        }
    }

    /// <summary>
    /// isUsed 0.5초후 false return
    /// </summary>
    /// <param name="cube"></param>
    /// <returns></returns>
    IEnumerator IsUsedBack( GameObject cube){
        Cube cubeCube = cube.GetComponent<Cube>();

        cubeCube.isCoroutineOn = true;//코루틴실행중
        
        yield return new WaitForSeconds(0.5f);
    
        if(cube!=null){
            
            cubeCube.isUsed = false;
            cubeCube.isCoroutineOn = false;
        }
    }

    /// <summary>
    /// log함수 대용
    /// </summary>
    /// <param name="param">큐브네임</param>
    /// <returns></returns>
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
                case "16(Clone)": //->4
                    answer = 4;
					break;
                case "32(Clone)": //->5
                    answer = 5;
					break;
                case "64(Clone)": //->6
                    answer = 6;
					break;
                case "128(Clone)": //->7
                    answer = 7;
					break;
                case "256(Clone)": //->8
                    answer = 8;
					break;
                case "512(Clone)": //->9
                    answer = 9;
					break;
                case "1024(Clone)": //->10
                    answer = 10;
					break;
                case "2048(Clone)": //->11
                    answer = 11;
                    
					break;
                
		}
        return answer;
    }
}
