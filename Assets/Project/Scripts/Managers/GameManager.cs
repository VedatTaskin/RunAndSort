using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject slotPanel;
    public GameObject moveCounter;
    bool isLevelFinished;
    bool firstClick;

    private void OnEnable()
    {
        EventManager.sortingIsTrue += OnWin;
        EventManager.onFail += OnFail;
        EventManager.sortingRoutineStarted += ActivatePanels;
    }

    private void OnDisable()
    {
        EventManager.sortingIsTrue -= OnWin;
        EventManager.onFail -= OnFail;
        EventManager.sortingRoutineStarted -= ActivatePanels;
    }

    private void Awake()
    {
        slotPanel.SetActive(false);
        moveCounter.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isLevelFinished && !firstClick )
        {
            firstClick = true;
            EventManager.gameIsStarted?.Invoke();            
        }
        
    }

    void ActivatePanels()
    {
        slotPanel.SetActive(true);
        moveCounter.SetActive(true);
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
