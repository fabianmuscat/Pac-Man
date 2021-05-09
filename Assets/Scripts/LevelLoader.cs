using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR 
using UnityEditor;
#endif

public class LevelLoader : MonoBehaviour
{
    private Score score;

    void Start()
    {
        score = FindObjectOfType<Score>();
    }

    public void LoadLevel(string levelName)
    {
        if (levelName == "Menu" && score != null)
        {
            score.reset();
        }
        SceneManager.LoadScene(levelName);
    } 

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
