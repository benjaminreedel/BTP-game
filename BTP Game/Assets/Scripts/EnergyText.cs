using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyText : MonoBehaviour
{

    public Text energy;

    // Update is called once per frame
    void Update()
    {
        energy.text = "Energy: " + PlayerStats.Energy;
    }
}
