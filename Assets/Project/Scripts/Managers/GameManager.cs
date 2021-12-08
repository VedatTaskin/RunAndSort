using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject slotPanel;
    [SerializeField] private GameObject moveCounter;
    bool isLevelFinished;
    bool firstClick;
    GameObject confetti;

    private void OnEnable()
    {
        EventManager.sortingIsTrue += OnSortingTrue;
        EventManager.onFail += OnFail;
        EventManager.firstObstaclePassed += ActivatePanels;
    }

    private void OnDisable()
    {
        EventManager.sortingIsTrue -= OnSortingTrue;
        EventManager.onFail -= OnFail;
        EventManager.firstObstaclePassed -= ActivatePanels;
    }

    private void Awake()
    {
        slotPanel.SetActive(false);
        moveCounter.SetActive(false);
        confetti = GameObject.FindGameObjectWithTag("Confetti");
        confetti.SetActive(false);
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

    private void OnSortingTrue()
    {
        isLevelFinished = true;
        confetti.SetActive(true);
    }


}
