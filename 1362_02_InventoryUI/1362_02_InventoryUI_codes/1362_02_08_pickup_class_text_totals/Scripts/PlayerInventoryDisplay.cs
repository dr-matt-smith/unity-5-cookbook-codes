using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerInventoryDisplay : MonoBehaviour {
	public Text inventoryText;
	private string newInventoryText;
	
	public void OnChangeInventory(Dictionary<PickUp.PickUpType, int> inventory){
		inventoryText.text = "";
		
		newInventoryText = "carrying: ";
		int numItems = inventory.Count;

		foreach(var item in inventory){
			int itemTotal = item.Value;
			string description = item.Key.ToString();
			newInventoryText += " [ " + description + " " + itemTotal +  " ]";
		}
		
		if(numItems < 1) newInventoryText = "(empty inventory)";
		
		inventoryText.text = newInventoryText;
	}
}

