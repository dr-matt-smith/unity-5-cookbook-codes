using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReadImageFromWeb : MonoBehaviour {
	// URL of image
	public string url = "http://www.packtpub.com/sites/default/files/packt_logo.png";

	/*-----------------------------------------------
	 * load image from web and display in scene
	 */
	IEnumerator Start()
	{
		// create WWW object, asking it to load content from 'url'
		WWW www = new WWW(url);

		// wait until 'www' has finshed loading
		yield return www;

		// extract image contents from 'www'
		Texture2D texture = www.texture;

		// display image, by getting reference to sibling UI RawImage component
		// and setting the 'texture' property of that component to the loaded texture image
		GetComponent<RawImage>().texture = texture;
	}
}