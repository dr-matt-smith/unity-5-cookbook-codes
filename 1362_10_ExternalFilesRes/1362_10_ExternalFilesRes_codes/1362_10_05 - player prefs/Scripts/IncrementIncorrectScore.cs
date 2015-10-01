using UnityEngine;
using System.Collections;

public class IncrementIncorrectScore : MonoBehaviour
{
	/*-------------------------------------------
	 * add 1 to stored score
	 * retreive existing score with GetInt, add 1, and then store with SetInt
	 */
	void Start ()
	{
		int newScoreIncorrect = 1 + PlayerPrefs.GetInt("scoreIncorrect");
		PlayerPrefs.SetInt("scoreIncorrect", newScoreIncorrect);
	}
}
