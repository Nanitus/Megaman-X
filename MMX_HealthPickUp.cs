using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMX_HealthPickUp : MonoBehaviour {

    public GameObject CollidedObject = null;
    AudioSource Audio;
    public AudioClip HealthSFX;

    void Start() {
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Health") {
            Destroy(collision.gameObject);
            Debug.Log("YAY");
            GameManager.instance.Health += 1;
            GM_SoundManager.instance.playSingleSound(HealthSFX);
        }
    }
}