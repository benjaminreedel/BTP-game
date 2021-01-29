using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject BasicEnemy;

    public GameObject mapTile;
    public Node nodeScript;
    public Enemy enemyScript;

    public bool waveUp = false;

    [SerializeField] private int mapWidth;
    [SerializeField] private int mapHeight;

    public static List<GameObject> mapTiles = new List<GameObject>();
    public static List<GameObject> pathTiles = new List<GameObject>();

    public static GameObject startTile;
    public static GameObject endTile;

    private bool reachedX = false;
    private bool reachedY = false;
    private GameObject currentTile;
    private int currentIndex;
    private int nextIndex;

    public Color pathColor;
    public Color startColor;
    public Color noColor;
    public Color blockedColor;

    public Sprite pathSprite;
    public Sprite endSprite;
    public Sprite blockedSprite;
    public Sprite startSprite;


    private void Start() {
        deleteMap();
        reachedX = false;
        reachedY = false;
        mapTiles = new List<GameObject>();
        pathTiles = new List<GameObject>();
        waveUp = false;
        generateMap();
    }

    private List<GameObject> getTopEdgeTiles() {
        List<GameObject> edgeTiles = new List<GameObject>();

        for (int i = mapWidth * (mapHeight - 1); i < (mapWidth * mapHeight); i++) {
            edgeTiles.Add(mapTiles[i]);

        }

        return edgeTiles;
    }

    private List<GameObject> getBottomEdgeTiles() {
        List<GameObject> edgeTiles = new List<GameObject>();
        
        for (int i = 0; i < mapWidth; i++) {
            edgeTiles.Add(mapTiles[i]);
        }

        return edgeTiles;
    }

    private void moveDown() {
        nodeScript = currentTile.GetComponent<Node>();
        nodeScript.path = true;
        pathTiles.Add(currentTile);
        currentIndex = mapTiles.IndexOf(currentTile);
        nextIndex = currentIndex - mapWidth;
        currentTile = mapTiles[nextIndex];
    }

    private void moveLeft() {
        nodeScript = currentTile.GetComponent<Node>();
        nodeScript.path = true;
        pathTiles.Add(currentTile);
        currentIndex = mapTiles.IndexOf(currentTile);
        nextIndex = currentIndex-1;
        currentTile = mapTiles[nextIndex];
    }

    private void moveRight() {
        nodeScript = currentTile.GetComponent<Node>();
        nodeScript.path = true;
        pathTiles.Add(currentTile);
        currentIndex = mapTiles.IndexOf(currentTile);
        nextIndex = currentIndex+1;
        currentTile = mapTiles[nextIndex];
    }


    // Generates the Wave, is called by pressing the Call Wave button
    public void generateWave()
    {
        if (waveUp == false)
        {
            PlayerStats.Round++;
            StartCoroutine("ISpawnEnemies");
        }
        

    }

    IEnumerator ISpawnEnemies() {

        int rand = Random.Range(1, PlayerStats.Round) + 1 + PlayerStats.Round;
        waveUp = true;
        for (int i = 0; i < rand; i++) {

            GameObject e = Instantiate(BasicEnemy, startTile.transform.position, Quaternion.identity);
            enemyScript = e.GetComponent<Enemy>();
            enemyScript.movementSpeed += (0.2f * PlayerStats.Round);
            enemyScript.enemyHealth += (PlayerStats.Round);
            
            if (PlayerStats.Round < 10) {
                yield return new WaitForSeconds(1.5f - (0.1f * PlayerStats.Round));
            } else {
                yield return new WaitForSeconds(.4f - (0.01f * PlayerStats.Round));
            }
        }
        waveUp = false;
    }

    public void deleteMap() {
        foreach (GameObject tile in mapTiles) {
            Destroy(tile);
        }
    }

    private void generateMap() {
        for (int y = 0; y < mapHeight; y++) {
            for (int x = 0; x < mapWidth; x++) {
                GameObject newTile = Instantiate(mapTile);

                mapTiles.Add(newTile);

                newTile.transform.position = new Vector2(x, y);
            }
        }

        List<GameObject> topEdgeTiles = getTopEdgeTiles();
        List<GameObject> bottomEdgeTiles = getBottomEdgeTiles();

        int rand1 = Random.Range(0, mapWidth);
        int rand2;
        if (rand1 - 3 > 0) {
            rand2 = (rand1 - 3);
        } else {
            rand2 = (rand1 + 3);
        }

        startTile = topEdgeTiles[rand1];
        endTile = bottomEdgeTiles[rand2];

        currentTile = startTile;

        moveDown();

        while (!reachedX && !reachedY) {
            int rand = Random.Range(0, 2);
            if (rand == 1) {
                if (currentTile.transform.position.x > endTile.transform.position.x) {
                    moveLeft();
                } else if (currentTile.transform.position.x < endTile.transform.position.x) {
                    moveRight();
                } else {
                    reachedX = true;
                }
            } else {
                if (currentTile.transform.position.y > endTile.transform.position.y) {
                    moveDown();
                } else {
                    reachedY = true;
            }
            }
        }

        while (!reachedX) {

            if (currentTile.transform.position.x > endTile.transform.position.x) {
                moveLeft();
            } else if (currentTile.transform.position.x < endTile.transform.position.x) {
                moveRight();
            } else {
                reachedX = true;
            }
        }

        while (!reachedY) {
            if (currentTile.transform.position.y > endTile.transform.position.y) {
                moveDown();
            } else {
                reachedY = true;
            }
        }

        nodeScript = endTile.GetComponent<Node>();
        nodeScript.path = true;
        pathTiles.Add(endTile);

        foreach (GameObject tile in mapTiles) {
            int rand = Random.Range(0, 3);
            if (rand == 1) {
                tile.GetComponent<SpriteRenderer>().sprite = blockedSprite;
                tile.GetComponent<SpriteRenderer>().color = noColor;
                nodeScript = tile.GetComponent<Node>();
                nodeScript.path = true;
            }
        }

        foreach (GameObject tile in pathTiles) {
            tile.GetComponent<SpriteRenderer>().sprite = startSprite;
            tile.GetComponent<SpriteRenderer>().color = pathColor;
        }

        startTile.GetComponent<SpriteRenderer>().sprite = endSprite;
        startTile.GetComponent<SpriteRenderer>().color = noColor;
        endTile.GetComponent<SpriteRenderer>().sprite = endSprite;
        endTile.GetComponent<SpriteRenderer>().color = noColor;
        
    }
}
