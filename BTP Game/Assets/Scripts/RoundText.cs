using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundText : MonoBehaviour
{

    public Text round;

    // Update is called once per frame
    void Update()
    {
        round.text = "Round: " + PlayerStats.Round;
    }
}
