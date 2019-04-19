using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMX_Movement : MonoBehaviour {
    public float speed;
    public float jump;
    bool facingright = true;
    public Rigidbody2D rb;
    public Animator Death;
    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask isGroundLayer;
    private Animator mAnim;
    AudioSource Audio;
    public AudioClip JumpSFX;


    void Start() {
        mAnim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Death.GetBool("Dead") == false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                mAnim.SetTrigger("Moving");

                if (!facingright)
                {
                    float xscale = transform.localScale.x;
                    float yscale = transform.localScale.y;
                    transform.localScale = new Vector3(xscale *= -1, yscale, transform.localScale.z);
                    facingright = true;
                }


                Vector3 Dir = new Vector3(speed, 0, 0);
                transform.position += Dir * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A))
            {
                mAnim.SetTrigger("Moving");

                if (facingright)
                {
                    float xscale = transform.localScale.x;
                    float yscale = transform.localScale.y;
                    float zscale = transform.localScale.z;
                    transform.localScale = new Vector3(xscale *= -1, yscale, zscale);
                    facingright = false;
                }

                Vector3 Dir = new Vector3(-speed, 0, 0);
                transform.position += Dir * Time.deltaTime;
            }

            if (groundCheck)
            {
                isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);
            }

            if (isGrounded)
            {
                if ((Input.GetKey(KeyCode.Space)))
                {
                    rb.AddForce(new Vector2(0, jump * Time.deltaTime));
                    GM_SoundManager.instance.playSingleSound(JumpSFX);
                    mAnim.SetTrigger("Jump");
                }
            }

        }
    }
}
