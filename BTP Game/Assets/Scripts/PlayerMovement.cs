using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float yo;
    public float moveSpeed = 5f;
    public float jumpforce = 5f;
    public float fallmultiplier = 2.5f;
    public float lowjumpmultiplier = 2f;
    public GameObject bulletPrefab;
    Rigidbody2D rb;
    Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        tf = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        yo = rb.velocity.y;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);

        jump();
        walk(dir);
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab,tf.position,tf.rotation);
        }
    }

    void walk(Vector2 dir)
    {
        rb.velocity = (new Vector2(dir.x * moveSpeed, rb.velocity.y));
    }

    void jump()
    {
        if (Input.GetButtonDown ("Jump"))
        {
            rb.velocity += Vector2.up * jumpforce;
        }

        if (rb.velocity.y < 10) 
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallmultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowjumpmultiplier - 1) * Time.deltaTime;
        }
    }
}
