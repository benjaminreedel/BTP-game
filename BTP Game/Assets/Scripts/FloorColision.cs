using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorColision : MonoBehaviour
{
    public bool onfloor = false;
    public bool onwall = false;
    public int wallcount = 0;
    public int colcount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "wall")
        {
            colcount++; 
        } else {
            wallcount++;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag != "wall")
        {
            colcount--;
        } else {
            wallcount--;
        }
    }

    void Update()
    {
        if (colcount > 0)
        {
            onfloor = true;
        } else {
            onfloor = false;
        }

        if (wallcount > 0)
        {
            onwall = true;
        } else {
            onwall = false;
        }
    }
}
