using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	private PlayerInventoryDisplay playerInventoryDisplay;
	private List<PickUp> inventory = new List<PickUp>();
	
	void Start(){
		playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
		playerInventoryDisplay.OnChangeInventory(inventory);
	}
	
	void OnTriggerEnter2D(Collider2D hit){
		if(hit.CompareTag("Pickup")){
			PickUp item = hit.GetComponent<PickUp>();
			inventory.Add( item );
			playerInventoryDisplay.OnChangeInventory(inventory);
			Destroy(hit.gameObject);
		}
	}
}
