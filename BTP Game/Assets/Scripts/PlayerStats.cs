using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public static int Energy;
	public int startEnergy = 100;


	public static int Rounds;

	void Start ()
	{
		Energy = startEnergy;

		Rounds = 0;
	}

}