using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InactiveWhenNotVisible : MonoBehaviour {
	// button action
	public void BUTTON_ACTION_MakeActive(){
		gameObject.SetActive(true);
		makeActiveAgainButton.SetActive(false);
	}
	
	public GameObject makeActiveAgainButton;

	private GameObject player;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void OnBecameInvisible() {
		gameObject.SetActive(false);
		makeActiveAgainButton.SetActive(true);
		print ("cube became invisible");
	}

	void Update(){
		//do something, so we know when this script is NOT doing something!
		float d = Vector3.Distance( transform.position, player.transform.position);
		print(Time.time + ": distance from player to cube = " + d);
	}
}
