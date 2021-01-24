using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Renderer rend;

    public Color startColor;
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    public GameObject turret;
    public bool path = false;
    public GameObject tower;

    private void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown ()
	{
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

    void buildTurret ()
	{
		// if (PlayerStats.Money < blueprint.cost)
		// {
		// 	Debug.Log("Not enough money to build that!");
		// 	return;
		// }


		if (PlayerStats.Energy < 10) {
			Debug.Log("Not enough money to build that!");
			return;
		}

		// PlayerStats.Money -= blueprint.cost;

		GameObject _turret = (GameObject) Instantiate(tower, transform.position, Quaternion.identity);
		turret = _turret;
		PlayerStats.Energy -= 10;

		Debug.Log("Turret build!");
	}

    void OnMouseEnter ()
	{
        Debug.Log("Hover");
		// if (buildManager.HasMoney) {
		// 	rend.material.color = hoverColor;
		// } else {
		// 	rend.material.color = notEnoughMoneyColor;
		// }
        if (!path && PlayerStats.Energy > 10) {
            rend.material.color = hoverColor;
        } else if (!path && PlayerStats.Energy < 10) {
			rend.material.color = notEnoughMoneyColor;
		}
        

	}

	void OnMouseExit ()
	{
		rend.material.color = startColor;
    }
}
