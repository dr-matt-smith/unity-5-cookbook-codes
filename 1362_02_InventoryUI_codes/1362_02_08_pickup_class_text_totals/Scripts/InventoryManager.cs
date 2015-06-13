using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {
	private PlayerInventoryDisplay playerInventoryDisplay;
	private List<InventoryItemTotal> items = new List<InventoryItemTotal>();
	
	void Start(){
		playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
		playerInventoryDisplay.OnChangeInventory(items);
	}
	
	public void Add(PickUp pickup){
		PickUp.PickUpType type = pickup.type;
		int index = InventoryItemTotal.IndexOfType(type, items);
		
		print ("index = " + index);
		
		if(index < 0)
			AddNewTypeToList(type);
		else
			items[index].total++;
		
		playerInventoryDisplay.OnChangeInventory(items);
	}
	
	private void AddNewTypeToList(PickUp.PickUpType type){
		InventoryItemTotal newItemTotal = new InventoryItemTotal();
		newItemTotal.type = type;
		newItemTotal.total = 1;
		items.Add (newItemTotal);
	}
}
