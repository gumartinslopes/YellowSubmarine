using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;
    public string scenePerTime="BossFight";
    public Submarine? submarino = null;
    public float time = 60f;
    private float timeAtual = 0f;

    public void Update() {
        if (submarino != null) {
            if (submarino.hp <= 0) {
                SceneManager.LoadScene(sceneName);
            }
        } 

        if(time != 0) {
            if(timeAtual > time) {
                SceneManager.LoadScene(scenePerTime);
            }
        }

        timeAtual+=Time.deltaTime;
    }

    public void ChangeS() {
        SceneManager.LoadScene(sceneName);
    }

    public void Sair() {
        Application.Quit();
    }
}
