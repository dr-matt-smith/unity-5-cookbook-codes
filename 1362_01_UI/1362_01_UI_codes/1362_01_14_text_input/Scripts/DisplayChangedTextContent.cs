using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayChangedTextContent : MonoBehaviour
{
	// a reference to the UI input field
	private InputField inputField;

	// get reference to the InputField component
	// of the parent GameObject
	void Start()
	{
		inputField = GetComponent<InputField>();
	}

	// print to Console the current value of the input field
	// this will be called each time the InputField receives an 'EndEdit' event message
	public void PrintNewValue ()
	{
		string msg = "new content = '" + inputField.text + "'";
		print (msg);
	}
}
