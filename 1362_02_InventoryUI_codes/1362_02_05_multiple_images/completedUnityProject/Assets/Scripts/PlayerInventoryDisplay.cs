using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInventoryDisplay : MonoBehaviour 
{
	public Image star0Image;
	public Image star1Image;
	public Image star2Image;
	public Image star3Image;
	
	public Sprite iconStarYellow;
	public Sprite iconStarGrey;
	
	public void OnChangeStarTotal(int starTotal){
		switch(starTotal){
		case 4:
			star0Image.sprite = iconStarYellow;
			star1Image.sprite = iconStarYellow;
			star2Image.sprite = iconStarYellow;
			star3Image.sprite = iconStarYellow;
			break;
		case 3:
			star0Image.sprite = iconStarYellow;
			star1Image.sprite = iconStarYellow;
			star2Image.sprite = iconStarYellow;
			break;
		case 2:
			star0Image.sprite = iconStarYellow;
			star1Image.sprite = iconStarYellow;
			break;
		case 1:
			star0Image.sprite = iconStarYellow;
			break;
		case 0:
		default:
			// do nothing - leave stars at default grey
			break;
		}
	}
}
