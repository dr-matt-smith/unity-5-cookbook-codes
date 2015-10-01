using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class UpdateScoreText : MonoBehaviour
{
	/*-------------------------------------------
	 * load scores from Player static variables
	 * and display on screen in sibling UI Text component
	 */
	void Start()
	{
		Text scoreText = GetComponent<Text>();
		int totalAttempts = Player.scoreCorrect + Player.scoreIncorrect;
		string scoreMessage = "Score = ";
		scoreMessage += Player.scoreCorrect + " / " + totalAttempts;

		scoreText.text = scoreMessage;
	}
}