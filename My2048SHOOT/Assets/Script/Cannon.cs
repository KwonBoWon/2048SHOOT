using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    float x, y, z;


    // Start is called before the first frame update
    void Start()
    {
    }
    void Cannon_rotate()
    {
        Vector3 point = new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, 10-Camera.main.transform.position.z);

        point = Camera.main.ScreenToWorldPoint(point);

        point = point - transform.position;

        transform.rotation = Quaternion.FromToRotation(Vector3.up, point);
        //this.x = point.x;
        //this.y = point.y;

    }
    // Update is called once per frame
    void Update()
    {
        Cannon_rotate();
    }
}
