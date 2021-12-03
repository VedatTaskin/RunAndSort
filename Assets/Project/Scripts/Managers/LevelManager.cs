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
        switch (currentScene)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                player.GetComponent<PlayerControl3>().enabled = true;
                Animator animator = player.transform.GetChild(0).GetComponent<Animator>();
                animator.runtimeAnimatorController = Resources.Load("CharacterAnimator 3") as RuntimeAnimatorController;
                break;
            default:
                break;
        }

    }
}
