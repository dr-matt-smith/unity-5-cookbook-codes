using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorChangeListenerImage : MonoBehaviour {
	void OnEnable() {
		ColorManager.onChangeColor += ChangeColorEvent;
	}
	
	private void OnDisable(){
		ColorManager.onChangeColor -= ChangeColorEvent;
	}

	void ChangeColorEvent(Color newColor){
			GetComponent<Image>().color = newColor;
	}
}