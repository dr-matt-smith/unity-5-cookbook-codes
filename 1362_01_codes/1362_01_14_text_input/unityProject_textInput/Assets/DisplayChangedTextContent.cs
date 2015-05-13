using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayChangedTextContent : MonoBehaviour {
	private InputField inputField;

	void Start(){
		inputField = GetComponent<InputField>();
	}

	public void PrintNewValue (){
		string msg = "new content = '" + inputField.text + "'";
		print (msg);
	}
}
