using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMX_Shot : MonoBehaviour {
    public GameObject Lemon;
    public Transform LemonBuster;
    bool isFired = false;

    void Update() {
        if (Input.GetKey(KeyCode.K) && !isFired) {
            GameObject lemon = Instantiate(Lemon, LemonBuster.position, Quaternion.identity);
            Rigidbody2D rb = lemon.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(100.0f * transform.localScale.x, 0.0f));
            Destroy(lemon, 2.5f);
            isFired = true;
            StartCoroutine(BulletTimer());
        }
    }

    IEnumerator BulletTimer() {
        yield return new WaitForSeconds(0.5f);
            isFired = false;
            StopAllCoroutines();
    }
}