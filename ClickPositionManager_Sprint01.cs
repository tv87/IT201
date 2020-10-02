// Tej Vyas
// IT 201 - 007
// Sprint01

// This program creates chain of objects selected by user on Unity, when clicked on the scene.
// User will be able to select the color and shapes of the objects
// Objects will be deleted using Destroy() in the given time


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickPositionManager_Sprint01 : MonoBehaviour
{
    private int shape = 0;
    private GameObject primitive;
    private float red = 1f, green = 1f, blue = 1f;
    public Text mousePosition;

    [SerializeField]
    private float distance = 5f, distanceChange;

    private Vector3 clickPosition;
    private bool timeDestroyIsOn = true;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Destroy(hit.transform.gameObject);
            }
        }
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(1))
        {
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, distance));

            switch (shape)
            {
                case 0:
                    primitive = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    break;

                case 1:
                    primitive = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    break;

                case 2:
                    primitive = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    break;
            }
            primitive.transform.localScale = new Vector3(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
            //randomizing colors and scale
            primitive.transform.position = clickPosition;
            primitive.GetComponent<Renderer>().material.color = new Vector4(Random.Range(0f, red), Random.Range(0f, green), Random.Range(0f, blue), 1f);
            primitive.transform.parent = this.transform;
            if (timeDestroyIsOn)
            {
                Destroy(primitive, 3f);
            }
        }
        mousePosition.text = "Mouse Position x: " + Input.mousePosition.x.ToString("F0") + ", y: " + Input.mousePosition.y.ToString("F0");
    }

    public void changeShape(int tempShape)
    {
        shape = tempShape;
    }
    public void changeRed(int tempRed)
    {
        red = tempRed;
    }
    public void changeGreen(int tempGreen)
    {
        green = tempGreen;
    }
    public void changeBlue(int tempBlue)
    {
        blue = tempBlue;
    }
    public void destroyObjects()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void ToggleTimedDestroy(bool timer)
    {
        timeDestroyIsOn = timer;
    }
}

