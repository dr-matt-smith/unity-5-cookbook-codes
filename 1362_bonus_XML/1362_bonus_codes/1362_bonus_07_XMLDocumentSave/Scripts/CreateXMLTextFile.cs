// file: CreateXMLTextFile.cs
using UnityEngine;
using System.Collections;
using System.IO;

public class CreateXMLTextFile : MonoBehaviour {
	public string fileName = "playerData.xml";
	public string folderName = "Data";
	
	private void Start() {
		string filePath = Path.Combine( Application.dataPath, folderName);
		filePath = Path.Combine( filePath, fileName);

		PlayerXMLWriter myPlayerXMLWriter = new PlayerXMLWriter(filePath);
		myPlayerXMLWriter.AddXMLElement("matt", "55");
		myPlayerXMLWriter.AddXMLElement("jane", "99");
		myPlayerXMLWriter.AddXMLElement("fred", "101");
		myPlayerXMLWriter.SaveXMLFile();
		
		print( "XML file should now have been created at: " + filePath);
	}
}