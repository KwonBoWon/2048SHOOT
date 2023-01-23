using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    float x, y, z;
    public static Vector3 point;

    // Start is called before the first frame update
    void Start()
    {
    }
    /// <summary>
    /// 대포의 방향을 마우스좌표로 회전
    /// </summary>
    void CannonRotate()
    {
        point = new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, 10-Camera.main.transform.position.z);

        point = Camera.main.ScreenToWorldPoint(point);

        point = point - transform.position;

        transform.rotation = Quaternion.FromToRotation(Vector3.up, point);
    }
    

    void Update()
    {
        CannonRotate();
    }
}
/*
큐브 프리펩을 캐논 위치에 생성> 중력 없엠> 큐브발사(중력 만듬)> 0.1초후 큐브생성>>
*/
