using UnityEngine;
using System.Collections;
//Requires the AudioSource component
[RequireComponent(typeof(AudioSource))]

/* ----------------------------------------
 * class to demonstrate how to play a video texture
 */ 
public class PlayVideo : MonoBehaviour {

	// boolean variable for looping the video playback
	public bool loop = true;
	// boolean variable for start playing the video as soon as the level starts
	public bool playFromStart = true;
	// Movie Texture to be used
	public MovieTexture video;
	// Audio clip to be played
	public AudioClip audioClip;
	// variable for storing the object's AudioSource
	private AudioSource audio;

	/* ----------------------------------------
	 * At Start, set up movie texture and audio clip, 
	 * playing the video if required.  
	 */
	void Start () {
		// Assign AudioSource component to 'audio' variable
		audio = GetComponent<AudioSource> ();

		if (!video)
			// IF there is no Movie Texure assigned to 'video', THEN use the Movie Texture assigned to the material's main texture
			video = GetComponent<Renderer>().material.mainTexture as MovieTexture;

		if (!audioClip)
			// IF there is no Audio Clip assigned to 'audioClip', THEN use the audio clip assigned to object's Audio Source component
			audioClip = audio.clip;

		video.Stop ();

		audio.Stop ();

		// Assign 'loop' boolean value to Movie Texture's 'Loop' option 
		video.loop = loop;

		// Assign 'loop' boolean value to Audio Source 'Loop' option 
		audio.loop = loop;

		if(playFromStart)
			// IF 'playFromStart' is selected, THEN call ControlMovie function
			ControlMovie();
	}

	/* ----------------------------------------
	 * On MouseUp, call ControlMovie function
	  */	
	void OnMouseUp(){
		//Call ControlMovie function
		ControlMovie();	
	}


	/* ----------------------------------------
	 * Function playing/pausing movie
	  */
	public void ControlMovie(){
	
		if(video.isPlaying){		
			// IF Movie Texure is playing, THEN pause Movie Texture and Audio Clip 
			video.Pause();
			audio.Pause();
		} else {
			// ELSE, IF Movie Texure is not playing, THEN play Movie Texture and Audio Clip 
			video.Play();
			audio.Play();
		}
	}
}
