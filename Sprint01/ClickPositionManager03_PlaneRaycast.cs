// Tej Vyas
// IT 201 - 007

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPositionManager03_PlaneRaycast : MonoBehaviour
{
    private GameObject primitive;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(1))
        {
            Vector3 clickPosition = -Vector3.one;

            Plane plane = new Plane(Vector3.up, 0f);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distanceToPlane;

            if (plane.Raycast(ray, out distanceToPlane))
            {
                clickPosition = ray.GetPoint(distanceToPlane);
            }

            Debug.Log(clickPosition);
            primitive = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            primitive.transform.position = clickPosition;
        }
    }
}

