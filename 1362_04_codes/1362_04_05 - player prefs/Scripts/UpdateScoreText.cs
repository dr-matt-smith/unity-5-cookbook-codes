using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class UpdateScoreText : MonoBehaviour {
	void Start(){
		Text scoreText = GetComponent<Text>();

		int scoreCorrect = PlayerPrefs.GetInt("scoreCorrect");
		int scoreIncorrect = PlayerPrefs.GetInt("scoreIncorrect");

		int totalAttempts = scoreCorrect + scoreIncorrect;
		string scoreMessage = "Score = ";
		scoreMessage += scoreCorrect + " / " + totalAttempts;

		scoreText.text = scoreMessage;
	}
}
