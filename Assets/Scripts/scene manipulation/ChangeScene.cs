using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;
    public Animator anim;

    public void ChangeS() {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene() {
        anim.SetBool("call", true);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(sceneName);
        anim.SetBool("call", false);
    }

    public void Sair() {
        Application.Quit();
    }
}
