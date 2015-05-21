// file: WebLeaderBoard.cs
using UnityEngine;
using System.Collections;
using System;

using UnityEngine.UI;

public class WebLeaderBoard : MonoBehaviour {
	public Text ui_lastURL;
	public Text ui_lastURLValue;
	public Text ui_textFile;

	public string leaderBoardURL = "http://localhost/leaderboard/index.php";
	private string url = "(empty)";
	private string action;
	private string parameters;
	private string textFileContents = "(still loading file ...)";

	void Start(){
		UpdateUI();
	}

	private void UpdateUI() {
		ui_lastURL.text = "LAST URL = " + url;
		ui_lastURLValue.text = StringToInt(textFileContents);
		ui_textFile.text = MakePretty(textFileContents);
	}

	private string MakePretty(string s){

		// hide closing tag
		string prettyText = s.Replace("</", "?@?"); 
		
		// prefix opening tag with newline
		prettyText = prettyText.Replace("<", "\n<"); 
		
		// return closing tag 
		prettyText = prettyText.Replace("?@?", "</"); 

		return prettyText;

		/*
		GUILayout.Label ( "last url = " + url );
		GUILayout.Label ( StringToInt(textFileContents) );
		GUILayout.Label ( "results from last url = " + prettyText );
		
		WebButtons();
		*/
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
//			print (e);
		}	
		return intMessage;
	}

	
	private IEnumerator LoadWWW(){
		url = leaderBoardURL + "?action=" + action + parameters;
		WWW www = new WWW (url);
		yield return www;
		textFileContents = www.text;
		UpdateUI();
	}
	
	//
	// public button Methods
 	//
	public void GetAction() {
		action = "get";
		parameters = "&player=matt";
		StartCoroutine( LoadWWW() );
	}

	public void SetAction() {
		int randomScore = UnityEngine.Random.Range(500, 510);
		parameters = "&player=matt&score=" + randomScore;
		action = "set";
		StartCoroutine( LoadWWW() );
	}

	public void HTMLAction() {
		action = "html";
		parameters = "";
		StartCoroutine( LoadWWW() );
	}

	public void XMLAction() {
		action = "xml";
		parameters = "";
		StartCoroutine( LoadWWW() );
	}

	public void ResetAction() {
		action = "reset";
		parameters = "";
		StartCoroutine( LoadWWW() );
	}
}