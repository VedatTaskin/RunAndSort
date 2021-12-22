using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControl1 : AbstractPlayerControl
{
    int cartWheelCount = 0;

    protected override void GameStarted()
    {
        base.GameStarted();
        anim.SetTrigger("CartWheel");
    }

}
