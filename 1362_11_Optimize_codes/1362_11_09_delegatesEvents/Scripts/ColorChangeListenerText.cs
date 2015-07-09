using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorChangeListenerText : MonoBehaviour {
	void OnEnable() {
		ColorManager.onChangeColor += ChangeColorEvent;
	}
	
	private void OnDisable(){
		ColorManager.onChangeColor -= ChangeColorEvent;
	}

	void ChangeColorEvent(Color newColor){
		GetComponent<Text>().color = newColor;
	}
}
