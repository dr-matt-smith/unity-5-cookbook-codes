using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	private PlayerInventoryModel playerInventoryModel;
	
	void Start(){
		playerInventoryModel = GetComponent<PlayerInventoryModel>();
	}
	
	void OnTriggerEnter2D(Collider2D hit){
		if(hit.CompareTag("Star")){
			playerInventoryModel.AddStar();
			Destroy(hit.gameObject);
		}
	}
}
