using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMX_PickUpLifeUp : MonoBehaviour {
    public GameObject CollidedObject = null;
    private Animator mAnim;
    AudioSource Audio;
    public AudioClip LifeSFX;

    void Start() {
        mAnim = gameObject.GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Collectible_Life") {
            mAnim.SetTrigger("PickUp");
            Destroy(collision.gameObject);
            GameManager.instance.lives += 1;
            GM_SoundManager.instance.playSingleSound(LifeSFX);
        }
    }
}