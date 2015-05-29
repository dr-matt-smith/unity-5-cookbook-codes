using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFromWebTextureToSprite : MonoBehaviour {
	public string url = "http://www.packtpub.com/sites/default/files/packt_logo.png";
	IEnumerator Start() {
		WWW www = new WWW(url);
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