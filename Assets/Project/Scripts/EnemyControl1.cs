using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl1 : MonoBehaviour
{
    bool isGameStarted;
    bool cameClose;
    public float enemySpeed = 2;
    public float minDistance = 1.5f;
    Animator anim;
    Transform playerTransform;

    private void OnEnable()
    {
        EventManager.gameIsStarted += GameIsStarted;
    }
    private void OnDisable()
    {
        EventManager.gameIsStarted -= GameIsStarted;
    }

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isGameStarted && !cameClose)
        {
            if (Vector3.Distance(transform.position, playerTransform.position) > minDistance)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * enemySpeed);
            }

            else if (Vector3.Distance(transform.position, playerTransform.position) <= minDistance)
            {
                anim.SetTrigger("Dance");
                EventManager.enemyIsClose?.Invoke();
                cameClose = true;
            }
        }        
    }

    void GameIsStarted()
    {
        isGameStarted = true;
        anim.enabled = true;
    }

    public void Death()
    {
        anim.SetTrigger("Death");
    }
    
}
