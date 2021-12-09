using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorManager : MonoBehaviour
{
    bool cursorCanShow;

    private void OnEnable()
    {
        EventManager.firstObstaclePassed += FirstObstaclePassed;
        EventManager.onFail += OnFail;
        EventManager.sortingIsTrue += SortingIsTrue;
    }

    private void OnDisable()
    {
        EventManager.firstObstaclePassed -= FirstObstaclePassed;
        EventManager.onFail -= OnFail;
        EventManager.sortingIsTrue -= SortingIsTrue;
    }

    private void Update()
    {

        if (cursorCanShow)
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
            }

            else if (Input.GetMouseButtonUp(0))
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
            }

            transform.position = Input.mousePosition;
        }

    }

    void FirstObstaclePassed()
    {
        cursorCanShow = true;
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);

    }

    void OnFail()
    {
        cursorCanShow = false;
    }
    
    void SortingIsTrue()
    {
        cursorCanShow = false;
    }

}
