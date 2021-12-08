using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AnimationEventCalller : MonoBehaviour
{

    private CinemachineImpulseSource source;

    private void Awake()
    {
        source = GetComponent<CinemachineImpulseSource>();
        
    }

    void enemyCanDie()
    {
        EventManager.enemyCanDie?.Invoke();
        source.GenerateImpulse();
    }
}
