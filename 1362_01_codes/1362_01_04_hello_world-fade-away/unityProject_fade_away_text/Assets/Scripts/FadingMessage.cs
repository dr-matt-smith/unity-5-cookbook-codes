// file: FadingMessage
using UnityEngine;
using System.Collections;

public class FadingMessage : MonoBehaviour {
	const int TOTAL_FRAMES = 100;	

	private float alpha = 1.0f;
	private float alphaStep = 1.0f / TOTAL_FRAMES;
	private float deathAlpha;
	private float r;
	private float g;
	private float b;
	
	private void Awake() {
		deathAlpha = 2 * alphaStep;;
		Color startColor = GetComponent<GUIText>().material.color;
		alpha = startColor.a;
		
		r = startColor.r;
		g = startColor.g;
		b = startColor.b;
	}
	
	private void Update() {
		alpha -= alphaStep;
		
		if( alpha < deathAlpha)
			Destroy(gameObject);

		Color newColor = new Color(r, g, b, alpha); 
		GetComponent<GUIText>().material.color = newColor;
	}
}