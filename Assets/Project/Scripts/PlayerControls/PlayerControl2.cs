using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControl2 : AbstractPlayerControl
{

    public float speed=10;
    float startSpeed;
    int obstaclePassed = 0;
    GameObject obstacle;

    protected override void Awake()
    {
        base.Awake();
        obstacle = GameObject.FindGameObjectWithTag("Obstacle");
        startSpeed = speed;
    }

    private void Update()
    {
        if (isGameStarted && speed !=0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);            
        }
    }


    //when game starts we change bool "isGameStarted"
    protected override void GameStarted()
    {
        base.GameStarted();
        anim.SetTrigger("Run");
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
                obstaclePassed++;
                speed *= 2f;
                anim.SetTrigger("Run");
                StartCoroutine("MoveLittleForward");
                if (!isSortingTrue)
                {
                    EventManager.firstObstaclePassed?.Invoke();
                }
                other.transform.parent.gameObject.SetActive(false);
                break;
            default:
                break;
        }        
    }


    // after jumping we move player a little forward
    IEnumerator MoveLittleForward()
    {
        yield return new WaitForSeconds(1);
        speed = 0;
        anim.SetTrigger("Idle");
    }

    //if sorting is true, we bring obtsacle in front of player; and sets bool "imagesAreSorted" true
    protected override void SortingIsTrue()
    {
        base.SortingIsTrue();
        obstacle.transform.position = new Vector3(obstacle.transform.position.x, obstacle.transform.position.y,
            transform.position.z + 20);
        speed = startSpeed;        
        anim.SetTrigger("Run");
        StartCoroutine("WinScene");
    }

    IEnumerator WinScene()
    {
        yield return new WaitUntil(() => obstaclePassed ==2);
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("Win");
        speed = 0;
        EventManager.winMenu?.Invoke();
    }

    //if sorting is false, we stop player; 
    protected override void SortingIsFalse()
    {
        base.SortingIsFalse();
        speed = 0;        
    }
}
