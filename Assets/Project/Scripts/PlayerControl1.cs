using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControl1 : MonoBehaviour
{    
    Animator anim;
    bool imagesAreSorted;
    GameObject enemy;
    Ease jumpEaseType = Ease.OutQuad;


    private void OnEnable()
    {
        EventManager.sortingIsTrue += SortingIsTrue;
        EventManager.onFail += SortingIsFalse;
        EventManager.enemyIsClose += EnemyIsClose;
    }

    private void OnDisable()
    {
        EventManager.sortingIsTrue -= SortingIsTrue;
        EventManager.onFail -= SortingIsFalse;
        EventManager.enemyIsClose -= EnemyIsClose;
    }

    private void Awake()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    //if sorting is true, we bring obtsacle in front of player; and sets bool "imagesAreSorted" true
    void SortingIsTrue()
    {
        imagesAreSorted = true;

        // Play Kick animation again

    }

    IEnumerator WinScene()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetTrigger("Win");
    }

    //if sorting is false, we stop player; 
    void SortingIsFalse()
    {
        anim.SetTrigger("Lose");
    }

    void EnemyIsClose()
    {
        Invoke("PlayKickAnimation", 2);
    }

    void PlayKickAnimation()
    {
        anim.SetTrigger("Kick");
    }
}
