// file: SerialiseToXML.cs
using UnityEngine; 
using System.Collections; 
using System.Collections.Generic;

public class SerialiseToXML : MonoBehaviour {
	private string output = "(nothing yet)";
	
	void Start () { 
		SerializeManager<PlayerScore> serializer = new SerializeManager<PlayerScore>();
		PlayerScore myData = new PlayerScore("matt", 200);
		output = serializer.SerializeObject(myData);
	} 
 
	void OnGUI() {
		GUILayout.Label( output );
	}
} 