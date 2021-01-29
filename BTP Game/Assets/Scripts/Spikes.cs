using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float timetohit;
    private PlayerMovement playerMovement;
    void Start()
    {
        timetohit = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D other) {
        
        if (Time.time > timetohit)
        {
            PlayerStats.Energy -= 5;
            timetohit = Time.time + 2;
            other.gameObject.GetComponent<PlayerMovement>().playerhit(2);
        }
    }
}
