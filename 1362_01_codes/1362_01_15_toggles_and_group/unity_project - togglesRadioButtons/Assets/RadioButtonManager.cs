using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RadioButtonManager : MonoBehaviour {
	private string currentDifficulty = "easy";

	public void PrintNewGroupValue(Toggle sender){
		// only take notice from Toggle just swtiched to On
		if(sender.isOn){
			currentDifficulty = sender.tag;
			print ("option changed to = " + currentDifficulty);
		}
	}
}
