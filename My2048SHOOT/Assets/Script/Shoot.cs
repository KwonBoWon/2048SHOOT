using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//It will add in cannon


public class Shoot : MonoBehaviour
{
    public GameObject cannon;
    // Start is called before the first frame update
    Rigidbody rb;
    float power = 30f;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            rb.AddForce(Cannon.point*power);

            
        }
    }
}
