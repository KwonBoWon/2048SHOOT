using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    float power = 0;
    private void OnCollisionEnter(Collision collision)
    {
        
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("space")){
            power= power + 0.2f;
            Debug.Log(power);
        }
        if(Input.GetKeyUp("space")){
            Shoot.ShootCube(gameObject, power);
            power = 0;
        }
    }
}
