using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    Vector3 startpos;
    Vector3 emir;
    public Vector3 targetpos;
    bool down = true;
    Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        emir = startpos + targetpos;
        move();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Square")
        {
            other.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.name == "Square")
        {
            other.collider.transform.SetParent(null);
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
