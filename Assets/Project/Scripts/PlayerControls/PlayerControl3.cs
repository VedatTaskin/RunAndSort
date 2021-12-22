using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControl3 : AbstractPlayerControl
{   

    public override void OnEnable()
    {
        base.OnEnable();
        EventManager.enemyIsClose += EnemyIsClose;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        EventManager.enemyIsClose -= EnemyIsClose;
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
