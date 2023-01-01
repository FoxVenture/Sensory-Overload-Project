using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private int sceneNum;

    private void Start()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex+1;
    }
    public void NextScene()
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void ToMenuScene()
    {
        SceneManager.LoadScene("Main Menu");
    }    
}
