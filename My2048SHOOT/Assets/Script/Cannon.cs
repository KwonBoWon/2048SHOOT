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
    public GameObject nextTextobj;
    TextMeshProUGUI nextText;

    public GameObject nextCubePrefab;
    public GameObject nextCubePos;
    bool isDelay = false;


    float power = 0;
    float x, y, z;

    // Start is called before the first frame update
    void Start()
    {
        theCreatCube = FindObjectOfType<CreatCube>();
        powerText = powerTextobj.GetComponent<TextMeshProUGUI>();
        nextText = nextTextobj.GetComponent<TextMeshProUGUI>();
        isDelay = false;
        power = 0;

        nextCubePrefab = Instantiate(CubeManager.preCubes[0], nextCubePos.transform.position, Quaternion.identity);
        nextCubePrefab.transform.localScale -= new Vector3(0.8f, 0.8f, 0.8f);
        //Rigidbody rigi = nextCubePrefab.GetComponent<Rigidbody>();
        Destroy(nextCubePrefab.GetComponent<Rigidbody>());
        Destroy(nextCubePrefab.GetComponent<BoxCollider>());
    }
    /// <summary>
    /// 대포의 방향을 마우스좌표로 회전
    /// </summary>
    public void CannonRotate()
    {
        point = new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, 10 - Camera.main.transform.position.z);

        point = Camera.main.ScreenToWorldPoint(point);

        point = point - transform.position;

        transform.rotation = Quaternion.FromToRotation(Vector3.up, point);
    }
    /// <summary>
    /// 큐브를 캐논방향으로 파워만큼 발사함
    /// </summary>
    /// <param name="cube">날라갈 큐브</param>
    /// <param name="power">발사할 힘</param>
    public void ShootCube(GameObject cube, float power)
    {
        Rigidbody rb;
        rb = cube.GetComponent<Rigidbody>();
        rb.AddForce(point * power, ForceMode.VelocityChange);
    }

    void Update()
    {
        if (!Setting.isSettingOn)
        {
            /*
            if (CreatCube.onClick)
            {
                CannonRotate();
            }
            */
            CannonRotate();
            // 클릭할때 큐브생성
            if (Input.GetMouseButtonDown(0) && CreatCube.onClick && !isDelay)
            {
                CreatCube.onClick = false;
                //theCreatCube.CubeSpawn();
                //CreatCube.nowCube.GetComponent<BoxCollider>().enabled = false; // 발사전 합쳐져서 삭제되는것 방지
            }

            // 클릭하고있으면 누르면 파워증가
            if (Input.GetMouseButton(0) && !CreatCube.onClick && !isDelay)
            {
                
                if (power < 10f) power = power + 1.5f * Time.deltaTime;
                //Debug.Log(power);
                powerText.text = power.ToString("F1");
            }

            // 클릭을 떼면 발사
            if (Input.GetMouseButtonUp(0) && !CreatCube.onClick && !isDelay)
            {

                theCreatCube.CubeSpawn();
                CreatCube.nowCube.GetComponent<BoxCollider>().enabled = false; // 발사전 합쳐져서 삭제되는것 방지

                isDelay = true;
                Invoke("isDelayFalse", 0.15f);//발사 딜레이
                ShootCube(CreatCube.nowCube, power);
                power = 0;
                Debug.Log(CreatCube.nowCube);
                CreatCube.nowCube.GetComponent<Rigidbody>().useGravity = true;
                CreatCube.onClick = true;

                CreatCube.nowCube.GetComponent<BoxCollider>().enabled = true;
                //theCreatCube.CubeSpawn();   
                CreatCube.MakeRandomCube(CubeManager.LargestCube);
                //nextText.text = $"Next: {Mathf.Pow(2, (CreatCube.nextCube + 1))}";
                Destroy(nextCubePrefab);
                nextCubePrefab = Instantiate(CubeManager.preCubes[CreatCube.nextCube], nextCubePos.transform.position, Quaternion.identity);
                nextCubePrefab.transform.localScale -= new Vector3(0.8f, 0.8f, 0.8f);
                //Rigidbody rigi = nextCubePrefab.GetComponent<Rigidbody>();
                Destroy(nextCubePrefab.GetComponent<Rigidbody>());
                Destroy(nextCubePrefab.GetComponent<BoxCollider>());
                //$"A: {a} / B: {b} 1+2 = {1+2}“gameObject.transform.position
            }

        }
    }
    void isDelayFalse()
    {
        isDelay = false;
    }
}
/*
큐브 프리펩을 캐논 위치에 생성> 중력 없엠> 큐브발사(중력 만듬)> 0.1초후 큐브생성>>


지금 넣어야하는거


드래그로도 할 수있게 구현하기

게임 커버사진

2 4 8 tkwls

*/
