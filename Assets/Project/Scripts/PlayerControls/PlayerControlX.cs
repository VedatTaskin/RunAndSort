using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControlX : AbstractPlayerControl
{

    protected override void GameStarted()
    {
        base.GameStarted();
        anim.SetTrigger("CartWheel");
        Invoke("OnFirstCartWheelFinished", 2);
    }

    void OnFirstCartWheelFinished()
    {
        EventManager.firstObstaclePassed?.Invoke();

    }
    protected override void SortingIsTrue()
    {
        base.SortingIsTrue();
        anim.SetTrigger("CartWheel");
        
        StartCoroutine("WinScene");  
    }

    IEnumerator WinScene()
    {
        Debug.Log("we won");
        yield return new WaitForSeconds(4f);
        // we give sometime to begin win animation and scene        
        anim.SetTrigger("Win");
        EventManager.winMenu?.Invoke();
    }


}
