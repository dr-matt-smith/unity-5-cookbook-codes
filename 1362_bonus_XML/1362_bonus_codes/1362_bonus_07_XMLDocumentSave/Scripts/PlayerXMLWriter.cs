// file: PlayerXMLWriter.cs
using System.Text;
using System.Xml;
using System.IO;

public class PlayerXMLWriter {
	private string _filePath;
	private XmlDocument _xmlDoc;
	private XmlElement _elRoot;
	
	public PlayerXMLWriter(string filePath) {
		_filePath = filePath;
		_xmlDoc = new XmlDocument();
		
		if(File.Exists (_filePath)) {
			_xmlDoc.Load(_filePath);
			_elRoot = _xmlDoc.DocumentElement;
			_elRoot.RemoveAll();
		}
		else {
			_elRoot  = _xmlDoc.CreateElement("playerScoreList");
			_xmlDoc.AppendChild(_elRoot);			
		}
	}
	
	public void SaveXMLFile() {
		_xmlDoc.Save(_filePath);
	}
	
	public void AddXMLElement(string playerName, string playerScore) {
		XmlElement elPlayer = _xmlDoc.CreateElement("playerScore");
		_elRoot.AppendChild(elPlayer);

		XmlElement elName = _xmlDoc.CreateElement("name");
		elName.InnerText = playerName;
		elPlayer.AppendChild(elName);

		XmlElement elScore = _xmlDoc.CreateElement("score");
		elScore.InnerText = playerScore;
		elPlayer.AppendChild(elScore);
	}
}