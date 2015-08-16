using UnityEngine;
using System.Collections;
/* ----------------------------------------
 * class to demonstrate how to procedurally rotate 
 * a character's bone depending on user's input
 */ 
public class MouseAim: MonoBehaviour {
	// Transform variable for the Character's transform bone that should be rotated
	public Transform spine;
	// float variable for rotating the spine around its Z-Axis
	private float xAxis = 0f;
	// float variable for rotating the spine around its Y-Axis
	private float yAxis = 0f;
	// 2D Vector for storing minimum and maximum values for rotation around Z-Axis
	public Vector2 xLimit = new Vector2(-30f,30f);
	// 2D Vector for storing minimum and maximum values for rotation around Y-Axis
	public Vector2 yLimit= new Vector2(-30f,30f);
	// Transform variable for the character's weapon
	public Transform weapon;
	// GameObject variable for the UI Image for the crosshair
	public GameObject crosshair;
	// 2D vector for the screen location of the crosshair
	private Vector2 aimLoc;
	/* ----------------------------------------
	 * At LateUpdate, get mouse movement and use it to rotate
	 * character's spine accordingly, cast ray from weapon, and draw
	 * crosshair on screen. Late Update is used, so changes in rotation are applied
	 * after the model's original animation has played
	 */
	public void LateUpdate(){
		// Add horizontal mouse speed to yAxis rotation
		yAxis += Input.GetAxis ("Mouse X");

		// Clamp yAxis roation to specified values, avoiding impossible twists in character's bone structure
		yAxis = Mathf.Clamp (yAxis, yLimit.x, yLimit.y);

		// Add horizontal mouse speed to yAxis rotation
		xAxis -= Input.GetAxis ("Mouse Y");

		// Clamp yAxis roation to specified values, avoiding impossible twists in character's bone structure
		xAxis = Mathf.Clamp (xAxis, xLimit.x, xLimit.y);

		// Create 3D Vector for character's spine new transform rotation
		Vector3 corr = new Vector3(xAxis,yAxis,spine.localEulerAngles.z); 

		// Apply new rotation to character's spine
		spine.localEulerAngles = corr;

		// Create RaycastHit variable to detect if weapon is aiming at any object's collider
		RaycastHit hit; 

		// Create 3D Vector for keeping the weapon's forward direction 
		Vector3 fwd = weapon.TransformDirection(Vector3.forward);

		if (Physics.Raycast (weapon.position, fwd, out hit)) {
			// IF Ray cast from weapon to its forward direction hits something, THEN convert hit point to screen coordinates and set them as aimLoc variable ... 
			aimLoc =  Camera.main.WorldToScreenPoint(hit.point);
			// AND set UI crosshair as active...
			crosshair.SetActive(true);
			// AND set the UI crosshair's position to aimloc (which is the hit point position converted to screen coordinates) 
			crosshair.transform.position = aimLoc;
		
		} else {
			// ELSE, IF Ray cast from weapon to its forward direction does not hit anything, THEN set UI crosshair as inactive...
			crosshair.SetActive(false);
		
		}
		// For debugging purposes, draw a ray from the weapon to its forward direction 
		//Debug.DrawRay (weapon.position, fwd, Color.red);
	}
}
