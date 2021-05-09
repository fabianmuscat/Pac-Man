using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class WinScore : MonoBehaviour
{
    private Score score;
    private List<TextMeshProUGUI> texts;
    private TextMeshProUGUI winScore;

    void Start()
    {
        score = FindObjectOfType<Score>();
        texts = new List<TextMeshProUGUI>(FindObjectsOfType<TextMeshProUGUI>());
        winScore = texts.Single(text => text.tag == "WinScore");

        if (winScore.tag == "WinScore")
        {
            winScore.SetText($"Total Score: {score.currentScore}");
        }
    }
}
