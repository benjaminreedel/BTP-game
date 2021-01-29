using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformPlayer : MonoBehaviour
{
    Vector3 startpos;
    public Vector3 emir;
    public Vector3 targetpos;
    public bool down = true;
    Rigidbody2D rb;
    public float speed;
    private bool playeron = false;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        emir = startpos + targetpos;
        if(playeron)
        move();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Square")
        {
            playeron = true;
            other.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.name == "Square")
        {
            other.collider.transform.SetParent(null);
            playeron = false;
        }
    }

    void move()
    {
        
        if (down)
        {
            transform.position = Vector2.MoveTowards(transform.position, emir, speed * Time.deltaTime);
        }

        if (!down)
        {
            transform.position = Vector2.MoveTowards(transform.position, startpos, speed * Time.deltaTime);
        }
        
        if (transform.position == emir)
        {
            down = false;
        }

        if (transform.position == startpos)
        {
            down = true;
        }
    }
}
