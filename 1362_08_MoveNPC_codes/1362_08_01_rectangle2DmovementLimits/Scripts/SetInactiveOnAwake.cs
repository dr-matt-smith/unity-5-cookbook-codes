using UnityEngine;
using System.Collections;

public class SetInactiveOnAwake : MonoBehaviour {

	void Awake(){
		gameObject.SetActive(false);
	}
}
