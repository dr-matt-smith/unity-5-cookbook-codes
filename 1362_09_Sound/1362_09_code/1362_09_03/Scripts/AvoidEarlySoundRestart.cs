using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AvoidEarlySoundRestart : MonoBehaviour
{
	// reference to AudioSource object
	// public - so assign in Inspector
	public AudioSource audioSource;

	// reference to UI Text object
	// public - so assign in Inspector
	public Text buttonText;

	//-------------------------------
	void Update()
	{
		// default text is 'Play sound'
		string statusMessage = "Play sound";

		// if sound is already playing, then change text to '(sound playing)'
		if(audioSource.isPlaying )
			statusMessage = "(sound playing)";

		// set UI button text to our text string
		buttonText.text = statusMessage;
	}

	//----------------------------------
	// button click handler
	public void PlaySoundIfNotPlaying()
	{
		// only send Play() message to AudioSource object
		// if sound is NOT currently playing
		if( !audioSource.isPlaying )
			audioSource.Play();
	}
}