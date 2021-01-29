using UnityEngine;
using System.Collections;

public static class PlayerStats {

	public static int Energy = 300;
	public static int Round = 1;

	public static int Rounds {
		get {
			return Round;
		}
		set {
			Round = value;
		}
	}

	public static int Energys {
		get {
			return Energy;
		}
		set {
			Energy = value;
		}
	}

}