using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;
    public bool toBossFight = false;
    public Submarine? submarino = null;
    public float time = 0f;

    public void Update() {
        if (submarino != null) {
            if (submarino.hp <= 0) {
                SceneManager.LoadScene(sceneName);
            }
        } 

        if(toBossFight) {
            if(time > 10) {
                SceneManager.LoadScene("BossFight");
            }
        }

        time+=Time.deltaTime;
    }

    public void ChangeS() {
        SceneManager.LoadScene(sceneName);
    }

    public void Sair() {
        Application.Quit();
    }
}
