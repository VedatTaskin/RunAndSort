using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPlayerControl : MonoBehaviour
{

    protected Animator anim;
    protected bool isSortingTrue;
    protected bool isGameStarted;

    public virtual void OnEnable()
    {
        EventManager.gameIsStarted += GameStarted;
        EventManager.onFail += SortingIsFalse;
        EventManager.sortingIsTrue += SortingIsTrue;
        EventManager.winMenu += Win;
    }

    public virtual void OnDisable()
    {
        EventManager.onFail -= SortingIsFalse;
        EventManager.sortingIsTrue -= SortingIsTrue;
        EventManager.winMenu -= Win;
        EventManager.gameIsStarted -= GameStarted;
    }

    protected virtual void Awake()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    protected virtual void SortingIsFalse()
    {
        anim.SetTrigger("Lose");
    }

    /// <summary>
    /// To play win animation
    /// </summary>
    protected virtual void Win()
    {
        anim.SetTrigger("Win");
    }

    protected virtual void SortingIsTrue()
    {
        isSortingTrue = true;
    }

    protected virtual void GameStarted()
    {
        isGameStarted = true;
    }
}
