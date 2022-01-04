using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControl1 : AbstractPlayerControl
{   
    int jumpCounter=0;

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }


    protected override void GameStarted()
    {
        base.GameStarted();
        StartCoroutine(FirstJump());
    }

    IEnumerator FirstJump()
    {
        PlayBoxJumpAnimation();
        yield return new WaitForSeconds(4f);
        EventManager.firstObstaclePassed?.Invoke();
    }

    protected override void SortingIsTrue()
    {
        base.SortingIsTrue();
        PlayBoxJumpAnimation();
    }

    void PlayBoxJumpAnimation()
    {
        jumpCounter++;
        anim.SetTrigger("BoxJump");

        if (jumpCounter==2)
        {
            StartCoroutine("WinScene");
        }
    }

    IEnumerator WinScene()
    {
        yield return new WaitForSeconds(4f);
        EventManager.winMenu?.Invoke();
    }

}
