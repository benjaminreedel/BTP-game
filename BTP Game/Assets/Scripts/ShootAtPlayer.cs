using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{
    private float timetoshoot;
    public GameObject bullet;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        timetoshoot = Time.time + 3 + offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timetoshoot)
        {
            shoot();
            timetoshoot = Time.time + 3;
        }


    }

    void shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
