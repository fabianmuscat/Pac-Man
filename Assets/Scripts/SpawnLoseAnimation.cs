using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnLoseAnimation : MonoBehaviour
{
    private new Animator animation;
    private PacMan pacman;
    private Vector2 pacmanPos;
    private Vector3 pacmanScale;
    private Vector2 startPosition;

    void Start()
    {
        startPosition = new Vector2(transform.position.x, transform.position.y);
        pacman = FindObjectOfType<PacMan>();
        animation = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        pacmanPos = new Vector2(pacman.transform.position.x, pacman.transform.position.y);
        pacmanScale = new Vector3(pacman.transform.localScale.x, pacman.transform.localScale.y);
    }

    public void ResetPosition()
    {
        animation.enabled = false;
        transform.position = startPosition;
    }

    public void Play()
    {
        SetPosition();
        SetSize();
        animation.enabled = true;
    }

    void SetSize()
    {
        gameObject.transform.localScale = pacmanScale;
    }

    void SetPosition()
    {
        gameObject.transform.position = pacmanPos;
    }

    public void ResetAnimation()
    {
        gameObject.SetActive(true);
        gameObject.transform.position = new Vector2(pacmanPos.x, pacmanPos.y);
    }
}