using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInventoryDisplay : MonoBehaviour 
{
	public Text starText;
	
	public void OnChangeCarryingStar(bool carryingStar){
		string starMessage = "no star :-(";
		if(carryingStar) starMessage = "Carrying star :-)";
		starText.text = starMessage;
	}
}
