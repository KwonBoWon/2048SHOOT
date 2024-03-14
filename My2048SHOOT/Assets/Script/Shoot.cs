using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//It will add in cannon


public class Shoot : MonoBehaviour
{
    public static void ShootCube(GameObject cube, float power){
        Rigidbody rb;
        rb = cube.GetComponent<Rigidbody>();   
        rb.AddForce(Cannon.point*power);
    }
}
