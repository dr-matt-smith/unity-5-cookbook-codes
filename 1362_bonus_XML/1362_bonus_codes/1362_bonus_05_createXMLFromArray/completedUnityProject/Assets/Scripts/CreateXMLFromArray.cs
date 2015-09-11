// file: CreateXMLFromArray.cs
using UnityEngine;
using System.Collections;

public class CreateXMLFromArray : MonoBehaviour {
	private string output = "(nothing yet)";
	private ArrayList myPlayerList;

	private void Start () {
		myPlayerList = new ArrayList();
		myPlayerList.Add (new PlayerScore("matt", 200) );
		myPlayerList.Add (new PlayerScore("jane", 150) );
		
		output = PlayerScore.ListToXML( myPlayerList );
	}
	
	private void OnGUI() {
		GUILayout.Label( output );
	}
}