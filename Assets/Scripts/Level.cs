using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    LevelLoader level;
    [SerializeField] private int pacdots;
    Health healthbar;

    private Sprite health;

    void Start()
    {
        pacdots = 0;
        healthbar = FindObjectOfType<Health>();
        level = FindObjectOfType<LevelLoader>();
    }

    public void countDots()
    {
        pacdots++;
    }

    public void PacdotDestroyed() 
    {
        pacdots--;
        if (pacdots <= 0)
        {
            level.LoadNextLevel();
        }
    }

    public void RemoveLive()
    {
        healthbar.lives--;
        if (healthbar.lives == 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
