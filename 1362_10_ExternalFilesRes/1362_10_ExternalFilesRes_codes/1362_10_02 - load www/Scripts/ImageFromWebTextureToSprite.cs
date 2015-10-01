using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFromWebTextureToSprite : MonoBehaviour {

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

		// display image, by getting reference to sibling UI Image component
		// and setting the 'sprite' property of that component to the Sprite version of our loaded image
		GetComponent<Image>().sprite = TextureToSprite(texture);
	}

	/*-----------------------------------------------
	 * convert a Texture2D object into a Sprite object
	 */
	private Sprite TextureToSprite(Texture2D texture)
	{
		// get the size of the texture
		Rect rect = new Rect(0, 0, texture.width, texture.height);

		// set pivot point to be the center 0.5 = half way
		Vector2 pivot = new Vector2(0.5f, 0.5f);

		// create new Sprite object with out texture, size and pivot
		Sprite sprite = Sprite.Create(texture, rect, pivot);

		return sprite;
	}
}