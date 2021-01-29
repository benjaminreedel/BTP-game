using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static GameObject currentTower;
    public static int towerCost;

    public GameObject basicTower;
    public GameObject sniperTower;
    public GameObject rollerTower;


    public void setBasic() {
        currentTower = basicTower;
        towerCost = 10;
    }

    public void setSniper() {
        currentTower = sniperTower;
        towerCost = 20;
    }

    public void setRoller() {
        currentTower = rollerTower;
        towerCost = 25;
    }

    private void Start() {
        currentTower = basicTower;
        towerCost = 10;
    }
}
