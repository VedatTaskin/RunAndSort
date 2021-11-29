using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject slotPanel;

    private void Awake()
    {
        slotPanel = GameObject.FindGameObjectWithTag("Slot");
        slotPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ActivateSlotPanel();
        }

    }

    void ActivateSlotPanel()
    {
        slotPanel.SetActive(true);
    }
}
