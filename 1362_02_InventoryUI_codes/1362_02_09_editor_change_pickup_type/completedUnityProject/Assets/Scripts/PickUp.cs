using UnityEngine;
using System;
using System.Collections;

public class PickUp : MonoBehaviour {
	public enum PickUpType {
		Star, Health, Key
	}
	
	[SerializeField]
	public PickUpType type;
	
	public void SetSprite(Sprite newSprite){
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = newSprite;
	}
}
