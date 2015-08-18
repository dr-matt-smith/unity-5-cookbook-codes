using UnityEngine;
using System.Collections;

public class AudioDestructBehaviour : MonoBehaviour {
	private AudioSource audioSource;

	void Start(){
		audioSource = GetComponent<AudioSource>();
	}

	private void Update(){
		if( !audioSource.isPlaying )
			Destroy(gameObject);
	}
}
