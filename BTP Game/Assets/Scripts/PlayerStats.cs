using UnityEngine;
using System.Collections;

public static class PlayerStats {

	public static int Energy = 100;
	public static int Score = 0;
	public static int Round = 0;

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

	public static int Scores {
		get {
			return Score;
		}
		set {
			Score = value;
		}
	}

}