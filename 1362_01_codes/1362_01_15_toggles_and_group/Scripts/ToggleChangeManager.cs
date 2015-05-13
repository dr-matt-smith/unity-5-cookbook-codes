using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleChangeManager : MonoBehaviour {
	private Toggle toggle;

	void Start () {
		toggle = GetComponent<Toggle>();	
	}

	public void PrintNewToggleValue(){
		bool status = toggle.isOn;
		print ("toggle status = " + status);
	}

}
