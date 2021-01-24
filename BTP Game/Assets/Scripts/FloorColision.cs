using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorColision : MonoBehaviour
{
    public bool onfloor = false;
    public bool temp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        temp = true; 
    }
    
    void Update()
    {
        onfloor = false;
        if (temp)
        {
            onfloor = true;
        }
        temp = false;
    }
}
