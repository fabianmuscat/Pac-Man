using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int currentScore;
    int pointsPerDot = 10;
    List<TextMeshProUGUI> textObjects;
    TextMeshProUGUI scoreText;
    private Scene currentScene;
    private int scoreCount;

    void Awake()
    {
        scoreCount = FindObjectsOfType<Score>().Length;

        if (scoreCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        currentScore = 0;
        textObjects = new List<TextMeshProUGUI>(FindObjectsOfType<TextMeshProUGUI>());
        scoreText = textObjects.Single(textObject => textObject.tag == "Score");
    }

    void Update()
    {
        CheckIfWinOrLose();
    }

    private void CheckIfWinOrLose()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Win" || currentScene.name == "Lose")
        {
            reset();
        }
    }

    public void addScore()
    {
        currentScore += pointsPerDot; 
        scoreText.SetText($"Score: {currentScore}");
    }

    public void reset()
    {
        Destroy(gameObject);
    }
}
