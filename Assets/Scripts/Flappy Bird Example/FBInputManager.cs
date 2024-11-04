using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FBCharacterSystem
{
    public class FBInputManager : MonoBehaviour
    {
        public static FBInputManager instance;

        private void Awake() 
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);

            } else if (instance != this) {
                Destroy(gameObject);
            }    
        }

        

        public bool fly;

        private void Update()
        {
            fly = Input.GetKeyDown(KeyCode.Space) ? true : false;
        }
    }

}
