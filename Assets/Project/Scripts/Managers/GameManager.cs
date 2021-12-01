using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    GameObject slotPanel;
    bool isLevelFinished;
    bool firstClick;

    private void OnEnable()
    {
        EventManager.sortingIsTrue += OnWin;
        EventManager.onFail += OnFail;
        EventManager.sortingTimerStarted += ActivateSlotPanel;
    }

    private void OnDisable()
    {
        EventManager.sortingIsTrue -= OnWin;
        EventManager.onFail -= OnFail;
        EventManager.sortingTimerStarted -= ActivateSlotPanel;
    }

    private void Awake()
    {
        slotPanel = GameObject.FindGameObjectWithTag("Slot");
        slotPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isLevelFinished && !firstClick )
        {
            firstClick = true;
            EventManager.gameIsStarted?.Invoke();
        }
        
    }

    void ActivateSlotPanel()
    {
        slotPanel.SetActive(true);
    }

    private void OnFail()
    {
        isLevelFinished = true;
    }

    private void OnWin()
    {
        isLevelFinished = true;
    }


}
