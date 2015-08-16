using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/* ----------------------------------------
 * class to demonstrate how to take snapshots
 * of the screen and use it as a GUI texture
 */ 
public class ScreenTexture : MonoBehaviour {
	// Gameobject variable for the GUI object where to display the texture
	public GameObject photoGUI;
	// Gameobject variable for the GUI object to be used as frame
	public GameObject frameGUI;
	// Float variable for the ratio between size of the snapshot and displayed texture 
	public float ratio = 0.25f;

	/* ----------------------------------------
	 * During Update, detect if the left mouse button was pressed,
	 * starting the CaptureScreen() coroutine, if so.
	 */
	void  Update (){
		if (Input.GetKeyUp (KeyCode.Mouse0))
			// IF the left mouse button was pressed, THEN start the CaptureScreen coroutine
			StartCoroutine(CaptureScreen());
	}

	/* ----------------------------------------
	 * A function to calculate the dimension and location of the snapshot,
	 * capture it and apply it to its respective GUI element
	 */
	IEnumerator  CaptureScreen (){
		// Disable GUI element for the last snapshot taken (otherwise it will be superposed to the next snapshot)
		photoGUI.SetActive (false);

		// A shorthand for the screen's width
		int sw = Screen.width;

		// A shorthand for the screen's height
		int sh = Screen.height;

		// A shorthand for the Rect Transform settings of the GUI element for the framing 
		RectTransform frameTransform = frameGUI.GetComponent<RectTransform> ();


		// Rect for the snapshot area, initially based on the GUI frame's the Rect Transform 
		Rect framing = frameTransform.rect;

		// A shorthand for the coordinates of the GUI frame's pivot
		Vector2 pivot = frameTransform.pivot;
		
		// A 2D vector for the Anchor Min (defines horizontal and vertical origin of the frame)
		Vector2 origin = frameTransform.anchorMin;

		// Convert X coordinate of origin point to pixels by multiplying it by screen's width
		origin.x *= sw;

		// Convert Y coordinate of origin point to pixels by multiplying it by screen's height
		origin.y *= sh;

		// float var for horizontal offset of the frame, obtained by multiplying horizontal pivot point by frame width
		float xOffset = pivot.x * framing.width;

		// Add horizontal offset to frame horizontal origin
		origin.x += xOffset;

		// float var for vertical offset of the frame, obtained by multiplying vertical pivot point by frame height
		float yOffset = pivot.y * framing.height;

		// Add vertical offset to frame vertical origin
		origin.y += yOffset;

		// Offset framing horizontal location 
		framing.x += origin.x;

		// Offset framing vertical location 
		framing.y += origin.y;

		// Int variable for texture width, based on framing width
		int textWidth = (int)framing.width;

		// Int variable for texture height, based on framing height
		int textHeight = (int)framing.height;

		// Create a new Texture measuring textWidth x textHeight
		Texture2D texture = new Texture2D(textWidth,textHeight);	

		// Wait for the EndOfFrame before capturing snapshot
		yield return new WaitForEndOfFrame();

		//Read Pixels from screen 
		texture.ReadPixels(framing, 0, 0);

		// Apply captured pixels onto texture
		texture.Apply();

		// Re-activate GUI element for displaying snapshot
		photoGUI.SetActive (true);

		// 3D Vector for the new snapshot dimension (based on framing dimension multplied by selected ratio)
		Vector3 photoScale = new Vector3 (framing.width * ratio, framing.height * ratio, 1);

		// Resize GUI texture display to specified dimensions
		photoGUI.GetComponent<RectTransform> ().localScale = photoScale;

		// Set captured texture as GUI display's texture  
		photoGUI.GetComponent<RawImage>().texture = texture;
	}
}