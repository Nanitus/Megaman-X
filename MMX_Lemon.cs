using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMX_Lemon : MonoBehaviour {

    public ParticleSystem Explosion;
    public float lifeTime;

    void Start() {

        if (lifeTime <= 0) {
            lifeTime = 2.0f;
        }

        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy_Wheel")
        {
            Destroy(gameObject);
        }

        if (Explosion)
            Instantiate(Explosion, transform.position, transform.rotation);
    }
}