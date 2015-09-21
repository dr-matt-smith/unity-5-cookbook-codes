using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	// cached reference to instance of PlayerInventoryDisplay
	private PlayerInventoryDisplay playerInventoryDisplay;

	// number of stars player is carrying
	private int totalStars = 0;
	
	//-----------------------------
	void Start()
	{
		// get reference to instance of PlayerInventoryDisplay in parent GameObject
		playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
	}

	//-----------------------------
	// IF we hit something taggerd 'Star'
	// THEN
	//		- add to our total
	//		- tell PlayerInventoryDisplay object to update its display to the user
	//		- destron the hit GameObject
	void OnTriggerEnter2D(Collider2D hit)
	{
		if(hit.CompareTag("Star")){
			totalStars++;
			playerInventoryDisplay.OnChangeStarTotal(totalStars);
			Destroy(hit.gameObject);
		}
	}
}
