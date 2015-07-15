using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryItemTotal {
	public PickUp.PickUpType type;
	public int total;
	
	public static int IndexOfType(PickUp.PickUpType type, List<InventoryItemTotal> itemTotalList){
		for (int i = 0; i < itemTotalList.Count; i++){
			if (itemTotalList[i].type == type){
				return i;
			}
		}
		
		// return seninal value to indicate item not found
		return -1;
	}	
}
