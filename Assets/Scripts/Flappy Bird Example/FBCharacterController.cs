using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FBCharacterSystem
{
    public class FBCharacterController : MonoBehaviour 
    {
        public float forceMagnitude = 10000;
        public Sprite deathSprite;
        private Rigidbody2D rb;
        

        private void Start() 
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update() 
        {
            if (FBInputManager.instance.fly) 
            {
                rb.AddForce(Vector3.up * forceMagnitude * Time.deltaTime);
            }
        }


        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.tag == "Column") {
                Kill();
            }
            // if (other.collider.GetComponent<FBColumn>()) {
            //     Kill();
            // }
        }

        private void Kill() {
            // TODO: change animation sprite
            // // 1st way: reach SpriteRenderer and change the sprite
            // GetComponent<Animator>().enabled = false;
            // GetComponent<SpriteRenderer>().sprite = deathSprite;

            // 2nd way: change sprite by animator
            GetComponent<Animator>().SetBool("die", true);

            // TODO: pause game
            StartCoroutine(WaitForDieAnimationState());

            // TODO: bring a post-death UI
            FBSceneLoader.LoadScene("DeathUIScene", true);

        }

        private IEnumerator WaitForDieAnimationState() {
            while (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Die")) {
                // wait
                yield return null;
            }
            PauseGame();
        }
        private void PauseGame() {
            Time.timeScale = 0;
        }

       
        


    }
}
