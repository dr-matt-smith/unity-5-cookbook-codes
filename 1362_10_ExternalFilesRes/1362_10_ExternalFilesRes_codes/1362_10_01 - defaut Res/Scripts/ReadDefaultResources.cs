using UnityEngine;
using System.Collections;

public class ReadDefaultResources : MonoBehaviour
{
	// name of file to be loaded (no extension)
	public string fileName = "externalTexture";

	// image object to load file into
	private Texture2D externalImage;

	private void Start ()
	{
		// read data from external file and store in 'externalImage'
		externalImage = (Texture2D)Resources.Load(fileName);

		// get reference to Renderer componenent of parent GameObject
		Renderer myRenderer = GetComponent<Renderer>();

		// make parent GameObject display our loaded image
		myRenderer.material.SetTexture("_MainTex", externalImage);

	}
}
