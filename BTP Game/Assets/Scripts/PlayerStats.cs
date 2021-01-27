using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public static int Energy;
	public static int Round = 1;
	public int startEnergy = 100;

	void Start ()
	{
		Energy = startEnergy;
	}

}