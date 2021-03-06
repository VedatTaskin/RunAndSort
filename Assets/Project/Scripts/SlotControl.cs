using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotControl : MonoBehaviour
{
    List<GameObject> ImagesGO = new List<GameObject>();


    private void Start()
    {
        TakeImageList();
        
        ShuffleChildImages();        
    }

    private void ShuffleChildImages()
    {
        for (int i = 0; i <  ImagesGO.Count; i++)
        {
            int randomIndex =  UnityEngine.Random.Range(i, ImagesGO.Count);
            transform.GetChild(i).SetSiblingIndex(randomIndex);
        }
        FirstCheck(); // we will ensure about the images are not sorted

    }

    void FirstCheck()
    {
        int index = 1;
        int correctImagesCount = 0;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeInHierarchy)
            {

                if (int.Parse(transform.GetChild(i).name) == index)
                {
                    correctImagesCount++;
                    index++;
                    if (correctImagesCount == ImagesGO.Count)
                    {
                        ShuffleChildImages();
                    }
                }

            }

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
                    }
                }

            } 

        }
        
    }

    void ImagesSorted()
    {
        EventManager.sortingIsTrue?.Invoke();
        GetComponent<Image>().color = new Color32(0, 255, 225, 100); // Change slot color to green
    }

    
        
}
