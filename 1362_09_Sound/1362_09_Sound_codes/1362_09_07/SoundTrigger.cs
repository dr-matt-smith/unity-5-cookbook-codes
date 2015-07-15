// file: SoundTrigger.cs
using UnityEngine;
using System.Collections;

/* ----------------------------------------
 * class to demonstrate how to trigger the sound clip 
 * from an AudioSource component
 */ 
public class SoundTrigger : MonoBehaviour{

	/* ----------------------------------------
	 * Whenever something enters this game object's trigger collider , 
	 *  Play the audio clip from the AudioSource component
	 */
	private void OnTriggerEnter(Collider other){
		// Plays the audio clip from the AudioSource component of the game object 
		gameObject.GetComponent<AudioSource>().Play();


	}
}
