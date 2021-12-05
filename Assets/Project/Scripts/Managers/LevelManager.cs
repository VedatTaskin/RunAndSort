using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    private int currentScene;
    GameObject player;
    Animator animator;

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
                break;
            case 3:
                player.AddComponent<PlayerControl3>();
                animator = player.transform.GetChild(0).GetComponent<Animator>();
                animator.runtimeAnimatorController = Resources.Load("CharacterAnimator 3") as RuntimeAnimatorController;
                break;
            default:
                break;
        }

    }
}
