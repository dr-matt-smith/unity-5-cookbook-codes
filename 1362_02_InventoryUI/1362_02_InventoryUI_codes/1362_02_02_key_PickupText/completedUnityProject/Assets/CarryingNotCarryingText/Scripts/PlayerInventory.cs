using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {
	private PlayerInventoryDisplay playerInventoryDisplay;
	private bool carryingStar = false;
	
	void Start(){
		playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
		playerInventoryDisplay.OnChangeCarryingStar(carryingStar);
	}
	
	void OnTriggerEnter2D(Collider2D hit){
		if(hit.CompareTag("Star")){
			carryingStar = true;
			playerInventoryDisplay.OnChangeCarryingStar(carryingStar);
			Destroy(hit.gameObject);
		}
	}
}
