using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventCalller : MonoBehaviour
{

    Animator anim;

    private void Awake()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy != null)
        {
            anim = enemy.GetComponent<Animator>();
        }
        
    }


    void Death()
    {
        anim.SetTrigger("Death");
    }
}
