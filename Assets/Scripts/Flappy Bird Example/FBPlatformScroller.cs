using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBPlatformScroller : MonoBehaviour
{ 
    public float maxX;
    public float minX;
    public float speed = 2;
    
    private void Update() 
    {
        Vector3 currentPosition = transform.position;
        
        float newX = currentPosition.x - speed * Time.deltaTime;
        
        if (newX < minX) {
            newX = maxX;
            GetComponent<FBColumnGenerator>().GenerateColumns();
        }
        
        transform.position = new Vector3(newX, currentPosition.y, currentPosition.z);

    
    }
}
