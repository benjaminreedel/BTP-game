using UnityEngine;
using System.Collections;

public static class PlayerStats : MonoBehaviour {

	public static int Energy;
	public static int Round = 1;
	public static int startEnergy = 100;

	void Start ()
	{
		Energy = startEnergy;
	}

}