using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
	public enum PickUpType {
		Star, Key, Heart
	}
	
	public PickUpType type;
}
