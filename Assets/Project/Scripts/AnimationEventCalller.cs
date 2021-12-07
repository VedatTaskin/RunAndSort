using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventCalller : MonoBehaviour
{
    void enemyCanDie()
    {
        EventManager.enemyCanDie?.Invoke();
    }
}
