using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleAni : MonoBehaviour
{
    //2.3 to -4.29
    public Transform Target;
    public float Speed = 1f;
    
    public void MoveTurtle(){
        transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
    
    }

}
