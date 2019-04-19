using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MMX_ShootingAnimation : MonoBehaviour {
    private Animator mAnim;
    AudioSource Audio;
    public AudioClip ShotSFX;

    void Start () {
        mAnim = gameObject.GetComponent<Animator>();
    }
	
	void Update () {
        if (Input.GetKey(KeyCode.K)) {
            mAnim.SetTrigger("Shooting");
            GM_SoundManager.instance.playSingleSound(ShotSFX);
        }
    }
}