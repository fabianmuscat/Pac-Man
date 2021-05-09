using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    private MusicManager music;

    private GameObject mute;
    private GameObject unmute;

    // Start is called before the first frame update
    void Start()
    {
        music = FindObjectOfType<MusicManager>();
        mute = GameObject.Find("Mute Button");
        unmute = GameObject.Find("Unmute Button");
    }

    void Update()
    {
        if (music.source.isPlaying)
        {
            unmute.SetActive(false);
            mute.SetActive(true);
        }
        else
        {
            mute.SetActive(false);
            unmute.SetActive(true);
        }
    }

    public void Stop()
    {
        music.StopMusic();
    }

    public void Continue()
    {
        music.ContinueMusic();
    }
}
