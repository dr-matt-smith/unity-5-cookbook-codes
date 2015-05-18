using UnityEngine;
using System.Collections;

public class RespawnWhenFall : MonoBehaviour {
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
