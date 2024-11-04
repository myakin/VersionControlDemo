using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBGameManager : MonoBehaviour
{
    public static FBGameManager instance;

    private void Awake() 
    {
        if (instance==null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }


    public Vector2Int minMaxNumOfColumns = new Vector2Int(3, 10);

    
}
