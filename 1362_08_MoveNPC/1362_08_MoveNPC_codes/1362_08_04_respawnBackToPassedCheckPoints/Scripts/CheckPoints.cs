using UnityEngine;
using System.Collections;

public class CheckPoints : MonoBehaviour {
	// position to respawn to
	private Vector3 respawnPosition;

	/*----------------------------------------------------------*/
	// cache current position of parent GameObject
	void Start ()
	{
		respawnPosition = transform.position;
	}

	/*----------------------------------------------------------*/
	// if we hit 'Checkpoint', then cache current position
	// if we hit 'Death' respawn us to last stored position
	void OnTriggerEnter (Collider hit)
	{
		if(hit.CompareTag("CheckPoint")){
			respawnPosition = transform.position;
		}
		
		if(hit.CompareTag("Death")){
			transform.position = respawnPosition;
		}
	}
}
