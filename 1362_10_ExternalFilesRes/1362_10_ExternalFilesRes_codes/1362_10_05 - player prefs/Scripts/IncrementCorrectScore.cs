using UnityEngine;
using System.Collections;

public class IncrementCorrectScore : MonoBehaviour
{
	/*-------------------------------------------
	 * add 1 to stored score
	 * retreive existing score with GetInt, add 1, and then store with SetInt
	 */
	void Start ()
	{
		int newScoreCorrect = 1 + PlayerPrefs.GetInt("scoreCorrect");
		PlayerPrefs.SetInt("scoreCorrect", newScoreCorrect);

	}
}
