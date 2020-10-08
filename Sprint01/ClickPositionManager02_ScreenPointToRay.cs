// Tej Vyas
// IT 201 - 007

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPositionManager02_ScreenPointToRay : MonoBehaviour
{
    public LayerMask clickMask;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(1))
        {
            // Create a vector with 3 positions x,y and z and 3 values of the positions
            // The vector should store mouse positions
            Vector3 clickPosition = -Vector3.one;

            // Creates a ray that returns a coordinate position of Vector3 
            // and shoots a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Declare a raycasthit variable from where the ray will hit a collider
            RaycastHit hit;

            /*
            if (Physics.Raycast(ray, out hit))
            {
                clickPosition = hit.point;
                GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                primitive.transform.position = clickPosition;
            }
            */ 

            if(Physics.Raycast(ray, out hit, 100f, clickMask))
            {
                clickPosition = hit.point;
                GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                primitive.transform.position = clickPosition;
            }

            // Print the position of the shape
            Debug.Log(clickPosition);
        }
    }
}
