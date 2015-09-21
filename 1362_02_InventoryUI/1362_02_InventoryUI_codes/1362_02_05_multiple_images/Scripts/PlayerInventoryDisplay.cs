using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * class to indicate to user how many stars are being carried by the suer
 *
 * this is acheived by displaying yellow stars (for how many being carried)
 * and grey stars for any remaining placehold UI images on screeen
 */
public class PlayerInventoryDisplay : MonoBehaviour 
{
	// array of references to UI Images on screen
	// public - so has to be set up via drag and drop in the Inspector
	public Image[] starPlaceholders;

	// reference to yellow star image
	public Sprite iconStarYellow;

	// reference to grey star image
	public Sprite iconStarGrey;

	//----------------------
	// loop showing 'starTotal' yellow stars
	// and any remaining as grey stars
	//
	// e.g. if 5 Images in array, and 'starTotal' is 2
	// i=0: show YELLOW
	// i=1: show YELLOW
	// i=2: show GREY
	// i=3: show GREY
	// i=4: show GREY
	//
	// so while i < 'starTotal' we show yellow stars to show the right amount
	public void OnChangeStarTotal(int starTotal)
	{
		// loop for all the UI Images in the array
		for (int i = 0;i < starPlaceholders.Length; ++i){
			// IF current loop index is less than stars we are carrying
			// THEN make current UI Image show a yellow star
			// ELSE display a grey star
			if (i < starTotal)
				starPlaceholders[i].sprite = iconStarYellow;
			else
				starPlaceholders[i].sprite = iconStarGrey;
		}
	}
}
