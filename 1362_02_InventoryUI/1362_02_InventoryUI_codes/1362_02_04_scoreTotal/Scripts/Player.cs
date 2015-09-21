using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	// reference to UI Text object
	public Text starText;

	// total number of stars the player has collected so far ...
	private int totalStars = 0;

	//--------------------
	// when scene starts, ensure UI text object is updated with our initial total of stars
	void Start()
	{
		UpdateStarText();
	}

	//---------------------------
	// if we hit something tagged 'Star'
	// then:
	//      - add to total of stars being carried
	//		- update text display to user
	//		- destroy the hit GameObject
	void OnTriggerEnter2D(Collider2D hit)
	{
		if(hit.CompareTag("Star")){
			totalStars++;
			UpdateStarText();
			Destroy(hit.gameObject);
		}
	}

	//----------------------------
	// build a string message indicating the total number of
	// stars being carried
	// then display this text string to user via UI object
	private void UpdateStarText()
	{
		string starMessage = "stars = " + totalStars;
		starText.text = starMessage;
	}
}
