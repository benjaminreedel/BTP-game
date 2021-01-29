using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 yo;
    private int walljumpcount;
    public int walljumps = 1;
    public float wallspeed = -1f;
    public float moveSpeed = 5f;
    public float jumpforce = 5f;
    public float fallmultiplier = 2.5f;
    public float lowjumpmultiplier = 2f;
    public FloorColision floorColision;
    private float timetouse;
    private Vector3 velo = Vector2.zero;
    Rigidbody2D rb;
    Transform tf;

    void Start()
    {
        //Seting a reference to this gameObject's Rigidbody and Transform
        rb = gameObject.GetComponent<Rigidbody2D>();
        tf = gameObject.GetComponent<Transform>();
        timetouse = Time.time;
    }

    void Update()
    {
        if (Time.time >= timetouse)
        {
            PlayerStats.Energy -= 1;
            timetouse = Time.time + 10;
        }
        //setting variables back to there deafults every frame
        //Which is overwriten by setting the variables again benith 
        rb.gravityScale = 4;

        //Debuging Variable
        yo = Input.mousePosition;

        //When pressing left or right set varible x to -1 or 1
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);
        //Creating a Vector2 to refernce when wanting to check if any buttons where pressed

        if(x<0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        } else if(x>0){
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        
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
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
                /**rb.gravityScale = 0;
                Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velo, 0.3f);
                //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);**/
        }
    }

    public int playerhit(int vulntime)
    {
        
        return 0;
        
    }

    void walk(Vector2 dir)
    {
        //set the character velocity depefing the the value of the x varible times the speed
        rb.velocity = (new Vector2((dir.x * moveSpeed), rb.velocity.y));
    }

    void jump()
    {
        //Making sure you can only jump when on the ground or on the side of
        //a wall with a wall jump remaining
        if (Input.GetButtonDown ("Jump") && floorColision.onfloor && PlayerStats.Energy > 0)
        {
            PlayerStats.Energy -= 2;
            rb.velocity += Vector2.up * jumpforce;
        } else
        if (Input.GetButtonDown ("Jump") && floorColision.onwall && walljumpcount < walljumps && PlayerStats.Energy > 0)
        {
            PlayerStats.Energy -= 4;
            rb.velocity += (new Vector2((rb.velocity.x * -1) * 4, 1 * jumpforce));
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
