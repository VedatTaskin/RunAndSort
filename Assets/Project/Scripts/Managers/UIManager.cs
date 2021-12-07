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

    bool isSortingTrue;
    bool isGameStarted;
    int movesRemaining =5;

    private void OnEnable()
    {
        EventManager.winMenu += WinMenu;
        EventManager.onFail += LoseMenu;
        EventManager.gameIsStarted += GameStarted;
        EventManager.firstObstaclePassed += OnFirstObstaclePassed;
        EventManager.decreaseMoveCount += DecreaseMoveCount;
        EventManager.sortingIsTrue += CloseTutorialText;
        EventManager.onFail += CloseTutorialText;
    }

    private void OnDisable()
    {
        EventManager.winMenu -= WinMenu;
        EventManager.onFail -= LoseMenu;
        EventManager.gameIsStarted -= GameStarted;
        EventManager.firstObstaclePassed -= OnFirstObstaclePassed;
        EventManager.decreaseMoveCount -= DecreaseMoveCount;
        EventManager.sortingIsTrue -= CloseTutorialText;
        EventManager.onFail -= CloseTutorialText;
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
        StartCoroutine("DisplayWinMenu");
    }

    IEnumerator DisplayWinMenu()
    {
        yield return new WaitForSeconds(2);
        winMenu.SetActive(true);
        gamePlay.SetActive(false);
    }

    void LoseMenu()
    {
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
        TutorialText.text = "WATCH NOW";
    }

    void OnFirstObstaclePassed()
    {
        TutorialText.text = "YOUR TURN!";
        StartCoroutine(BeginSortingRoutine());
    }

    IEnumerator BeginSortingRoutine()
    {        
        yield return new WaitForSeconds(2f);
        TutorialText.text = "SORT THE PICTURES";
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
        if (movesRemaining <= 0)
        {
            if (!isSortingTrue)
            {
                EventManager.onFail?.Invoke();
            }
        }        
    }

    void CloseTutorialText()
    {
        isSortingTrue = true;
        TutorialText.transform.parent.gameObject.SetActive(false);
    }
}
