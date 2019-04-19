using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMX_LifeBar : MonoBehaviour {
    private Animator mAnim;

    void Start () {
        mAnim = gameObject.GetComponent<Animator>();
    }
	
	void Update () {

        if (GameManager.instance.Health == 3) {
            mAnim.SetTrigger("Healed");
            mAnim.SetTrigger("FullHeal");
        }

        if (GameManager.instance.Health == 2) {
            mAnim.SetTrigger("Damaged");
            mAnim.SetTrigger("Healed2");
        }

        if (GameManager.instance.Health == 1) {
            mAnim.SetTrigger("Damaged2");
        }

        if (GameManager.instance.Health == 0) {
            mAnim.SetTrigger("Death");
        }
    }
}