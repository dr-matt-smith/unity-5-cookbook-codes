using UnityEngine;
using System.Collections;

public class RespawnWhenFall : MonoBehaviour {
	// variable to record the POSITION where our player object starts at
	// so we can reset the position back to this when he needs to respawn (e.g. when a life is lost)
	private Vector3 startPosition;

	void Start () {
		startPosition = transform.position;	
	}
	
	void Update () {
		if(transform.position.y < -10)
			Respawn();
	}

	void Respawn(){
		GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		transform.position = startPosition;
	}
}
