using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static Action sortingIsTrue;
    public static Action onFail;
    public static Action gameIsStarted;
    public static Action firstObstaclePassed;
    public static Action sortingRoutineStarted;
    public static Action enemyIsClose;
    public static Action decreaseMoveCount;
}
