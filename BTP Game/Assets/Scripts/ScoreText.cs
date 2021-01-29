using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    public TMPro.TextMeshProUGUI score;

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + PlayerStats.Score;
    }
}
