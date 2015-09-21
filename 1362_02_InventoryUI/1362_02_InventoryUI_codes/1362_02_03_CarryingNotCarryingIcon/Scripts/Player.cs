using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	// reference to a UI image on screen
	public Image starImage;

	// reference to image of icon indicating player IS carrying a star
	public Sprite iconStar;

	// reference to image of icon indicating player is NOT carrying a star
	public Sprite iconNoStar;

	// flag to indicate if player is carrying a star or not
	private bool carryingStar = false;

	//--------------------------------
	void OnTriggerEnter2D(Collider2D hit)
	{
		// IF we hit something tagged 'Star'
		if(hit.CompareTag("Star")){
			// set our flag to TRUE
			carryingStar = true;

			// call method to update the image displyed to user
			UpdateStarImage();

			// destroy the star object that we collided with
			Destroy(hit.gameObject);
		}
	}

	//----------------------------
	// if we are carrying star display image 'iconStar'
	// else display image 'iconNoStar'
	private void UpdateStarImage()
	{
		if(carryingStar)
			starImage.sprite = iconStar;
		else 
			starImage.sprite = iconNoStar;
	}
}
