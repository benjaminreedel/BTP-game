using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField]
    private float range;

    // [SerializeField]
    // private float damage;

    [SerializeField]
    private float cooldown; // time between shots;

    private float nextTimeToShoot;

    public GameObject currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        nextTimeToShoot = Time.time;
    }

    private void updateNearestEnemy() {
        GameObject currentNearestEnemy = null;

        float distance = Mathf.Infinity;

        foreach (GameObject enemy in EnemyManager.enemies)
        {
            if (enemy != null) {
                float _distance = (transform.position - enemy.transform.position).magnitude;

                if (_distance < distance) {
                    distance = _distance;
                    currentNearestEnemy = enemy;
                }
            }
        }

        
        currentTarget = currentNearestEnemy;
    

        if (Time.time >= nextTimeToShoot) {
            if (distance <= range) {
                shoot();
                float rand = Random.Range(0, 1f);
                if (this.gameObject.tag == "Bullet") {
                    rand = 0;
                }
                nextTimeToShoot = Time.time + cooldown + rand;
            }
        }
        
    
    }

    protected virtual void shoot() {
        Enemy enemyScript = currentTarget.GetComponent<Enemy>();

        // enemyScript.takeDamage(damage);
        
    }

    // Update is called once per frame
    void Update()
    {
        updateNearestEnemy();
    }
 
}
