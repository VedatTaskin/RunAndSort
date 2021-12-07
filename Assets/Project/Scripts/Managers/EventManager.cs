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
    public static Action enemyIsClose;
    public static Action decreaseMoveCount;
    public static Action enemyCanDie; 
    public static Action winMenu;  // call winmenu
}
