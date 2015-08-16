using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {
	private GameObject probe; 
	private UpdateProbe up;
	void Awake(){
		probe = GameObject.Find("OnDemandProbe");
		up = probe.GetComponent<UpdateProbe>();
	}

	void Update () {
		if (Input.anyKeyDown) {
			// IF any key is down, THEN assign the object's euler angles to a Vector3 variable named newRotation...
			Vector3 newRotation = transform.eulerAngles;
			// Set a random value between 0 and 360 as the newRotation.y
			newRotation.y = Random.Range(0F, 360F);
			// Update the object's euler angle with the values from newRotation (now including a random Y angle)
			transform.eulerAngles = newRotation; 
			up.RefreshProbe();
		}
	}
}
