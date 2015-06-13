using UnityEngine;
/* ----------------------------------------
 * class to demonstrate how to switch cameras
 * based on keyboard input
 */ 
public class CameraSwitch : MonoBehaviour {
	// A list of cameras from the scene
	public GameObject[] cameras;
	// A list of shortcuts. These are the keys that should be detected  
	public string[] shortcuts;
	// A boolean variable for whether the audiolistener of the selected camera should be enabled or not
	public bool  changeAudioListener = true;

	/* ----------------------------------------
	 * At Update, whenever the user presses a key from the 'shorcuts' list,
	 * the SwitchCamera function should be called, and the shortcut, passed.
	 */
	void  Update (){  
		if (Input.anyKeyDown) {
			// IF any key was pressed down, THEN read through the 'cameras' list
			for (int i=0; i<cameras.Length; i++) {  
				if (Input.GetKeyDown (shortcuts [i]))
					// IF the key pressed down is one from the 'cameras' list, THEN pass it to the SwitchCamera function
					SwitchCamera (i);
			}
		}
	}

	/* ----------------------------------------
	 * A function to enable the selected camera and disable every other camera in the scene
	 */
	void  SwitchCamera ( int index  ){
		// Read through the 'cameras' list
		for(int i = 0; i<cameras.Length; i++){  
			if(i != index){
				// IF the camera from the list is not the selected one, THEN disable its Camera component...
				cameras[i].GetComponent<Camera>().enabled = false;
				if(changeAudioListener)
					// ... AND IF the 'changeAudioListener' option is checked, THEN disable the camera's Audio Listener component
					cameras[i].GetComponent<AudioListener>().enabled = false;
			} else {
				// ELSE, IF the camera from the list is the selected one, THEN enable its Camera component...
				cameras[i].GetComponent<Camera>().enabled = true;
				if(changeAudioListener)
					// ... AND IF the 'changeAudioListener' option is checked, THEN enable the camera's Audio Listener component
					cameras[i].GetComponent<AudioListener>().enabled = true;
			}
		}
	}
}

