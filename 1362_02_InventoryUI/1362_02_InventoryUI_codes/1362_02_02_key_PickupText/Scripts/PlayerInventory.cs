using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour
{
	// a cached reference to an instance of class PlayerInventoryDisplay
	private PlayerInventoryDisplay playerInventoryDisplay;

	// flag to indicate if player is carrying a star or not
	private bool carryingStar = false;

	//------------------------
	// cache a reference to the PlayerInventoryDisplay object
	// that is in the parent GameObject
	//
	// and then ensure UI display matches this initial state
	// of whether we are carrying a star or not
	void Start()
	{
		playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
		playerInventoryDisplay.OnChangeCarryingStar(carryingStar);
	}

	//--------------------------
	void OnTriggerEnter2D(Collider2D hit)
	{
		// IF we hit something tagged 'Star'
		if(hit.CompareTag("Star")){
			// set our flag to TRUE
			carryingStar = true;

			// update the UI display of our star carrying status
			playerInventoryDisplay.OnChangeCarryingStar(carryingStar);

			// destroy the star object that we collided with
			Destroy(hit.gameObject);
		}
	}
}
