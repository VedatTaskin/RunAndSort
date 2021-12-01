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
        EventManager.onFail += SortingIsFalse;
    }

    private void OnDisable()
    {
        EventManager.gameIsStarted -= GameStarted;
        EventManager.sortingIsTrue -= SortingIsTrue;
        EventManager.onFail -= SortingIsFalse;
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


    //when game starts we change bool "isGameStarted"
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
                if (imagesAreSorted)
                {
                    StartCoroutine(WinScene());
                }
                break;
            default:
                break;
        }        
    }

    //if sorting is true, we bring obtsacle in front of player; and sets bool "imagesAreSorted" true
    void SortingIsTrue()
    {
        imagesAreSorted = true;
        obstacle.transform.position = new Vector3(obstacle.transform.position.x, obstacle.transform.position.y,
            transform.position.z + 20);
    }

    IEnumerator WinScene()
    {
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("Win");
        speed = 0;
    }

    //if sorting is false, we stop player; 
    void SortingIsFalse()
    {
        speed = 0;
        anim.SetTrigger("Lose");
    }
}
