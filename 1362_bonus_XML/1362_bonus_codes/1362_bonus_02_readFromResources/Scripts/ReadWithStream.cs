// file: ReadWithStream.cs
using UnityEngine;
using System.Collections;
using System.IO;

public class ReadWithStream : MonoBehaviour {
	private string filePath = "";
	private string textFileContents = "(file not found yet)";	
	private FileReadWriteManager fileReadWriteManager = new FileReadWriteManager();

	private void Start () {
		string fileName = "cities.txt";
	 	filePath = Path.Combine(Application.dataPath, "Resources");
	 	filePath = Path.Combine(filePath, fileName);
		
		textFileContents = fileReadWriteManager.ReadTextFile( filePath );
	}
	
	private void OnGUI() {
		GUILayout.Label ( filePath );
		GUILayout.Label ( textFileContents );
	}
}