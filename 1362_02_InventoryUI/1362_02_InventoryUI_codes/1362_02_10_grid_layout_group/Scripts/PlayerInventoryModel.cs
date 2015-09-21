using UnityEngine;
using System.Collections;

public class PlayerInventoryModel : MonoBehaviour
{
	private int starTotal = 0;
	private PlayerInventoryDisplay playerInventoryDisplay;

	//----------------------------------
	// get reference to display scripted instance object
	// and tell it to display the inital 'starTotal'
	void Start()
	{
		playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
		playerInventoryDisplay.OnChangeStarTotal(starTotal);
	}

	//----------------------------------
	// when we add a star, we add to the total
	// and tell the display system to display that many yellow stars
	public void AddStar()
	{
		starTotal++;
		playerInventoryDisplay.OnChangeStarTotal(starTotal);
	}
}
