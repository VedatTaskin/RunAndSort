using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    private int currentScene;
    GameObject player;

    private void Start()
    {
        currentScene= SceneManager.GetActiveScene().buildIndex;
        player = GameObject.FindGameObjectWithTag("Player");
        ChangeLevelIndex();
    }

    public void Restart()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void NextScene()
    {
        if (currentScene == 0)
        {
            currentScene++;
        }
        SceneManager.LoadScene(currentScene);
    }

    void ChangeLevelIndex()
    {
        Animator animator;

        switch (currentScene + 1)
        {

            case 1:
                player.AddComponent<PlayerControl1>();
                animator = player.transform.GetChild(0).GetComponent<Animator>();
                animator.runtimeAnimatorController = Resources.Load("CharacterAnimator 1") as RuntimeAnimatorController;
                break;
            case 2:
                player.AddComponent<PlayerControl2>();
                animator = player.transform.GetChild(0).GetComponent<Animator>();
                animator.runtimeAnimatorController = Resources.Load("CharacterAnimator 2") as RuntimeAnimatorController;
                break;
            default:
                break;
        }

    }
}
