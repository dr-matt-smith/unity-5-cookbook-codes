using UnityEngine;
using System.Collections;

public class PickupUI : MonoBehaviour
{
	// references to child yellow / grey star objects
	public GameObject starYellow;
	public GameObject starGrey;
	
	//------------------------------------
	// initially hide both yellow and grey stars
	void Awake()
	{
		DisplayEmpty();
	}
	
	//------------------------------------
	// hide grey, show yellow
	public void DisplayYellow()
	{
		starYellow.SetActive(true);
		starGrey.SetActive(false);
	}
	
	//------------------------------------
	// hide yellow, show grey
	public void DisplayGrey()
	{
		starYellow.SetActive(false);
		starGrey.SetActive(true);
	}

	//------------------------------------
	// hide both yellow and grey
	public void DisplayEmpty()
	{
		starYellow.SetActive(false);
		starGrey.SetActive(false);
	}
}
