using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAnimationEvent1 : MonoBehaviour
{
    public void OnAnimationEnds()
    {
        transform.parent.transform.DOMoveZ(transform.parent.transform.position.z + 2, 3.2f);
    }
}
