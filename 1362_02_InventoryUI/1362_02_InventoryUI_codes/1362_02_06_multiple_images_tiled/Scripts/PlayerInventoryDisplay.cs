using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInventoryDisplay : MonoBehaviour 
{
	public Image iconStarsYellow;
	
	public void OnChangeStarTotal(int starTotal){
		float newWidth = 100 * starTotal;
		iconStarsYellow.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidth);
	}
}
