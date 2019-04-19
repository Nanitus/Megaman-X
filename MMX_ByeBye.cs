using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMX_ByeBye : MonoBehaviour {
    private Animator mAnim;
    AudioSource Audio;
    public AudioClip DeathSFX;

    void Start() {
        mAnim = gameObject.GetComponent<Animator>();
    }

    void Update() {
        if (GameManager.instance.Health == 0) {
            mAnim.SetBool("Dead", true);
            mAnim.SetTrigger("Bye-Bye");
            GM_SoundManager.instance.playSingleSound(DeathSFX);
            GameManager.instance.lives -= 1;
            SceneManager.LoadScene(3);
        }

        if (GameManager.instance.lives == 0) {
            SceneManager.LoadScene(4);
        }
    }
}