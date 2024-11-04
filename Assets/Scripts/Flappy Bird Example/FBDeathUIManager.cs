using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FBDeathUIManager : MonoBehaviour
{
    public Button restartButton;
    public Button quitButton;

    private void Start() {
        restartButton.onClick.AddListener(Restart);
        quitButton.onClick.AddListener(Quit);
    }

    public void Restart() {
        Time.timeScale = 1;
        FBSceneLoader.LoadScene("SampleScene");
    }

    public void Quit() {
        StopAllCoroutines();
        Application.Quit();
    }
}
