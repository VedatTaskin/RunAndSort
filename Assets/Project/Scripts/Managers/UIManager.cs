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


    bool isGameStarted;

    private void OnEnable()
    {
        EventManager.sortingIsTrue += WinMenu;
        EventManager.onFail += LoseMenu;
        EventManager.gameIsStarted += GameStarted;
        EventManager.firstObstaclePassed += OnFirstObstaclePassed;
    }

    private void OnDisable()
    {
        EventManager.sortingIsTrue -= WinMenu;
        EventManager.onFail -= LoseMenu;
        EventManager.gameIsStarted -= GameStarted;
        EventManager.firstObstaclePassed -= OnFirstObstaclePassed;
    }

    private void Awake()
    {
        gamePlay.SetActive(true);
        loseMenu.SetActive(false);
        winMenu.SetActive(false);
    }

    void WinMenu()
    {
        TutorialText.gameObject.SetActive(false);
        StartCoroutine("DisplayWinMenu");
    }

    IEnumerator DisplayWinMenu()
    {
        yield return new WaitForSeconds(3);
        winMenu.SetActive(true);
        gamePlay.SetActive(false);
    }

    void LoseMenu()
    {
        TutorialText.gameObject.SetActive(false);
        StartCoroutine("DisplayLoseMenu");
    }

    IEnumerator DisplayLoseMenu()
    {
        yield return new WaitForSeconds(2);
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
        EventManager.sortingTimerStarted?.Invoke();
    }

    void ChangeTutorialText(string tutorialText)
    {
        TutorialText.text = tutorialText;
    }
}
