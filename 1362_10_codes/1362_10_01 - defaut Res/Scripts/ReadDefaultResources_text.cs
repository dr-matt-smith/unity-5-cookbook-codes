using UnityEngine;
using System.Collections;

public class ReadDefaultResources_text : MonoBehaviour {
	public string fileName = "textFileName";
	private string textFileContents;

	void Start () {
		TextAsset textAsset = (TextAsset)Resources.Load(fileName);
		textFileContents = textAsset.text;
		Debug.Log(textFileContents);
	}
}
