using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControl1 : MonoBehaviour
{    
    Animator anim;


    private void OnEnable()
    {
        EventManager.onFail += SortingIsFalse;
        EventManager.enemyIsClose += EnemyIsClose;
        EventManager.winMenu += Win;
    }

    private void OnDisable()
    {
        EventManager.onFail -= SortingIsFalse;
        EventManager.enemyIsClose -= EnemyIsClose;
        EventManager.winMenu -= Win;
    }

    private void Awake()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    void Win()
    {
        anim.SetTrigger("Win");
    }

    //if sorting is false, we stop player; 
    void SortingIsFalse()
    {
        anim.SetTrigger("Lose");
    }

    // if enemy is close we play kick animation after 2 seconds
    void EnemyIsClose()
    {
        Invoke("PlayKickAnimation", 2);
    }

    // if enemy is close we play kick animation after 2 seconds,  we call this from "EnemyIsClose"
    void PlayKickAnimation()
    {
        anim.SetTrigger("Kick");
    }


}
