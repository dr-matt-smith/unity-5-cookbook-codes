using UnityEngine;
using System.Collections;

public class ReadDefaultResources : MonoBehaviour
{
	public string fileName = "externalTexture";
	private Texture2D externalImage;

	private void Start ()
	{
		externalImage = (Texture2D)Resources.Load(fileName);
		Renderer myRenderer = GetComponent<Renderer>();
		myRenderer.material.SetTexture("_MainTex", externalImage);

	}
}
