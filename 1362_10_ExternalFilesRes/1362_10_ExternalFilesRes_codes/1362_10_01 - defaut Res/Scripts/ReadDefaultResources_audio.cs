using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class ReadDefaultResources_audio : MonoBehaviour {
	public string fileName = "soundtrack";
	private AudioSource audioSource;
	
	void  Start (){
		audioSource = GetComponent<AudioSource>();

		// load audio from external file and store in AudioSource component
		audioSource.clip = (AudioClip)Resources.Load(fileName);

		// if no sound player, and clip fully loaded, then Play() the clip in the AudioSource
		if(!audioSource.isPlaying && audioSource.clip.isReadyToPlay)
			audioSource.Play();
	}
}