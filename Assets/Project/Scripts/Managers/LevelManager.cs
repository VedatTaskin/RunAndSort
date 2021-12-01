using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentScene;


    private void Start()
    {
        currentScene= SceneManager.GetActiveScene().buildIndex;        
    }

    public void Restart()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(currentScene);
    }

}
