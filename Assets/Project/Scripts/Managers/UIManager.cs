using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UIManager : MonoBehaviour
{
    [Header("GamePlay")]
    public GameObject gamePlay;
    public GameObject scorePanel;
    public GameObject slotPanel;
    public Text remainingMoveText;
    public Text tutorialText; 
    public static Text TutorialText; // we made static only with this method ý can solve the problem that ý don't understand :(

    [Header("WinMenu")]
    public GameObject winMenu;
    public Text winScoreText;
    public GameObject scorePanelWin;


    [Header("LoseMenu")]    
    public Text loseScoreText;
    public GameObject loseMenu;
    public GameObject scorePanelLose;


    bool isSortingTrue;
    int movesRemaining =5;
    int score = 0;

    private void OnEnable()
    {
        EventManager.winMenu += WinMenu;
        EventManager.onFail += LoseMenu;
        EventManager.gameIsStarted += GameStarted;
        EventManager.firstObstaclePassed += OnFirstObstaclePassed;
        EventManager.decreaseMoveCount += DecreaseMoveCount;
        EventManager.sortingIsTrue += SortingIsTrue;
    }

    private void OnDisable()
    {
        EventManager.winMenu -= WinMenu;
        EventManager.onFail -= LoseMenu;
        EventManager.gameIsStarted -= GameStarted;
        EventManager.firstObstaclePassed -= OnFirstObstaclePassed;
        EventManager.decreaseMoveCount -= DecreaseMoveCount;
        EventManager.sortingIsTrue += SortingIsTrue;
    }

    
    private void Start()
    {
        TutorialText = tutorialText; // we made static only with this method ý can solve the problem that ý don't understand :(
        gamePlay.SetActive(true);
        loseMenu.SetActive(false);
        winMenu.SetActive(false);
        remainingMoveText.text = movesRemaining.ToString();

        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
        }
        scorePanel.transform.GetChild(1).transform.GetComponent<Text>().text = score.ToString();
    }

    void WinMenu()
    {
        StartCoroutine("ScoreChangeAnimation");      
    }

    IEnumerator DisplayWinMenu()
    {        
        yield return new WaitForSeconds(1);
        slotPanel.SetActive(false);
        winMenu.SetActive(true);
        winScoreText.text = PlayerPrefs.GetInt("Score").ToString();
    }

    void LoseMenu()
    {
        StartCoroutine("DisplayLoseMenu");
    }

    IEnumerator DisplayLoseMenu()
    {
        yield return new WaitForSeconds(3);
        slotPanel.SetActive(false);
        loseMenu.SetActive(true);
        gamePlay.SetActive(false);
        loseScoreText.text = PlayerPrefs.GetInt("Score").ToString();
    }

    void GameStarted()
    {        
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
                slotPanel.SetActive(false);

            }
        }        
    }

    void SortingIsTrue()
    {
        isSortingTrue = true;
        TutorialText.text = "EXCELLENT";
    }

    IEnumerator ScoreChangeAnimation()
    {
        yield return new WaitForSeconds(1f);
        int loopCount = movesRemaining;
        for (int i = 0; i < loopCount; i++)
        {
            remainingMoveText.transform.DOShakeScale(0.5f, 1, 10, 90);
            scorePanel.transform.GetChild(0).transform.DOShakeScale(0.5f, 1, 10, 90);
            scorePanel.transform.GetChild(1).transform.GetComponent<Text>().gameObject.transform.DOShakeScale(0.5f, 1, 10, 90);

            movesRemaining--;
            score += 100;
            remainingMoveText.text = movesRemaining.ToString();
            scorePanel.transform.GetChild(1).transform.GetComponent<Text>().text = score.ToString();
            yield return new WaitForSeconds(0.6f);
        }

        remainingMoveText.transform.parent.gameObject.SetActive(false);
        slotPanel.SetActive(false);
        PlayerPrefs.SetInt("Score", score);
        StartCoroutine("DisplayWinMenu");
    }
}
