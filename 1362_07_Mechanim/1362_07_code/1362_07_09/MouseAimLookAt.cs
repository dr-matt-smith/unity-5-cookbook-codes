using UnityEngine;
using System.Collections;
/* ----------------------------------------
 * class to demonstrate how to procedurally rotate 
 * a character's bone depending on user's input
 * using the LookAt command
 */ 
public class MouseAimLookAt : MonoBehaviour {
	// Transform variable for the Character's transform bone that should be rotated
	public Transform spine;
	// Transform variable for the character's weapon
	public Transform weapon;
	// float variable for compensating spine's Y-Axis rotation, if necessary
	public float offsetYAngle = 20.0f;
	// float variable for maximum value for rotation around Y-Axis
	public float maxY = 300.0f;
	// float variable for minimum value for rotation around Y-Axis
	public float minY = 60.0f;
	// boolean variable for not allowing spine's X-Axis rotation (can be usefull for top-view purposes)
	public bool freezeX = false;
	// GameObject variable for the UI Image for the crosshair
	public GameObject crosshair;
	// 2D vector for the screen location of the crosshair
	private Vector2 aimLoc;
	// float variable for spine rotation around Y-Axis
	private float spineY;

	/* ----------------------------------------
	 * At LateUpdate, get mouse screen's position, convert it to World position, rotate
	 * character's spine to look ak it, constraining movement when necessary. 
	 * Then, cast ray from weapon, and draw crosshair on screen. 
	 * Late Update is used, so changes in rotation are applied
	 * after the model's original animation has played
	 */
	public void LateUpdate(){

		// 2D Vector for the mouse position
		Vector2 mouse = Input.mousePosition;

		// float variable for the Camera's Far Clip Plane, to be used as Z-axis reference when converting mouse screen position to world position 
		float dist = Camera.main.farClipPlane;

		// 3D Vector combining mouse position (x and y) and camera's far clip plane (z) 
		Vector3 screenPoint = new Vector3 (mouse.x, mouse.y,dist);

		// 3D vector for converting screenPoint from Screen position to World position
		Vector3 point = Camera.main.ScreenToWorldPoint(screenPoint);

		// float variable gets spine's orignal X-axis rotation
		float frozenX = spine.localEulerAngles.x;

		// Make spine rotate to look at 'point' where mouse is at
		spine.LookAt(point, Vector3.up);

		// 3D Vector for getting the rotation of spine in Euler Angles
		Vector3 newEulerAngles = spine.localEulerAngles;

		// Modify rotation of Y-Axis, adding Offset Y Angle to it 
		newEulerAngles.y = spine.localEulerAngles.y + offsetYAngle;

		// a boolean variable to detect if the new spine Y-Axis rotation is beyond the minimum value allowed
		bool underMinY = newEulerAngles.y  >= minY;

		// a boolean variable to detect if the new spine Y-Axis rotation is beyond the maximum value allowed
		bool overMaxY = newEulerAngles.y <= maxY;

		// a float for calculating the distance between current spine rotation and maximum value allowed
		float absDistMax = Mathf.Abs(newEulerAngles.y  - maxY);

		// a float for calculating the distance between current spine rotation and minimum value allowed
		float absDistMin = Mathf.Abs(newEulerAngles.y  + minY);


		if(underMinY && overMaxY){
			// IF rotation is out of specified bounds (minimum and maximum rotation values), THEN...
			if(absDistMax < absDistMin){
				// IF distance between current Y-Axis rotation is closer the the maximum value allowed, THEN set Y-Axis rotation to the maximum value allowed
				newEulerAngles.y = maxY;

			}else {
				// ELSE, IF distance between current Y-Axis rotation is closer the the minimum value allowed, THEN set Y-Axis rotation to the minimum value allowed
				newEulerAngles.y = minY;
			 }
		}

		if(freezeX)
			// IF X-Axis rotation is not allowed, use original X-Axis rotation instead
			newEulerAngles.x = frozenX;

		// Update spine rotation, with offset applied. 
		spine.localEulerAngles = newEulerAngles;


		// Create RaycastHit variable to detect if weapon is aiming at any object's collider
		RaycastHit hit; 

		// Create 3D Vector for keeping the weapon's forward direction 
		Vector3 fwd = weapon.TransformDirection(Vector3.forward);

		if (Physics.Raycast (weapon.position, fwd, out hit)) {
			// IF Ray cast from weapon to its forward direction hits something, THEN convert hit point to screen coordinates and set them as aimLoc variable ...
			aimLoc =  Camera.main.WorldToScreenPoint(hit.point);
			// AND set UI crosshair as active..
			crosshair.SetActive(true);
			// AND set the UI crosshair's position to aimloc (which is the hit point position converted to screen coordinates) 
			crosshair.transform.position = aimLoc;

    	} else {
			// ELSE, IF Ray cast from weapon to its forward direction does not hit anything, THEN set UI crosshair as inactive...
			crosshair.SetActive(false);

		}
		// For debugging purposes, draw a ray from the weapon to its forward direction 
		//Debug.DrawRay (weapon.position, fwd, Color.green);

    }


}
