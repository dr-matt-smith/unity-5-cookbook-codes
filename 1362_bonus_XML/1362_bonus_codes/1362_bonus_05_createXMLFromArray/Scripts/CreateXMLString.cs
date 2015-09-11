// file: CreateXMLString.cs
using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;

public class CreateXMLString : MonoBehaviour {
	private string output = "(nothing yet)";
	
	private void Start () {
		output = BuildXMLString();
	}
	
	private void OnGUI() {
		GUILayout.Label( output );
	}
	
	private string BuildXMLString() {
		StringWriter str = new StringWriter();
		XmlTextWriter xml = new XmlTextWriter(str);
		
		// start doc and root el.
	    xml.WriteStartDocument();
		xml.WriteStartElement("playerScoreList");
		
		// data element
		xml.WriteStartElement("player");
		xml.WriteElementString("name", "matt");
	    xml.WriteElementString("score", "200");
		xml.WriteEndElement();
	
		// data element
		xml.WriteStartElement("player");
		xml.WriteElementString("name", "jane");
	    xml.WriteElementString("score", "150");
		xml.WriteEndElement();
	
		// end root and document
	    xml.WriteEndElement();
	    xml.WriteEndDocument();

	    return str.ToString();
	}
}