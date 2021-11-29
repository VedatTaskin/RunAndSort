using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject winMenu;
    public GameObject loseMenu;
    public GameObject gamePlay;

    private void OnEnable()
    {
        EventManager.sortingIsTrue += WinMenu;
        EventManager.onFail += LoseMenu;
    }

    private void OnDisable()
    {
        EventManager.sortingIsTrue -= WinMenu;
        EventManager.onFail -= LoseMenu;
    }

    private void Awake()
    {
        gamePlay.SetActive(true);
        loseMenu.SetActive(false);
        winMenu.SetActive(false);
    }

    void WinMenu()
    {
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
        StartCoroutine("DisplayLoseMenu");
    }

    IEnumerator DisplayLoseMenu()
    {
        yield return new WaitForSeconds(2);
        loseMenu.SetActive(true);
        gamePlay.SetActive(false);
    }

}
