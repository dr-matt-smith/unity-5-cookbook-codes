using UnityEngine;
using System;
using System.Collections;

public class PickUp : MonoBehaviour
{
	/*----------------------------------------------
	 * define the 3 kinds of pickup
	 */
	public enum PickUpType
	{
		Star, Health, Key
	}

	// this instruciton is required for private variables
	// but optional for public ones
	// allows editor to save changes made at design-time
	//
	// 'type' is the type of pickup for the parent GameObject of each instance of this class
	[SerializeField]
	public PickUpType type;

	/*----------------------------------------------
	 * change the displayed sprite for the paraent GameObject
	 */
	public void SetSprite(Sprite newSprite)
	{
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = newSprite;
	}
}
