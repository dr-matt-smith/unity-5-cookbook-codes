// file: SaveTextFile.cs
using UnityEngine; 
using System.Collections; 
using System.IO; 

public class SaveTextFile : MonoBehaviour {
	public string fileName = "hello.txt";
	public string folderName = "Data";
	private string filePath = "(no file path yet)";
	private string message = "(trying to save data)";
	private FileReadWriteManager fileManager;
	
	void Start () { 
		fileManager = new FileReadWriteManager();
	 	filePath = Path.Combine(Application.dataPath, folderName);
	 	filePath = Path.Combine(filePath, fileName);
		
		string textData = "hello \n and goodbye";
		fileManager.WriteTextFile( filePath, textData ); 
		
		message = "file should have been written now ...";
	} 
 
   void OnGUI() 
   {    
		GUILayout.Label("filepath = " + filePath);
		GUILayout.Label("message = " + message);
	}
} 