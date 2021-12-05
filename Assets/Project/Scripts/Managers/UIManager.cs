using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public GameObject winMenu;
    public GameObject loseMenu;
    public GameObject gamePlay;
    public Text TutorialText;
    public Text remainingMoveText;


    bool isGameStarted;
    int movesRemaining =5;

    private void OnEnable()
    {
        EventManager.sortingIsTrue += WinMenu;
        EventManager.onFail += LoseMenu;
        EventManager.gameIsStarted += GameStarted;
        EventManager.firstObstaclePassed += OnFirstObstaclePassed;
        EventManager.decreaseMoveCount += DecreaseMoveCount;
    }

    private void OnDisable()
    {
        EventManager.sortingIsTrue -= WinMenu;
        EventManager.onFail -= LoseMenu;
        EventManager.gameIsStarted -= GameStarted;
        EventManager.firstObstaclePassed -= OnFirstObstaclePassed;
        EventManager.decreaseMoveCount -= DecreaseMoveCount;
    }

    private void Awake()
    {
        gamePlay.SetActive(true);
        loseMenu.SetActive(false);
        winMenu.SetActive(false);
        remainingMoveText.text = movesRemaining.ToString();
    }

    void WinMenu()
    {
        TutorialText.transform.parent.gameObject.SetActive(false);
        StartCoroutine("DisplayWinMenu");
        TutorialText.gameObject.SetActive(false);
    }

    IEnumerator DisplayWinMenu()
    {
        yield return new WaitForSeconds(5);
        winMenu.SetActive(true);
        gamePlay.SetActive(false);
    }

    void LoseMenu()
    {
        TutorialText.transform.parent.gameObject.SetActive(false);
        StartCoroutine("DisplayLoseMenu");
    }

    IEnumerator DisplayLoseMenu()
    {
        yield return new WaitForSeconds(3);
        loseMenu.SetActive(true);
        gamePlay.SetActive(false);
    }

    void GameStarted()
    {
        isGameStarted = true;
        ChangeTutorialText("WATCH NOW");
    }

    void OnFirstObstaclePassed()
    {
        ChangeTutorialText ("YOUR TURN !");
        StartCoroutine(ChangeWarning());
    }

    IEnumerator ChangeWarning()
    {
        yield return new WaitForSeconds(2f);
        ChangeTutorialText( "SORT THE PICTURES");
        EventManager.sortingRoutineStarted?.Invoke();
    }

    void ChangeTutorialText(string tutorialText)
    {
        TutorialText.text = tutorialText;
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    private void DecreaseMoveCount()
    {
        movesRemaining--;
        UpdateRemainingMoves();
    }

    void UpdateRemainingMoves()
    {
        remainingMoveText.text = movesRemaining.ToString();
        if (movesRemaining==0)
        {
            EventManager.onFail?.Invoke();
        }        
    }
}
