using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReadImageFromWeb : MonoBehaviour {
	public string url = "http://www.packtpub.com/sites/default/files/packt_logo.png";
	IEnumerator Start() {
		WWW www = new WWW(url);
		yield return www;
		Texture2D texture = www.texture;
		GetComponent<RawImage>().texture = texture;
	}
}