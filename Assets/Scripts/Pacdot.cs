using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pacdot : MonoBehaviour
{
    Level level;
    Score score;

    void Awake()
    {
        level = FindObjectOfType<Level>();
        score = FindObjectOfType<Score>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (tag == "Pacdot")
        {
            level.countDots();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag != "Enemy")
        {
            FindObjectOfType<Score>().addScore();
        }

        
        if (collider.tag == "Pacman")
        {

            level.PacdotDestroyed();
            Destroy(gameObject);
        }
    }
}