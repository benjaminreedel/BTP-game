using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float yo;
    public int walljumpcount;
    public int walljumps = 1;
    public float wallspeed = -1f;
    public float moveSpeed = 5f;
    public float jumpforce = 5f;
    public float fallmultiplier = 2.5f;
    public float lowjumpmultiplier = 2f;
    public GameObject bulletPrefab;
    public FloorColision floorColision;
    Rigidbody2D rb;
    Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        //Seting a reference to this gameObject's Rigidbody and Transform
        rb = gameObject.GetComponent<Rigidbody2D>();
        tf = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        //setting variables back to there deafults every frame
        //Which is overwriten by setting the variables again benith 
        //rb.velocity = (new Vector2(0, rb.velocity.y));
        rb.gravityScale = 4;

        //Debuging Variable
        yo = rb.velocity.y;

        //When pressing left or right set varible x to -1 or 1
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);
        //Creating a Vector2 to refernce when wanting to check if any buttons where pressed

        
        walk(dir);
        jump();
        //Called when colliding with the floor
        if (floorColision.onfloor)
        {
            walljumpcount = 0;
        }

        //called when colliding with the wall and not on the floor and the character is falling
        if (floorColision.onwall && !floorColision.onfloor && x != 0 && rb.velocity.y < 0)
        {
            //This add the wall slide and slow decent
            rb.gravityScale = 0;
            rb.velocity = (new Vector2(rb.velocity.x, wallspeed));
        }
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
        //set the character velocity depefing the the value of the x varible times the speed
        rb.velocity = (new Vector2(dir.x * moveSpeed, rb.velocity.y));
    }

    void jump()
    {
        //Making sure you can only jump when on the ground or on the side of
        //a wall with a wall jump remaining
        if (Input.GetButtonDown ("Jump") && floorColision.onfloor)
        {
            rb.velocity += Vector2.up * jumpforce;
        } else
        if (Input.GetButtonDown ("Jump") && floorColision.onwall && walljumpcount < walljumps)
        {
            rb.velocity = (new Vector2((rb.velocity.x * -1) * 2, 1 * jumpforce));
            walljumpcount++;
            Debug.Log("Walljmup");
        }

        //adds holding jump to jump longer and quicker decent than acent
        if (rb.velocity.y < 0 && !floorColision.onwall) 
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallmultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowjumpmultiplier - 1) * Time.deltaTime;
        }
    }
}
