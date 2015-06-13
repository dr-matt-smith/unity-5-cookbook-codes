using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	private InventoryManager inventoryManager;
	
	void Start(){
		inventoryManager = GetComponent<InventoryManager>();
	}
	
	void OnTriggerEnter2D(Collider2D hit){
		if(hit.CompareTag("Pickup")){
			PickUp item = hit.GetComponent<PickUp>();
			inventoryManager.Add( item );
			Destroy(hit.gameObject);
		}
	}
}
