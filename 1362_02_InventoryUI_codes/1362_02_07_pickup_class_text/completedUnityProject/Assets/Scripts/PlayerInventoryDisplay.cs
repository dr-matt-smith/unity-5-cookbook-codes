using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerInventoryDisplay : MonoBehaviour 
{
	public Text inventoryText;
	
	public void OnChangeInventory(List<PickUp> inventory){
		/* 
		 * alphabetical sorting of List
		 * 

		inventory.Sort(
			delegate(PickUp p1, PickUp p2){
			return p1.description.CompareTo(p2.description);
		}
		);
		
		*/

		// (1) clear existing display
		inventoryText.text = "";
		
		// (2) build up new set of items 
		string newInventoryText = "carrying: ";
		int numItems = inventory.Count;
		for(int i = 0; i < numItems; i++){
			string description = inventory[i].description;
			newInventoryText += " [" + description+ "]";
		}
		
		if(numItems < 1) newInventoryText = "(empty inventory)";
		
		// (3) update screen display
		inventoryText.text = newInventoryText;
	}
}
