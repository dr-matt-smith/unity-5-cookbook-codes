using UnityEngine;
using System.Collections;

public class ReadDefaultResources_text : MonoBehaviour {
	public string fileName = "textFileName";
	private string textFileContents;

	void Start () {
		// load text from texternal file into a Textasset object
		TextAsset textAsset = (TextAsset)Resources.Load(fileName);

		// extract the text content from 'textAsset' and store in string variable 'textFileContents'
		textFileContents = textAsset.text;

		// output string to the Console panel
		Debug.Log(textFileContents);
	}
}
