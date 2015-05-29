using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class UpdateScoreText : MonoBehaviour {
	void Start(){
		Text scoreText = GetComponent<Text>();
		int totalAttempts = Player.scoreCorrect + Player.scoreIncorrect;
		string scoreMessage = "Score = ";
		scoreMessage += Player.scoreCorrect + " / " + totalAttempts;

		scoreText.text = scoreMessage;
	}
}
