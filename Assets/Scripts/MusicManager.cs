using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        int musicCount = FindObjectsOfType<MusicManager>().Length;

        if (musicCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            source.Play();
            source.volume = 0.2f;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void StopMusic()
    {
        source.Pause();
    }

    public void ContinueMusic()
    {
        source.Play();
    }
}
