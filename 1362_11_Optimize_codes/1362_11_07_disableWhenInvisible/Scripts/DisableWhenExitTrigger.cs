using UnityEngine;
using System.Collections;

public class DisableWhenExitTrigger : MonoBehaviour {
	private GameObject player;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void OnTriggerEnter(Collider hitObjectCollider) {
		if (hitObjectCollider.CompareTag("Player")){
			print ("cube close to Player again");
			enabled = true;
		}
	}
	
	void OnTriggerExit(Collider hitObjectCollider) {
		if (hitObjectCollider.CompareTag("Player")){
			print ("cube away from Player");
			enabled = false;
		}
	}

	void Update(){
		//do something, so we know when this script is NOT doing something!
		float d = Vector3.Distance( transform.position, player.transform.position);
		print(Time.time + ": distance from player to cube = " + d);
	}
}
