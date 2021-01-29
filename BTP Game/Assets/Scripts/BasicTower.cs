using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTower : Tower
{
    public Transform pivot;
    public Transform barrel;
    public GameObject bullet;
    public AudioSource source;


    protected override void shoot() {
        base.shoot();
        source.Play();
        GameObject newBullet = Instantiate(bullet, barrel.position, pivot.rotation);
    }
}
