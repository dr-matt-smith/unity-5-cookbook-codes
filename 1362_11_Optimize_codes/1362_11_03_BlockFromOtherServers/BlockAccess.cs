// file: BlockAccess
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/* ----------------------------------------
 * class to demonstrate how to prevent a webgame made with unity 
 * from running on unknown servers
 */ 
public class BlockAccess : MonoBehaviour {
	// Boolean variable. Set as 'true' to turn this script's functionality on
	public bool checkDomain = true;

	// Boolean variable. Set as 'true' if using the game's full URL, from "http:" to ".unity3d) 
	public bool fullURL = true;

	// String Array for entering valid URLs for the game to be located at  
	public string[] domainList;

	// String variable for entering the message to be displayed when blocking access to the game
	public string warning;

	/* ----------------------------------------
	 * At Start, detect if the game is running on a browser, 
	 * identify URL and compare to allowed URLs, blocking access
	 * if necessary.
	 */ 
	private void Start(){
		// Text component from the UI Text game object
		Text scoreText = GetComponent<Text>();

		// Boolean variable for illegitimacy of the URL. Initially set as 'true'. 
		bool illegalCopy = true;

        if (Application.isEditor)
            // IF game runs from editor for testing purposes, THEN set illegalCopy as 'false' 
            illegalCopy = false;

		if (Application.isWebPlayer && checkDomain){
			// IF game runs on browser and checkDomain is set as 'true', THEN run 'for' loop through list of valid URLs
			for (int i = 0; i < domainList.Length; i++){
				if (Application.absoluteURL == domainList[i]){
					// IF game's URL matches address on the Domain List, THEN set illegalCopy as 'false'
					illegalCopy = false;
				}else if (Application.absoluteURL.Contains(domainList[i]) && !fullURL){
					// IF there is no need for the full URL and game's URL contains part of address on the Domain List, THEN set illegalCopy as 'false'
					illegalCopy = false;
				}
			}
		}

		if (illegalCopy)
			// IF the game is not at a valid URL, THEN set the warning message as text for the UI Text element 
			scoreText.text = warning;
		else
			// ELSE, if game is at a valid URL, play next level of the game
			Application.LoadLevel(Application.loadedLevel + 1);
	}
}
