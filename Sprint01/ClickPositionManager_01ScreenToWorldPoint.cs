// Tej Vyas
// IT 201 - 007

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPositionManager_01ScreenToWorldPoint : MonoBehaviour
{
    [Range(1f, 30f)]
    [SerializeField]
    public float distance = 10f;
    public GameObject fancy;
    [Range(-3f, 3f)]
    [SerializeField]    
    public float distanceChange = 1f;

    /* Start is called before the first frame update
    void Start()
    {
        
    }
    */

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButton(1))
        {
            distance += distanceChange;

            // Create a vector with 3 positions x,y and z and 3 values of the positions
            // The vector should store mouse positions
            
            Vector3 clickPosition = -Vector3.one;

            // Find the mouse position
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, distance));

            // Print the mouse position to the screen and see where it is reclicking
            Debug.Log(clickPosition);
            //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //sphere.transform.position = clickPosition;

            GameObject tempGO = Instantiate(fancy, clickPosition, Quaternion.identity);
            Destroy(tempGO, 3f);

            Instantiate(fancy, clickPosition, Quaternion.identity);
            Destroy(fancy, 3f);

            //Instantiate(fancy, clickPosition, Quaternion.identity);

        }
        
    }

    public void ChangeDistance(float change)
    {
        distance = change;
    }
}

