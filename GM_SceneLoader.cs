using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM_SceneLoader: MonoBehaviour {

    public void START() {
        SceneManager.LoadScene(2);
    }

    public void RETRY(){
        SceneManager.LoadScene(2);
        GameManager.instance.Health = 3;
    }

    public void CONTROLS() {
        SceneManager.LoadScene(1);
    }

    public void BACK() {
        SceneManager.LoadScene(0);
        GameManager.instance.lives = 3;
    }

    public void EXIT() {
        Application.Quit();
    }
}