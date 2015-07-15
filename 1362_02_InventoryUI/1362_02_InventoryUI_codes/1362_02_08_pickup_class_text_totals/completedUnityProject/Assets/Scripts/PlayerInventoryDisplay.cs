using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerInventoryDisplay : MonoBehaviour 
{
	public Text inventoryText;
	private string newInventoryText;
	
	public void OnChangeInventory(List<InventoryItemTotal> inventory){
		inventoryText.text = "";
		
		newInventoryText = "carrying: ";
		int numItems = inventory.Count;
		
		print("numitems = " + numItems);
		
		for(int i = 0; i < numItems; i++){
			InventoryItemTotal itemTotalObject = inventory[i];
			string description = itemTotalObject.type.ToString();
			newInventoryText += " [ " + description + " " + itemTotalObject.total +  " ]";
		}
		
		if(numItems < 1) newInventoryText = "(empty inventory)";
		
		inventoryText.text = newInventoryText;
	}
}

