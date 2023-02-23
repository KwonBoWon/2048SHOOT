using UnityEngine;

public class DragRotate : MonoBehaviour
{
    private Vector3 mouseStart;
    private Vector3 mouseDrag;
    private float rotateSpeed = 10f;

    void Update() {
        if(Input.GetMouseButtonDown(0)){
            
        }
    
    }
    void OnMouseDown()
    {
        mouseStart = Input.mousePosition;
    }

    void OnMouseDrag()
    {
        mouseDrag = Input.mousePosition;

        Vector3 difference = mouseDrag - mouseStart;
        mouseStart = mouseDrag;

        transform.Rotate(Vector3.up, difference.x * rotateSpeed * Time.deltaTime, Space.World);
    }
}
