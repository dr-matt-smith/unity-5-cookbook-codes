using UnityEngine;
using System.Collections;

public class PickupUI : MonoBehaviour {
	public GameObject starYellow;
	public GameObject starGrey;
	
	void Awake(){
		DisplayEmpty();
	}
	
	public void DisplayYellow(){
		starYellow.SetActive(true);
		starGrey.SetActive(false);
	}
	
	public void DisplayGrey(){
		starYellow.SetActive(false);
		starGrey.SetActive(true);
	}
	
	public void DisplayEmpty(){
		starYellow.SetActive(false);
		starGrey.SetActive(false);
	}
}
