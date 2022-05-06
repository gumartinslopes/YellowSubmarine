using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;

    public void ChangeS() {
        SceneManager.LoadScene(sceneName);
    }

    public void Sair() {
        Application.Quit();
    }
}
