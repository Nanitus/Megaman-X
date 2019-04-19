using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health: MonoBehaviour {
    public int health;
    public GameObject CollidedObject = null;
    AudioSource Audio;
    public AudioClip EnemyHitSFX;
    public AudioClip EnemyDeathSFX;

    private void Start() {
    }

    private void Update() {
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Lemon")
        {
            Destroy(collision.gameObject);
            health -= 1;
            GM_SoundManager.instance.playSingleSound(EnemyHitSFX);
        }

        if (health <= 0)  {
            Destroy(gameObject);
            GM_SoundManager.instance.playSingleSound(EnemyDeathSFX);
        }
    }
}
