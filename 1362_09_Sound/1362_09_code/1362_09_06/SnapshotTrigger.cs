// file: SnapshotTrigger.cs
using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

/* ----------------------------------------
 * class to demonstrate how to transition between 
 * Audio mixer Snapshots, making a dynamic soundtrack possible
 */ 
public class SnapshotTrigger : MonoBehaviour{
	// A variable for storing the Snapshot we'd like to make a transition to
	public AudioMixerSnapshot snapshot;
	// A float variable for the time (in seconds) that the crossfade between snapshots weill take
	public float crossfade;

	/* ----------------------------------------
	 * Whenever something enters this game object's trigger collider , 
	 *  make a transition to our 'snapshot'
	 */
	private void OnTriggerEnter(Collider other){
		// Make a transition to our 'snapshot' in 'crossfade' seconds
		snapshot.TransitionTo (crossfade);
	}
}
