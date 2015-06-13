using UnityEngine;

public class Player : MonoBehaviour {
	public static int scoreCorrect = 0;
	public static int scoreIncorrect = 0;

	public static void ZeroAll(){
		scoreCorrect = 0;
		scoreIncorrect = 0;
	}
}
