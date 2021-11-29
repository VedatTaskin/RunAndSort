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
    }

    private void OnDisable()
    {
        EventManager.sortingIsTrue -= WinMenu;
    }

    private void Awake()
    {
        gamePlay.SetActive(true);
        loseMenu.SetActive(false);
        winMenu.SetActive(false);
    }

    void WinMenu()
    {
        winMenu.SetActive(true);
        gamePlay.SetActive(false);
    }

    void LoseMenu()
    {
        loseMenu.SetActive(true);
        gamePlay.SetActive(false);
    }

}
