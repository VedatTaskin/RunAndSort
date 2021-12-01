using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotControl : MonoBehaviour, IDropHandler
{
    List<GameObject> ImagesGO = new List<GameObject>();
    public Text resultText;
    public Text timerText;
    bool IsMissionAccomplished;
    [SerializeField] private int timer=10;



    private void Awake()
    {
        TakeImageList();
        ShuffleChildImages();
        InvokeRepeating("Timer", 1, 1);
    }

    private void ShuffleChildImages()
    {
        for (int i = 0; i <  ImagesGO.Count; i++)
        {
            int randomIndex =  UnityEngine.Random.Range(i, ImagesGO.Count);
            transform.GetChild(i).SetSiblingIndex(randomIndex);
        }
    }

    private void TakeImageList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeInHierarchy)
            {
                ImagesGO.Add(transform.GetChild(i).gameObject);
            }
        }
    }

    public void CheckImagesOrder()
    {
        int index = 1;
        int correctImagesCount = 0;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeInHierarchy)
            {
                // print(int.Parse(transform.GetChild(i).name));

                if (int.Parse(transform.GetChild(i).name) ==index)
                {
                    correctImagesCount++;
                    index++;
                    if (correctImagesCount == ImagesGO.Count )
                    {
                        ImagesSorted();
                    }
                }

            } 

        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        //print("On Drop");      
    }

    void ImagesSorted()
    {
        // oyun bitti
        IsMissionAccomplished = true;
        EventManager.sortingIsTrue?.Invoke();
        GetComponent<Image>().color = Color.green; // Change slot color to green
        resultText.gameObject.SetActive(true);
        resultText.text = "EXCELLENT";
        CancelInvoke("Timer");
        timerText.gameObject.SetActive(false);
        StartCoroutine(CloseSlotPanel());
    }

    void Timer()
    {
        timer--;
        timerText.text = timer.ToString();
        if (timer <=0 && !IsMissionAccomplished)
        {
            ImagesNotSorted();
        }
    }

    void ImagesNotSorted()
    {
        timerText.enabled = false;
        resultText.gameObject.SetActive(true);
        resultText.text = "FAIL";
        EventManager.onFail?.Invoke();
        this.gameObject.SetActive(false);
    }

    IEnumerator CloseSlotPanel()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
