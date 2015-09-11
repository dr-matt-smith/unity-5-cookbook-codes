// file: ParseXML.cs
using UnityEngine;
using System.Collections;

using System.Xml;
using System.IO;

public class ParseXML : MonoBehaviour {
	public TextAsset scoreDataTextFile;
	
	private void Start() {
		string textData = scoreDataTextFile.text;
		ParseScoreXML( textData );
	}
	
	private void ParseScoreXML(string xmlData) {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load( new StringReader(xmlData) );
		
		string xmlPathPattern = "//scoreRecordList/scoreRecord";
		XmlNodeList myNodeList = xmlDoc.SelectNodes( xmlPathPattern );

		foreach(XmlNode node in myNodeList)
			print ( ScoreRecordString( node ) );
	}
	
	private string ScoreRecordString(XmlNode node) {
		XmlNode playerNode = node.FirstChild;
		XmlNode scoreNode = playerNode.NextSibling;
		XmlNode dateNode = scoreNode.NextSibling;
		
		return "Player = " + playerNode.InnerXml + ", score = " + scoreNode.InnerXml + ", date = " + DateString( dateNode );		
	}
	
	private string DateString(XmlNode dateNode) {
		XmlNode dayNode = dateNode.FirstChild;
		XmlNode monthNode = dayNode.NextSibling;
		XmlNode yearNode = monthNode.NextSibling;	
		
		return dayNode.InnerXml + "/" + monthNode.InnerXml + "/" + yearNode.InnerXml;
	}	
}
