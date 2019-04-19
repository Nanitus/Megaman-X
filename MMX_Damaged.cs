using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMX_Damaged : MonoBehaviour {
    public GameObject CollidedObject = null;
    private Animator mAnim;
    AudioSource Audio;
    public AudioClip HitSFX;

    void Start() {
        mAnim = gameObject.GetComponent<Animator>();
        if (GameManager.instance.Health >= 3) {
            GameManager.instance.Health = 3;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            Debug.Log("OUCHIE");
            GameManager.instance.Health -= 1;
            mAnim.SetTrigger("Hurt");
            GM_SoundManager.instance.playSingleSound(HitSFX);
        }

        if (collision.gameObject.tag == "Enemy_Wheel") {
            Debug.Log("OUCHIE");
            GameManager.instance.Health -= 1;
            mAnim.SetTrigger("Hurt");
            GM_SoundManager.instance.playSingleSound(HitSFX);
        }

        if (collision.gameObject.tag == "Missile") {
            Debug.Log("OUCHIE");
            GameManager.instance.Health -= 1;
            mAnim.SetTrigger("Hurt");
            Destroy(collision.gameObject);
            GM_SoundManager.instance.playSingleSound(HitSFX);
        }
    }
}