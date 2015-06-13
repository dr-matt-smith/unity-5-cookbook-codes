using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class ReadDefaultResources_audio : MonoBehaviour {
	public string fileName = "soundtrack";
	private AudioClip audioFile;
	private AudioSource audioSource;
	
	void  Start (){
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = (AudioClip)Resources.Load(fileName);
		if(!audioSource.isPlaying && audioSource.clip.isReadyToPlay)
			audioSource.Play();
	}
}