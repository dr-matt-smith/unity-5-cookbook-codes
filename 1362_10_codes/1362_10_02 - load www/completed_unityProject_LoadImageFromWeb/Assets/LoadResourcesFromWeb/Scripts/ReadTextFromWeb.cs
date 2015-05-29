using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadTextFromWeb : MonoBehaviour {
	public string url = "http://www.ascii-art.de/ascii/ab/badger.txt";

	IEnumerator Start(){
		Text textUI = GetComponent<Text>();
		textUI.text = "(loading file ...)";

		WWW www = new WWW(url);
		yield return www;
		string textFileContents = www.text;
		Debug.Log(textFileContents);

		textUI.text = textFileContents;
	}
}
