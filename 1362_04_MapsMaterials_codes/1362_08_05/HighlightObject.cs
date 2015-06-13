using UnityEngine;
using System.Collections;
/* ----------------------------------------
 * class to demonstrate how to change the Emission color of 
 * a material whenever the mouse hovers or clicks the object
 */ 
public class HighlightObject : MonoBehaviour
{
	// A variable for keeping the original emission color of the material.
	private Color initialColor;
	
	// A boolean for setting the initial emission color as black (no emission)
	public bool noEmissionAtStart = true;
	
	// A selector for the emission color on mouse hover
	public Color highlightColor = Color.red;
	
	// A selector for the emission color on mouse button down
	public Color mousedownColor = Color.green;
	
	// A boolean for tracking if the mouse is over the object
	private bool mouseon = false;
	
	// A variable for accessing the object's Renderer component
	private Renderer myRenderer;
	
	/* ----------------------------------------
	 * At Start, assign object's Renderer component to myRenderer
	 * and appropriate color to initialColor 
	 */ 
	void Start() {
		// Set the object's Renderer component as myRenderer
		myRenderer = GetComponent<Renderer>();
		if (noEmissionAtStart)
			// IF there should be no Emission color at Start THEN set black as initialColor
			initialColor = Color.black;
		else
			// ELSE, access the material's Emission Color property and assign it to initialColor
			initialColor = myRenderer.material.GetColor("_EmissionColor");
	}
	
	/* ----------------------------------------
	 * Whenever the mouse hovers the object,  
	 * set mouseon to 'true' and change the material's Emission Color
	 */
	void OnMouseEnter(){
		// Set mouseon as 'true'
		mouseon = true;
		// Set the the Emission Color of the object's material to the one selected in 'highlightColor'  
		myRenderer.material.SetColor("_EmissionColor", highlightColor);
	}
	
	/* ----------------------------------------
	 * Whenever the mouse exits the object,  
	 * set mouseon to 'false' and change the material's Emission Color to its initial color
	 */
	void OnMouseExit(){
		// Set mouseon as 'false'
		mouseon = false;
		// Set the the Emission Color of the object's material to the one selected in 'initialColor'  
		myRenderer.material.SetColor("_EmissionColor",initialColor);
	}
	
	/* ----------------------------------------
	 * Whenever the mouse button is down on the object,  
	 * change the material's Emission Color to the one selected in 'mousedownColor'
	 */
	void OnMouseDown(){
		myRenderer.material.SetColor("_EmissionColor", mousedownColor);
	}
	
	/* ----------------------------------------
	 * Whenever the mouse button is up,  
	 * restore the appropriate Emission Color
	 */
	void OnMouseUp(){
		if (mouseon)
			// IF the mouse is still over the object, THEN restore 'highlightColor' 
			myRenderer.material.SetColor("_EmissionColor", highlightColor);
		else
			// ELSE change the Emission Color back to the 'initialColor'
			myRenderer.material.SetColor("_EmissionColor", initialColor);
	}
}
