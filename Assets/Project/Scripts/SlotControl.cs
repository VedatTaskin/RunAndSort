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
    public GameObject confetti;
    bool imagesAreSorted;
    bool sortAgain;
    [SerializeField] private int timer=10;

    private void OnEnable()
    {
        EventManager.onFail += ImagesNotSorted;
    }

    private void OnDisable()
    {
        EventManager.onFail += ImagesNotSorted;
    }

    private void Awake()
    {
        TakeImageList();
        ShuffleChildImages();
        confetti.SetActive(false);
    }

    private void ShuffleChildImages()
    {
        for (int i = 0; i <  ImagesGO.Count; i++)
        {
            int randomIndex =  UnityEngine.Random.Range(i, ImagesGO.Count);
            transform.GetChild(i).SetSiblingIndex(randomIndex);
        }

        // we check if the begining sorting is mixed or not
        CheckImagesOrder();
        if (sortAgain)
        {
            ShuffleChildImages();
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

                if (int.Parse(transform.GetChild(i).name) ==index)
                {
                    correctImagesCount++;
                    index++;
                    if (correctImagesCount == ImagesGO.Count )
                    {
                        ImagesSorted();
                        sortAgain = true; // we will use it if the begining sorting not mix our images;
                    }
                }

            } 

        }
        
    }

    void ImagesSorted()
    {
        // oyun bitti
        imagesAreSorted = true;
        EventManager.sortingIsTrue?.Invoke();
        GetComponent<Image>().color = Color.green; // Change slot color to green
        confetti.SetActive(true); // confetties under main camera activates
        resultText.gameObject.SetActive(true);
        resultText.text = "EXCELLENT";
        StartCoroutine(CloseSlotPanel());
    }

    void ImagesNotSorted()
    {
        resultText.gameObject.SetActive(true);
        resultText.text = "FAIL";
        this.gameObject.SetActive(false);
    }

    IEnumerator CloseSlotPanel()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    // Not used yet
    public void OnDrop(PointerEventData eventData)
    {
        //print("On Drop");      
    }

}
