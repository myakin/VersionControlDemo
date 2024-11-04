using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBEnvironmentScrollManager : MonoBehaviour 
{
    public GameObject system1;
    public GameObject system2; 
    public float maxX;
    public float minX;
    public float speed = 2;
    
    private void Update() 
    {
        ScrollElement(system1);
        ScrollElement(system2);
    
    } 

    private void ScrollElement(GameObject element) {
        Vector3 currentPosition = element.transform.position;
        
        float newX = currentPosition.x - speed * Time.deltaTime;
        
        if (newX < minX) {
            newX = maxX;
        }
        
        element.transform.position = new Vector3(newX, currentPosition.y, currentPosition.z);

        // element.transform.position += -element.transform.right * speed * Time.deltaTime;
        

    
    }   
}