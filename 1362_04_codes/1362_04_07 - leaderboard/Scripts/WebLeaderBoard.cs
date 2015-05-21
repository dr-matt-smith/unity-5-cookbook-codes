// file: WebLeaderBoard.cs
using UnityEngine;
using System.Collections;
using System;

public class WebLeaderBoard : MonoBehaviour {
	public string leaderBoardURL = "http://localhost/leaderboard/index.php";
	private string url;
	private string action;
	private string parameters;
	private string textFileContents = "(still loading file ...)";

	private void OnGUI() {
		// hide closing tag
		string prettyText = textFileContents.Replace("</", "?@?"); 
		
		// prefix opening tag with newline
		prettyText = prettyText.Replace("<", "\n<"); 
		
		// return closing tag 
		prettyText = prettyText.Replace("?@?", "</"); 

		GUILayout.Label ( "last url = " + url );
		GUILayout.Label ( StringToInt(textFileContents) );
		GUILayout.Label ( "results from last url = " + prettyText );
		
		WebButtons();
	}
	
	private void WebButtons() {
		bool getButtonWasClicked = GUILayout.Button("Get score for player 'matt'");
		bool setButtonWasClicked = GUILayout.Button("Set score for player 'matt' to random integer 500-510");
		bool htmlButtonWasClicked = GUILayout.Button("Get html for all players");
		bool xmlButtonWasClicked = GUILayout.Button("Get xml for all players");
		bool resetButtonWasClicked = GUILayout.Button("Reset all scores");
		
		if( getButtonWasClicked )
			GetAction();
		if( setButtonWasClicked )
			SetAction();
		if( htmlButtonWasClicked )
			HTMLAction();
		if( xmlButtonWasClicked )
			XMLAction();
		if( resetButtonWasClicked )
			ResetAction();
	}
	
	private string StringToInt(string s) {
		string intMessage = "integer received = ";
		try{
			int integerReturned = Int32.Parse(s);
			intMessage += integerReturned;
		}
		catch(System.Exception e){
			intMessage += "(not an integer) ";
			print (e);
		}	
		return intMessage;
	}
	
	private void GetAction() {
		action = "get";
		parameters = "&player=matt";
		StartCoroutine( LoadWWW() );
	}

	private void SetAction() {
		int randomScore = UnityEngine.Random.Range(500, 510);
		parameters = "&player=matt&score=" + randomScore;
		action = "set";
		StartCoroutine( LoadWWW() );
	}

	private void HTMLAction() {
		action = "html";
		parameters = "";
		StartCoroutine( LoadWWW() );
	}

	private void XMLAction() {
		action = "xml";
		parameters = "";
		StartCoroutine( LoadWWW() );
	}

	private void ResetAction() {
		action = "reset";
		parameters = "";
		StartCoroutine( LoadWWW() );
	}

	private IEnumerator LoadWWW(){
		url = leaderBoardURL + "?action=" + action + parameters;
		WWW www = new WWW (url);
		yield return www;
	    textFileContents = www.text;
	}	
}