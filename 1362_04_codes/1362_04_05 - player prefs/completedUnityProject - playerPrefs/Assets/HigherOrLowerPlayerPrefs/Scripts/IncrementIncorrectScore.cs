using UnityEngine;
using System.Collections;

public class IncrementIncorrectScore : MonoBehaviour {
	void Start () {
		int newScoreIncorrect = 1 + PlayerPrefs.GetInt("scoreIncorrect");
		PlayerPrefs.SetInt("scoreIncorrect", newScoreIncorrect);
	}
}
