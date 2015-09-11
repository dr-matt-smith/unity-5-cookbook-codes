// file: ReadPublicTextAsset.cs
using UnityEngine;
using System.Collections;

public class ReadPublicTextAsset : MonoBehaviour {
	public TextAsset dataTextFile;
	private string textData = "";
	
	private void Start() {
		textData = dataTextFile.text;
	}
	
	private void OnGUI() {
		GUILayout.Label ( textData );
	}
}
