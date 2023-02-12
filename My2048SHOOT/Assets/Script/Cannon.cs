using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Cannon : MonoBehaviour
{
    CreatCube theCreatCube;
    public static Vector3 point;
    public GameObject powerTextobj;
    TextMeshProUGUI powerText;

    
    float power =0;
    float x, y, z;

    // Start is called before the first frame update
    void Start()
    {
        theCreatCube = FindObjectOfType<CreatCube>();
        powerText = powerTextobj.GetComponent<TextMeshProUGUI>();
    }
    /// <summary>
    /// 대포의 방향을 마우스좌표로 회전
    /// </summary>
    public void CannonRotate()
    {
        point = new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, 10-Camera.main.transform.position.z);

        point = Camera.main.ScreenToWorldPoint(point);

        point = point - transform.position;

        transform.rotation = Quaternion.FromToRotation(Vector3.up, point);
    }
    /// <summary>
    /// 큐브를 캐논방향으로 파워만큼 발사함
    /// </summary>
    /// <param name="cube">날라갈 큐브</param>
    /// <param name="power">발사할 힘</param>
    public void ShootCube(GameObject cube, float power){
        Rigidbody rb;
        rb = cube.GetComponent<Rigidbody>();   
        rb.AddForce(point*power);
    }

    void Update()
    {
        if(CreatCube.onClick){
            CannonRotate();
        }

        // 스페이스바 누를때 큐브생성
         if(Input.GetKeyDown("space") && CreatCube.onClick){
            CreatCube.onClick = false;
            theCreatCube.CubeSpawn();
            CreatCube.nowCube.GetComponent<BoxCollider>().enabled = false; // 발사전 합쳐져서 삭제되는것 방지
  
        }

        // 스페이스바 누르면 파워증가
        if(Input.GetKey("space") && !CreatCube.onClick){
            power= power + 0.2f;
            //Debug.Log(power);
            powerText.text = power.ToString("F1");
        }

        // 스페이스바를 떼면 발사
        if(Input.GetKeyUp("space") && !CreatCube.onClick){
            ShootCube(CreatCube.nowCube, power);
            power = 0;
            Debug.Log(CreatCube.nowCube);
            CreatCube.nowCube.GetComponent<Rigidbody>().useGravity = true;
            CreatCube.onClick = true;

            CreatCube.nowCube.GetComponent<BoxCollider>().enabled = true;
            //theCreatCube.CubeSpawn();   
        }

    }
}
/*
큐브 프리펩을 캐논 위치에 생성> 중력 없엠> 큐브발사(중력 만듬)> 0.1초후 큐브생성>>


지금 넣어야하는거


드래그로도 할 수있게 구현하기

게임 커버사진

2 4 8 tkwls

클릭기능 -> 스페이스바
스페이스바로쏘기전에 충돌판정 없에야함

*/
