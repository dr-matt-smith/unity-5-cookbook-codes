using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {
	private PlayerInventoryDisplay playerInventoryDisplay;
	private Dictionary<PickUp.PickUpType, int> items = new Dictionary<PickUp.PickUpType, int>();
	
	void Start(){
		playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
		playerInventoryDisplay.OnChangeInventory(items);
	}
	
	public void Add(PickUp pickup){
		PickUp.PickUpType type = pickup.type;
		int oldTotal = 0;
		if(items.TryGetValue(type, out oldTotal))
			items[type] = oldTotal + 1;
		else
			items.Add (type, 1);
		
		playerInventoryDisplay.OnChangeInventory(items);
	}
}
