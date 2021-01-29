using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if((player.transform.position.x - transform.position.x) > 0)
        {
            rb.velocity = (new Vector2(10, 0));
        } else {
            rb.velocity = (new Vector2(-10, 0));
        }
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        
        if (other.gameObject.name == "Square")
        {
            Destroy(gameObject);
            PlayerStats.Energy -= 5;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
