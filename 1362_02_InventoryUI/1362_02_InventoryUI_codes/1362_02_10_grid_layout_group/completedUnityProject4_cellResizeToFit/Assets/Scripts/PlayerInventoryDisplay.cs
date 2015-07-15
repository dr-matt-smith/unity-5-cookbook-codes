using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInventoryDisplay : MonoBehaviour 
{
	const int NUM_INVENTORY_SLOTS = 15;
	private PickupUI[] slots = new PickupUI[NUM_INVENTORY_SLOTS];
	public GameObject slotGrid;
	public GameObject starSlotPrefab;
	
	void Awake(){
		// resize grid layout group cellsize
		float panelWidth = slotGrid.GetComponent<RectTransform>().rect.width;
		GridLayoutGroup gridLayoutGroup = slotGrid.GetComponent<GridLayoutGroup>();
		float xCellSize = panelWidth / NUM_INVENTORY_SLOTS;
		xCellSize -= gridLayoutGroup.spacing.x;
		gridLayoutGroup.cellSize = new Vector2(xCellSize, xCellSize);
		
		// create starSlot game objects as before
		for(int i=0; i < NUM_INVENTORY_SLOTS; i++){
			GameObject starSlotGO = (GameObject)Instantiate(starSlotPrefab);
			starSlotGO.transform.SetParent(slotGrid.transform);
			
			slots[i] = starSlotGO.GetComponent<PickupUI>();
		}
	}

	public void OnChangeStarTotal(int starTotal){
		for(int i = 0; i < NUM_INVENTORY_SLOTS; i++){
			PickupUI slot = slots[i];
			if(i < starTotal)
				slot.DisplayYellow();
			else
				slot.DisplayGrey();
		}
	}
}
