using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using System.IO;

public class ReadManualResourceImageFile : MonoBehaviour
{
	private string fileName = "externalTexture.jpg";
	private string url;
	private Texture2D externalImage;
	
	 IEnumerator Start ()
	 {
	 	// prefix "file:" to URL
	 	// so Unity knows we are loading from a file in the Build assets (not from the web)
	 	// use Path.combine, so mac/windows/linux correct folder separator used "/" or "\"
		url = "file:" + Application.dataPath;
		url = Path.Combine(url, "Resources");
		url = Path.Combine(url, fileName);

		// start loading data from path in 'url'
		// wait until loading completed
		WWW www = new WWW (url);
		yield return www;

		// display the loaded image as a Sprite on screen
		Texture2D texture = www.texture;
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
