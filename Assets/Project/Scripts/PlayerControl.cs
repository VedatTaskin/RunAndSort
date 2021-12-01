using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControl : MonoBehaviour
{

    public float speed=10;
    Animator anim;
    bool isGameStarted;
    bool imagesAreSorted;
    GameObject obstacle;
    

    private void OnEnable()
    {
        EventManager.gameIsStarted += GameStarted;
        EventManager.sortingIsTrue += SortingIsTrue;
    }

    private void OnDisable()
    {
        EventManager.gameIsStarted -= GameStarted;
        EventManager.sortingIsTrue -= SortingIsTrue;
    }

    private void Awake()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        obstacle = GameObject.FindGameObjectWithTag("Obstacle");
    }

    private void Update()
    {
        if (isGameStarted)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            anim.SetTrigger("Run");
        }
    }

    void GameStarted()
    {
        isGameStarted = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "StartTrigger":
                speed *= 0.5f;
                anim.SetTrigger("Jump");
                break;
            case "EndTrigger":
                speed *= 2f;
                EventManager.firstObstaclePassed?.Invoke();
                other.transform.parent.gameObject.SetActive(false);
                break;
            default:
                break;
        }        
    }

    void SortingIsTrue()
    {
        imagesAreSorted = true;
        obstacle.transform.SetParent(null);
        obstacle.transform.position = new Vector3(obstacle.transform.position.x, obstacle.transform.position.y,
            transform.position.z + 20);
    }



}
