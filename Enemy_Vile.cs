using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Vile : MonoBehaviour {
    private Animator mAnim;
    public int BossHealth;
    public float ShootSpeed;
    public float FireRate;
    public float DeathTime;
    public float BombDestroy;
    bool isFired = false;
    public Animator Death;
    public Transform BombLauncher;
    public GameObject enemy_bomb;
    AudioSource Audio;
    public AudioClip ShotSFX;
    public AudioClip HitSFX;
    public AudioClip DeathSFX;
    public GameObject CollidedObject = null;

    void Start() {
        mAnim = gameObject.GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (Death.GetBool("Dying") == false)
        {
            if (collision.gameObject.tag == "Player" && isFired != true)
            {
                GM_SoundManager.instance.playSingleSound(ShotSFX);
                GameObject Bomb = Instantiate(enemy_bomb, BombLauncher.position, Quaternion.identity);
                Rigidbody2D rb = Bomb.GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(-ShootSpeed, 0.0f));
                Destroy(Bomb, BombDestroy);
                isFired = true;
                StartCoroutine(BulletTimer());
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lemon")
        {
            GM_SoundManager.instance.playSingleSound(HitSFX);
            mAnim.SetTrigger("Hit");
            Destroy(collision.gameObject);
            BossHealth -= 1;
        }

        if (BossHealth <= 0)
        {
            GM_SoundManager.instance.playSingleSound(DeathSFX);
            mAnim.SetTrigger("Dead");
            mAnim.SetBool("Dying", true);
            StartCoroutine(DeathAnimation());
        }
    }

    IEnumerator BulletTimer() {
        yield return new WaitForSeconds(FireRate);
        isFired = false;
        StopAllCoroutines();
    }

    IEnumerator DeathAnimation() {
        yield return new WaitForSeconds(DeathTime);
        SceneManager.LoadScene(5);
        StopAllCoroutines();
    }
}
