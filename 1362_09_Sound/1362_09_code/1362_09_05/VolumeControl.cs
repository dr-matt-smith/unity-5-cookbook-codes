// file: VolumeControl.cs
using UnityEngine;
// Include UnityEngine.Audio for the AudioMixer
using UnityEngine.Audio;
using System.Collections;

/* ----------------------------------------
 * class to demonstrate how to change the sound volume of Audio Mixers through GUI and script.
 * This script should be attached to the GUI game object.
 */ 
public class VolumeControl : MonoBehaviour
{
	// A variable where to assign our Audio Mixer to
	public AudioMixer myMixer;

	// A GameObject variable to give us access to the GUI Panel
	private GameObject panel;

	// Boolean variable to determine whether the game is paused or not;
	private bool isPaused = false;

	/* ----------------------------------------
	 * At Start, assign the Panel game object to our 'panel' variable and make it inactive.
	 */ 
	void Start()
	{
		// Populate 'panel'variable with Panel game object
		panel = GameObject.Find("Panel");

		// Set 'panel' as inactive, hiding the volume control sliders
        panel.SetActive(false);
	}

	/* ----------------------------------------
	 * Whenever the Escape key is pressed, 
	 * enable/disable the GUI panel and pause/unpause the game 
	 */
	void Update()
	{
		if (Input.GetKeyUp (KeyCode.Escape)) {
			// IF the Escape key is hit, THEN invert active/inactive status for the GUI Panel
			panel.SetActive(!panel.activeInHierarchy);

			if(isPaused)
				// IF game is paused, THEN set time scale as 1, to unpause it
				Time.timeScale = 1.0f;
			else
				// ELSE, if game is not paused, THEN set time scale as 0, to pause it
				Time.timeScale = 0.0f;

			// Update isPaused boolean by inverting its value 
			isPaused = !isPaused;
		}		
	}	

	/* ----------------------------------------
	 * A function for changing the Volume of the music
	 * The function receives a float value as the new volume level
	 */
	public void ChangeMusicVol(float vol)
	{
		// Assigns to the exposed parameter 'MusicVolume' a new volume level, converted from linear to decibels
		myMixer.SetFloat ("MusicVolume", Mathf.Log10(vol) * 20f);
	}

	/* ----------------------------------------
	 * A function for changing the Volume of sound effects
	 * The function receives a float value as the new volume level
	 */
	public void ChangeFxVol(float vol)
	{
		// Assigns to the exposed parameter 'FxVolume' a new volume level, converted from linear to decibels
		myMixer.SetFloat ("FxVolume", Mathf.Log10(vol) * 20f);
	}

	/* ----------------------------------------
	 * A function for changing the Overall Volume 
	 * The function receives a float value as the new volume level
	 */
	public void ChangeOverallVol(float vol)
	{
		// Assigns to the exposed parameter 'OverallVolume' a new volume level, converted from linear to decibels
		myMixer.SetFloat ("OverallVolume", Mathf.Log10(vol) * 20f);
	}
}

