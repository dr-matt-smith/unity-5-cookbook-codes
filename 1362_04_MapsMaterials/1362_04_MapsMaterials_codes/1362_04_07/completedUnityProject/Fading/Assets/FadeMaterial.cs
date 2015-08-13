using UnityEngine;
using System.Collections;
/* ----------------------------------------
 * class to demonstrate how to fade a material upon mouse click
 */ 
public class FadeMaterial : MonoBehaviour {
	// Time for fade duration, in seconds
	public float fadeDuration = 1.0f;
	// boolean variable for using the material's original alpha value at start
	public bool useMaterialAlpha = false;
	// Alpha value at start (if not using the material's original alpha value)
	public float alphaStart = 1.0f;
	// Alpha value at the end of the fade transition
	public float alphaEnd = 0.0f;
	// boolean variable for destroying the object once it has become invisible
	public bool destroyInvisibleObject = true;
	// boolean variable for activating/deactivating fade
	private bool isFading = false;
	// float value for the difference between initial and final alpha values
	private float alphaDiff;
	// float value for transition's starting time
	private float startTime;
	// variable for storing the object's Renderer component
	private Renderer rend;
	// variable for calculating the color of the material, including its alpha value
	private Color fadeColor;

	/* ----------------------------------------
	 * At Start, adjust object's material to desired alpha value, and also 
	 * calculate difference between initial and final alpha values
	 */
	void Start () {
		// store object's Renderer component into 'rend' variable
		rend = GetComponent<Renderer>();
		// set object material's original color as fadeColor
		fadeColor = rend.material.color;

		if (!useMaterialAlpha) {
			// IF not using material's original alpha value, THEN set 'alphaStart' as the alpha value for fadeColor 
			fadeColor.a = alphaStart;
		} else {
			// ELSE, IF using material's original alpha value, THEN use  material's alpha value for fadeColor 
			alphaStart = fadeColor.a;
		}

		// Change the object's material color to fadeColor
		rend.material.color = fadeColor;
		// Calculate difference between initial and final alpha values
		alphaDiff = alphaStart - alphaEnd;
	}
	
	/* ----------------------------------------
	 * During Update, calculate alpha value based on elapsed time, and
	 * also destroy invisible object, if necessary
	 */
	void Update () {
		// IF isFading is set as true, THEN...
		if(isFading){
			//...calculate elapsed time by subtracting fade starting time from current time
			var elapsedTime = Time.time - startTime;

			// IF elapsed time is less or equal to fade duration, THEN...
			if(elapsedTime <= fadeDuration){
				//... calculate fade progress based on the proportion between elapsed time and fade duration
				var fadeProgress = elapsedTime / fadeDuration;
				//... calculate value to be subtracted from initial alpha, based on fade progress and difference between initial and final alpha values
				var alphaChange = fadeProgress * alphaDiff;
				//... change fadeColor's alpha value by subtracting alphaChange from initial alpha value   
				fadeColor.a =  alphaStart - alphaChange;
				// apply fadeColor into object's material
				rend.material.color = fadeColor;
			// ELSE, if elapsed time is greater than fade duration...
			} else {
				//... set alphaEnd as fadeColor's alpha value
				fadeColor.a = alphaEnd;
				//... apply fadeColor into object's material
				rend.material.color = fadeColor;

				// IF destroyInvisibleObject is true, THEN...
				if(destroyInvisibleObject)
					// ...Destroy game object
					Destroy (gameObject);
				//... Stop fading by setting isFading as false; 
				isFading = false;	
			}
		}
	}

	/* ----------------------------------------
	 * On MouseUp, call FadeAlpha function
	  */	
	void OnMouseUp(){
		// Call FadeAlpha function
		FadeAlpha();
	}

	/* ----------------------------------------
	 * Function for starting fading process
	  */
	public void FadeAlpha(){
		// Set isFading as true
		isFading = true;
		// Set startTime as the current time
		startTime = Time.time;		
	}
}
