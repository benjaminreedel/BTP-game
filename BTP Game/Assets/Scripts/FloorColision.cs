using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorColision : MonoBehaviour
{
    public bool onfloor = false;
    public int colcount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        colcount++; 
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        colcount--;    
    }

    void Update()
    {
        if (colcount > 0)
        {
            onfloor = true;
        } else {
            onfloor = false;
        }
    }
}
