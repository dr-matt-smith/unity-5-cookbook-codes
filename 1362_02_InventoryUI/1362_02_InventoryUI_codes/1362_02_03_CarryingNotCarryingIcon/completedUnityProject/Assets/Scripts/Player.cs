using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public Image starImage;
	public Sprite iconStar;
	public Sprite iconNoStar;
	private bool carryingStar = false;
	
	void OnTriggerEnter2D(Collider2D hit){
		if(hit.CompareTag("Star")){
			carryingStar = true;
			UpdateStarImage();
			Destroy(hit.gameObject);
		}
	}
	
	private void UpdateStarImage(){
		if(carryingStar)
			starImage.sprite = iconStar;
		else 
			starImage.sprite = iconNoStar;
	}
}
