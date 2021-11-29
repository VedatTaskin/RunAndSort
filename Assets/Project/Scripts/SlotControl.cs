using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotControl : MonoBehaviour, IDropHandler
{
    List<GameObject> ImagesGO = new List<GameObject>();

    private void Awake()
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
                        // oyun bitti
                        print("hepsi sýralandý");
                        EventManager.sortingIsTrue?.Invoke();
                    }
                }

            } 

        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        print("On Drop");      
    }



}
