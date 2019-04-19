using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]

public enum GameState { NullState, MainMenu, Game }

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public int Health = 3;
    public int lives = 3;

    //GameState _gm = GameState.NullState;

    void Awake() {

        if (instance == null) {
            instance = this;
        }

        else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        
        //gm = GameState.MainMenu;
    }


    private void Update() {
        if (Health >= 4) {
            Health = 3;
        }

    }

    /*public void StartGame()
    {
        gm = GameState.Game;
        SceneManager.LoadScene("Stage1");
    }

    public GameState gm
    {
        get { return _gm; }
        set
        {
            _gm = value;
            Debug.Log("Current State: " + _gm);
        }
    }

    public int lives
    {
        get { return _lives; }
        set
        {
            _lives = value;
            if (gm == GameState.Game)
            {
                if (_lives > 0)
                    SceneManager.LoadScene("GameOver");
                else
                    Debug.Log("Player Dead");
            }
        }
    }*/
}