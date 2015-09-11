// file: PlayerScore.cs
using System.Collections;
using System.Xml;
using System.IO;

public class PlayerScore {	
	private string _name;
	private int _score;
	
	public PlayerScore(string name, int score) {
		_name = name;
		_score = score;
	}

	// class method
	static public string ListToXML(ArrayList playerList) {
		StringWriter str = new StringWriter();
		XmlTextWriter xml = new XmlTextWriter(str);
		
		// start doc and root el.
	    xml.WriteStartDocument();
		xml.WriteStartElement("playerScoreList");

		// add elements for each object in list
	    foreach (PlayerScore playerScoreObject in playerList) {
			playerScoreObject.ObjectToElement( xml );
	    }
	
		// end root and document
	    xml.WriteEndElement();
	    xml.WriteEndDocument();

	    return str.ToString();
	}
	
	private void ObjectToElement(XmlTextWriter xml) {
		// data element
		xml.WriteStartElement("player");
		xml.WriteElementString("name", _name);
		string scoreString = "" + _score; // make _score a string
	    xml.WriteElementString("score", scoreString);
		xml.WriteEndElement();		
	}	
}
