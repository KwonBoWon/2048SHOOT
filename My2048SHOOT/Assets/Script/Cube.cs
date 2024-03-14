using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    bool firstCollision = false;
    public bool isUsed = false; //첫번쨰충돌(벽이나 큐브) 까지 꺼야함 여러개 충돌시 함수 하나만 실행하기위해 사용
    public bool isCoroutineOn = false;
    private void OnCollisionEnter(Collision collision)
    {   
        //if(isUsed){
        //    return ;
        //}
        if(!firstCollision){
            
            if(collision.collider.CompareTag("cube") && gameObject.name == collision.gameObject.name){
                Cube cube2 = collision.gameObject.GetComponent<Cube>();

                
                CubeManager.instance.MergeCube(gameObject, collision.gameObject, gameObject.name);
                //cube2.isUsed = true;
                //isUsed = true;
            }
        }
        else{
            firstCollision = true;
        }
    }
    void Start()
    {
        firstCollision = false;
        isUsed = false;
    }
}
