using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadTextFromWeb : MonoBehaviour
{
	public string url = "http://www.ascii-art.de/ascii/ab/badger.txt";

	IEnumerator Start()
	{
		// get reference to UI Text object on screen
		// and initially present a loading message
		Text textUI = GetComponent<Text>();
		textUI.text = "(loading file ...)";

		// load text from URL
		WWW www = new WWW(url);
		yield return www;

		// extract text contents
		string textFileContents = www.text;

		// display string in Console
		// and also on screen via UI Text object
		Debug.Log(textFileContents);
		textUI.text = textFileContents;
	}
}
