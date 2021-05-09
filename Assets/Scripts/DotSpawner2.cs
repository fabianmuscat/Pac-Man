using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpawner2 : MonoBehaviour
{
    GameObject[] dots;
    GameObject dot;

    Vector2 dotPosition;

    void LoadDotsFromResources()
    {
        dots = Resources.LoadAll<GameObject>("PacdotsLvl2");
        dotPosition = transform.position;
    }

    void GetRandomDot()
    {
        int randomNumber = Random.Range(0, dots.Length);
        dot = dots[randomNumber];
    }

    void SpawnDots()
    {
        Instantiate(dot, dotPosition, transform.rotation);
    }

    void PrintDots()
    {
        GetRandomDot();
        SpawnDots();
    }

    void Start()
    {
        LoadDotsFromResources();
        PrintDots();
    }
}
