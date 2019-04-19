using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mech : MonoBehaviour {

    private Animator mAnim;
    public float ShootSpeed;
    public float FireRate;
    public float MissileDestroy;
    bool isFired = false;
    AudioSource Audio;
    public AudioClip ShotSFX;
    public Transform MissileLauncher;
    public GameObject enemy_missile;
    public GameObject CollidedObject = null;

    void Start() {
        mAnim = gameObject.GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collision) {
            if (collision.gameObject.tag == "Player" && isFired != true) {
            GM_SoundManager.instance.playSingleSound(ShotSFX);
            mAnim.SetTrigger("In Range");
            GameObject Missile = Instantiate(enemy_missile, MissileLauncher.position, Quaternion.identity);
                Rigidbody2D rb = Missile.GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(-ShootSpeed, 0.0f));
                Destroy(Missile, MissileDestroy);
                isFired = true;
                StartCoroutine(BulletTimer());
            }
        }
    
    IEnumerator BulletTimer() {
        yield return new WaitForSeconds(FireRate);
        isFired = false;
        StopAllCoroutines();
    }
}
