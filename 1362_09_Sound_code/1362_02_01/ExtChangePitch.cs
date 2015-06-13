using UnityEngine;
using System.Collections;

/* ----------------------------------------
 * class to demonstrate how to access ChangePitch component 
 * from a different game object
 */ 
public class ExtChangePitch : MonoBehaviour {

	// A variable for referencing the external ChangePitch component
	private ChangePitch changePitch;

	/* ----------------------------------------
	 * At Start, assign the external object's ChangePitch component to 'changePitch' variable
	 */ 
	void Start () {
		// Assign ChangePitch component from game object named 'animatedRocket' to the 'changePitch' variable
		changePitch = GameObject.Find ("animatedRocket").GetComponent<ChangePitch>();
	}

	/* ----------------------------------------
	 * Whenever left or right mouse buttons are clicked, 
	 * call AccelRocket() from external ChangePitch component to readjust speed 
	 */
	void Update () {
		if (Input.GetMouseButton(0))
			// IF the left button of the mouse is clicked, THEN call AccelRocket to increase speed 
			changePitch.AccelRocket(changePitch.accel);
		
		if (Input.GetMouseButton(1))
			// IF the right button of the mouse is clicked, THEN call AccelRocket to decrease speed 
			changePitch.AccelRocket(-changePitch.accel);
	}
}
