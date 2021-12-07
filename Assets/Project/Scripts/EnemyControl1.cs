using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyControl1 : MonoBehaviour
{
    bool isGameStarted;
    bool isSortingTrue;
    public float enemySpeed = 2;
    public float minDistance = 1.5f;
    public ParticleSystem attackFx;
    Animator anim;
    Transform playerTransform;

    enum State{ Dance, Walk, Death};
    State enemyState = State.Walk;

    private void OnEnable()
    {
        EventManager.gameIsStarted += GameIsStarted;
        EventManager.enemyCanDie += Death;
        EventManager.sortingIsTrue += SortingIsTrue;
    }
    private void OnDisable()
    {
        EventManager.gameIsStarted -= GameIsStarted;
        EventManager.enemyCanDie -= Death;
        EventManager.sortingIsTrue -= SortingIsTrue;
    }

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();        
    }

    private void Update()
    {
        if (isGameStarted && enemyState == State.Walk)
        {
            if (Vector3.Distance(transform.position, playerTransform.position) > minDistance)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * enemySpeed);
            }

            else if (Vector3.Distance(transform.position, playerTransform.position) <= minDistance)
            {
                enemyState = State.Dance;
                anim.SetTrigger("Dance");
                EventManager.enemyIsClose?.Invoke();                
            }
        }        
    }

    void GameIsStarted()
    {
        isGameStarted = true;
        anim.enabled = true;
    }

    // we call it from Kick "Animation Event"
    public void Death()
    {
        enemyState = State.Death;
        anim.SetTrigger("Death");
        transform.DOMoveZ(transform.position.z + 5, 1).OnComplete(SortingStage);

        // attackFX will be played,
        attackFx.Play();
    }

    void SortingStage()
    {
        if (isSortingTrue)
        {
            EventManager.winMenu?.Invoke();
        }
        else if (!isSortingTrue)
        {
            EventManager.firstObstaclePassed?.Invoke();           
        }
    }

    void SortingIsTrue()
    {
        isSortingTrue = true;        
        enemyState = State.Walk;
        anim.SetTrigger("Walk");
    }

}
