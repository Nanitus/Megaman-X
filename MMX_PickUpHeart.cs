using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMX_PickUpHeart : MonoBehaviour
{
    public GameObject CollidedObject = null;
    private Animator mAnim;
    AudioSource Audio;
    public AudioClip HeartSFX;

    void Start()
    {
        mAnim = gameObject.GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Collectible_Heart")
        {
            mAnim.SetTrigger("PickUpHeart");
            Destroy(collision.gameObject);
            GameManager.instance.Health += 3;
            GM_SoundManager.instance.playSingleSound(HeartSFX);
        }
    }
}