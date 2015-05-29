using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using System.IO;

public class ReadManualResourceImageFile : MonoBehaviour {
	private string fileName = "externalTexture.jpg";
	private string url;
	private Texture2D externalImage;
	
	 IEnumerator Start () {
		url = "file:" + Application.dataPath;
		url = Path.Combine(url, "Resources");
		url = Path.Combine(url, fileName);
		
		WWW www = new WWW (url);
		yield return www;

		Texture2D texture = www.texture;
		GetComponent<Image>().sprite = TextureToSprite(texture);
	}
	
	private Sprite TextureToSprite(Texture2D texture){
		Rect rect = new Rect(0, 0, texture.width, texture.height);
		Vector2 pivot = new Vector2(0.5f, 0.5f);
		Sprite sprite = Sprite.Create(texture, rect, pivot);
		return sprite;
	}
}
