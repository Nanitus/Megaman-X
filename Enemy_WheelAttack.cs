using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_WheelAttack : MonoBehaviour
{
    public GameObject CollidedObject = null;
    public float speed;
    private Animator mAnim;
    public Animator Done;

    public void Start()
    {
        mAnim = gameObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Done.GetBool("Done") == false)
        {
            if (collision.gameObject.tag == "Player")
            {
                mAnim.SetTrigger("Impact");
                mAnim.SetBool("Done", true);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (Done.GetBool("Done") == false)
        {
            if (collision.gameObject.tag == "Player")
            {
                Vector3 Dir = new Vector3(-speed, 0, 0);
                transform.position += Dir * Time.deltaTime;
            }
        }
    }
}