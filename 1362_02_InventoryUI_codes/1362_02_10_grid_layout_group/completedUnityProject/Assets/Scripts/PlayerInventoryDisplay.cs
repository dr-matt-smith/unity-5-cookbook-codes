using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInventoryDisplay : MonoBehaviour 
{
	const int NUM_INVENTORY_SLOTS = 10;
	public PickupUI[] slots = new PickupUI[NUM_INVENTORY_SLOTS];
	
	public void OnChangeStarTotal(int starTotal){
		for(int i = 0; i < NUM_INVENTORY_SLOTS; i++){
			PickupUI slot = slots[i];
			if(i < starTotal)
				slot.DisplayYellow();
			else
				slot.DisplayGrey();
		}
	}
}
