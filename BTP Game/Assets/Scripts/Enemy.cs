using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public float enemyHealth;

    [SerializeField]
    public float movementSpeed;

    [SerializeField]
    private int damage;

    private GameObject targetTile;

    private void Awake() {
        EnemyManager.enemies.Add(gameObject);
    }

    private void Start() {
        initializeEnemy();
    }

    private void initializeEnemy() {
        targetTile = MapGenerator.startTile;
    }

    public void takeDamage(float amount) {
        enemyHealth -= amount;
        if (enemyHealth <= 0) {
            PlayerStats.Energy += 1;
            die();
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Bullet") {
            takeDamage(5);
        } else if (other.gameObject.tag == "SniperBullet") {
            takeDamage(1000);
        }
    }

    private void die() {
        EnemyManager.enemies.Remove(gameObject);
        Destroy(transform.gameObject);
    }

    private void moveEnemy() {
        transform.position = Vector3.MoveTowards(transform.position, targetTile.transform.position, movementSpeed * Time.deltaTime);
    }

    private void checkPosition() {

        // check the targetTile exists, and that it is not the endtile
        if (targetTile != null && targetTile != MapGenerator.endTile) {
            float distance = (transform.position - targetTile.transform.position).magnitude;

            if (distance < 0.001f) {
                int currentIndex = MapGenerator.pathTiles.IndexOf(targetTile);

                targetTile = MapGenerator.pathTiles[currentIndex + 1];
            }
        }
    }

    private void Update() {
        checkPosition();
        moveEnemy();
        if (transform.position == MapGenerator.endTile.transform.position) {
            PlayerStats.Energy -= damage;
            if (PlayerStats.Energy < 0) {
                SceneManager.LoadScene("GameOver");
            }
            die();
        }
    }

}



