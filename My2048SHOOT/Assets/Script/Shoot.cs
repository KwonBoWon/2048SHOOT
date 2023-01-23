using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//It will add in cannon


public class Shoot : MonoBehaviour
{
    void Start()
    {
    }
    void Update()
    {
    }
    /// <summary>
    /// 큐브를 캐논방향으로 파워만큼 발사함
    /// </summary>
    /// <param name="cube">날라갈 큐브</param>
    /// <param name="power">발사할 힘</param>
    public static void ShootCube(GameObject cube, float power){
        Rigidbody rb;
        rb = cube.GetComponent<Rigidbody>();   
        rb.AddForce(Cannon.point*power);
    }
}
