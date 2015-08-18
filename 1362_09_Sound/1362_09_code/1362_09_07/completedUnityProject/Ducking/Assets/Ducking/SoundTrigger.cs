// file: PlayDestroyButtonGUI.cs
using UnityEngine;
using System.Collections;

public class SoundTrigger : MonoBehaviour{
	
	private void OnTriggerEnter(Collider other){

		gameObject.GetComponent<AudioSource>().Play();


	}
}
