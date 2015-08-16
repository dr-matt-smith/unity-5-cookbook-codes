using UnityEngine;
/* ----------------------------------------
 * class to demonstrate how to create a Picture-in-Picture effect
 * using two cameras. This script should be attached to a secondary camera
 * featuring a higher Depth level than the main camera.
 */ 
public class PictureInPicture: MonoBehaviour {
	// A selector for Horizontal Alignment of the smaller viewport 
	public enum hAlignment{left, center, right};
	// A selector for Vertical Alignment of the smaller viewport 
	public enum vAlignment{top, middle, bottom};
	// Set initial value for Horizontal Alignment as 'left' 
	public hAlignment horAlign = hAlignment.left;
	// Set initial value for Vertical Alignment as 'top' 
	public vAlignment verAlign = vAlignment.top;
	// A selector for units (pixels or screen size percentage) 
	public enum UnitsIn{pixels, screen_percentage};
	// Set 'pixels' as default unit
	public UnitsIn unit = UnitsIn.pixels;
	// Int variable for Picture-in-Picture width
	public int width = 50;
	// Int value for Picture-in-Picture height
	public int height= 50;
	// Int value for Horizontal Offset of the viewport (useful for adding margins)
	public int xOffset = 0;
	// Int value for Vertica Offset of the viewport (useful for adding margins)
	public int yOffset = 0;
	// Bool variable for continually updating the PiP location and dimensions at runtime
	public bool  update = true;
	// Int variables for horizontal and vertical position and size, in pixels, of the viewport
	private int hsize, vsize, hloc, vloc;

	/* ----------------------------------------
	 * At Start, call the AdjustCamera function to adjust the camera's 
	 * viewport
	 */
	void Start (){
		// Call the function that adjusts the camera's viewport position and location
		AdjustCamera ();
	}

	/* ----------------------------------------
	 * During Update, if the 'update' option is checked, call the AdjustCamera 
	 * function to adjust the camera's viewport
	 */
	void Update (){
		if(update)
			// IF 'update' was set to 'true', THEN call the function that adjusts the camera's viewport position and location
			AdjustCamera ();
	}

	/* ----------------------------------------
	 * A function to interpret user preferences for the Picture-in-Picture
	 * and draw the camera's viewport accordingly
	 */
	void AdjustCamera(){
		// Int variable, a shorthand for the screen's witdh;
		int sw = Screen.width;

		// Int variable, a shorthand for the screen's height;
		int sh = Screen.height;

		// float variable for calculating width in terms of screen's percentage  
		float swPercent = sw * 0.01f;

		// float variable for calculating height in terms of screen's percentage  
		float shPercent = sh * 0.01f;

		// float variable for calculating horizontal offset in terms of screen's percentage  
		float xOffPercent = xOffset * swPercent;

		// float variable for calculating vertical offset in terms of screen's percentage  
		float yOffPercent = yOffset * shPercent;

		// Int variable to be populated with the actual horizontal offset value
		int xOff;

		// Int variable to be populated with the actual vertical offset value
		int yOff;

		// IF/ELSE statement for converting screen percentage to pixels, if necessary

		if(unit == UnitsIn.screen_percentage){
			// IF using screen percentage, THEN multiply PiP width by swPercent and use it as PiP viewport horizontal size (in pixels)...
			hsize = width * (int)swPercent; 

			// AND multiply PiP height by shPercentand use it as PiP viewport vertical size (in pixels)...
			vsize = height * (int)shPercent;

			// AND use xOffPercent as actual horizontal offset value
			xOff = (int)xOffPercent;

			// AND use yOffPercent as actual vertical offset value
			yOff = (int)yOffPercent;
		
		// ELSE, IF using 'pixels' as units...
		} else {
			// ELSE, IF using 'pixels' as units, use 'width' as PiP viewport horizontal size (in pixels)...
			hsize = width;

			//... And use 'width' as PiP viewport horizontal size (in pixels)...
			vsize = height;

			// AND use xOff as actual horizontal offset value
			xOff = xOffset;

			// AND use yOff as actual vertical offset value
			yOff = yOffset;
		}

		// A SWITCH statement for adjusting the PiP viewport's position depending on horizontal alignment
		switch (horAlign) {
			// Case of 'left' alignment 
			case hAlignment.left:
					// Horizontally, start drawing PiP right after horizontal offset. e.g: If offset is 0, start from the first pixel, left to right 
					hloc = xOff;
					break;
			// Case of 'right' alignment 
			case hAlignment.right:
					// Int variable for the position where to start drawing PiP. 
					// e.g.: when drawing a 100px pip on a 800px screen, start at 800 - 100 = 700
					int justifiedRight = (sw - hsize);
					// add horizontal offset distance to horizontal origin of the PiP. 
					hloc = (justifiedRight - xOff);
					break;
			// Case of 'center' alignment 
			case hAlignment.center:
					// float variable for the position where to start drawing PiP. 
					// e.g.: when drawing a 100px pip on a 800px screen, start drawing on (800/2 - 100/2) = 350
					float justifiedCenter = (sw * 0.5f) - (hsize * 0.5f);
					// add horizontal offset distance to horizontal origin of the PiP. 
					hloc = (int)(justifiedCenter - xOff);
					break;
			}

		// A SWITCH statement for adjusting the PiP viewport's position depending on vertical alignment
		switch (verAlign) {
			// Case of 'top' alignment 
			case vAlignment.top:
				// Int variable for the position where to start drawing PiP. 
				// e.g.: when drawing a 100px pip on a 600px screen, start at 600 - 100 = 500	
				int justifiedTop = sh - vsize;
				// add vertical offset distance to vertical origin of the PiP. 	
				vloc = (justifiedTop - (yOff));
				break;
			case vAlignment.bottom:
				// Vertically, start drawing PiP from the bottom, adding vertical offset. e.g: If offset is 0, start from the first pixel, bottom to top	
				vloc = yOff;
				break;
			case vAlignment.middle:
				// float variable for the position where to start drawing PiP. 
				// e.g.: when drawing a 100px pip on a 600px screen, start drawing on (600/2 - 100/2) = 250
				float justifiedMiddle = (sh * 0.5f) - (vsize * 0.5f);
				// add vertical offset distance to vertical origin of the PiP. 
				vloc = (int)(justifiedMiddle - yOff);
				break;
			}
		// Set pixel rect of the camera to be drawn from position (hloc,vloc), measuring hsize x vsize pixels.			
		GetComponent<Camera>().pixelRect = new Rect(hloc,vloc,hsize,vsize);		
	}	
}
