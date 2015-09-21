using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInventoryDisplay : MonoBehaviour 
{
	// number of stars to display
	const int NUM_INVENTORY_SLOTS = 10;

	// array of objects to display stars
	public PickupUI[] slots = new PickupUI[NUM_INVENTORY_SLOTS];

	//----------------------------
	// given a 'starTotal' number of stars being carried
	// loop through, and display 'starTotal' as yellow
	// and the rest as grey
	public void OnChangeStarTotal(int starTotal)
	{
		for(int i = 0; i < NUM_INVENTORY_SLOTS; i++){
			PickupUI slot = slots[i];
			if(i < starTotal)
				slot.DisplayYellow();
			else
				slot.DisplayGrey();
		}
	}
}
