using UnityEngine;
using System.Collections;

public class PlayerInventoryModel : MonoBehaviour {
	private int starTotal = 0;
	private PlayerInventoryDisplay playerInventoryDisplay;
	
	void Start(){
		playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
		playerInventoryDisplay.OnChangeStarTotal(starTotal);
	}
	
	public void AddStar(){
		starTotal++;
		playerInventoryDisplay.OnChangeStarTotal(starTotal);
	}
}
