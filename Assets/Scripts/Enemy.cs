using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Timeline;

public class Enemy : MonoBehaviour
{
    public Sprite EnemyUp, EnemyDown, EnemyLeft, EnemyRight;
    private SpawnLoseAnimation loseAnimation;
    private Health healthbar;
    private Level level;
    private PacMan pacman;
    private Vector3 lastPosition;


    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource source;

    void Start()
    {
        lastPosition = transform.position;

        level = FindObjectOfType<Level>();
        healthbar = FindObjectOfType<Health>();
        loseAnimation = FindObjectOfType<SpawnLoseAnimation>();
        pacman = FindObjectOfType<PacMan>();
    }

    Vector3 checkPosition(Vector3 lastPos, Vector3 pos)
    {
        Vector3 direction = pos - lastPos;
        lastPosition = transform.position;
        return direction;
    }

    private void setSprite()
    {
        var difference = checkPosition(lastPosition, transform.position);

        if (difference.x > 0.01)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = EnemyRight;
        }
        else if (difference.x < -0.01)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = EnemyLeft;
        }
        else if (difference.y > 0.01)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = EnemyUp;
        }
        else if (difference.y < -0.01)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = EnemyDown;
        }
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Pacman")
        {
            if (healthbar.lives == 0)
            {
                Destroy(source);
                Destroy(loseAnimation);
                Destroy(collider.gameObject);
            }
            else
            {
                source.PlayOneShot(clip, 0.2f);

                level.RemoveLive();

                loseAnimation.ResetAnimation();
                loseAnimation.Play();

                collider.gameObject.SetActive(false);

                yield return new WaitForSeconds(1);

                loseAnimation.ResetPosition();
                pacman.ResetPosition();
            }
        }
    }

    void Update()
    {
        setSprite();
    }
}
