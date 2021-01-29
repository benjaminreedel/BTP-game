using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Renderer rend;

    public Sprite startSprite;
    public Color hoverColor;
	public Color noColor;
	public Color startColor;
    public Color notEnoughMoneyColor;

	public Sprite buildSprite;
	public Sprite endSprite;

    public GameObject turret;
	public GameObject tower;

    public bool path = false;

    private void Start() {
        startSprite = this.GetComponent<SpriteRenderer>().sprite;
		startColor = this.GetComponent<SpriteRenderer>().color;
    }

    void OnMouseDown() {
		// if (EventSystem.current.IsPointerOverGameObject())
		// 	return;

		// if (turret != null)
		// {
		// 	buildManager.SelectNode(this);
		// 	return;
		// }

		// if (!buildManager.CanBuild)
		// 	return;

		// BuildTurret(buildManager.GetTurretToBuild());

        if (turret == null && !path) {
            buildTurret();
        }
	}

    void buildTurret() {
		// if (PlayerStats.Money < blueprint.cost)
		// {
		// 	Debug.Log("Not enough money to build that!");
		// 	return;
		// }


		if (PlayerStats.Energy < BuildManager.towerCost) {
			Debug.Log("Not enough money to build that!");
			gameObject.GetComponent<SpriteRenderer>().color = hoverColor;
			gameObject.GetComponent<SpriteRenderer>().color = noColor;
			return;
		}

		// PlayerStats.Money -= blueprint.cost;
		tower = BuildManager.currentTower;
		turret = (GameObject) Instantiate(tower, transform.position, Quaternion.identity);
		gameObject.GetComponent<SpriteRenderer>().sprite = buildSprite;
		gameObject.GetComponent<SpriteRenderer>().color = noColor;
		startSprite = buildSprite;
		path = true;
		PlayerStats.Energy -= BuildManager.towerCost;
	}

    void OnMouseEnter() {
		// if (buildManager.HasMoney) {
		// 	rend.material.color = hoverColor;
		// } else {
		// 	rend.material.color = notEnoughMoneyColor;
		// }
        if (!path && PlayerStats.Energy >= BuildManager.towerCost) {
            //gameObject.GetComponent<SpriteRenderer>().sprite = buildSprite;
			gameObject.GetComponent<SpriteRenderer>().color = hoverColor;
        } else if (!path && PlayerStats.Energy < BuildManager.towerCost) {
			gameObject.GetComponent<SpriteRenderer>().sprite = endSprite;
			gameObject.GetComponent<SpriteRenderer>().color = noColor;
		}
        

	}

	void OnMouseExit() {
		//gameObject.GetComponent<SpriteRenderer>().sprite = startSprite;
		if (turret == null) {
			gameObject.GetComponent<SpriteRenderer>().sprite = startSprite;
			gameObject.GetComponent<SpriteRenderer>().color = startColor;
		}
    }
}
