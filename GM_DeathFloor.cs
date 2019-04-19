using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_DeathFloor : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            GameManager.instance.Health = 0;
        }
    }
}