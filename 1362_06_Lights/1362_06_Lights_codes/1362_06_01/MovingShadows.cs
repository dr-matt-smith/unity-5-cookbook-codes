using UnityEngine;
using System.Collections;
/* ----------------------------------------
 * class to demonstrate how to simulate a cloudy/windy
 * outdoor environment with cookie textures
 */ 
public class MovingShadows : MonoBehaviour{
	//Float variable for the speed of the wind on the X-axis
	public float windSpeedX;
	//Float variable for the speed of the wind on the Z-axis
	public float windSpeedZ;
	//Private float for the cookie texture size
	private float lightCookieSize;
	//Private Vector3 variable for keeping the light object's initial position 
	private Vector3 initPos;

	/* ----------------------------------------
	 * At Start, get the light object's initial position
	 * and light cookie size.
	 */
	void Start(){
		// Keep object's initial posision on the initPos variable
		initPos = transform.position;
		// Keep clight's ookie size on the lightCookieSize variable
		lightCookieSize = GetComponent<Light>().cookieSize;
	}

	/* ----------------------------------------
	 * During Update, translate Directional Light object and check if its distance from initial position (on X and Z axis) 
	 * exceeds cookie size. If so, reset appropriate axis position to its initial value.
	 */
	void Update(){
		// Get current position
		Vector3 pos = transform.position;

		// Get absolute value for the X-axis position
		float xPos = Mathf.Abs (pos.x);

		// Get absolute value for the Z-axis position
		float zPos = Mathf.Abs (pos.z);

		// Set a limit for the X-axis position (equal to the initial position plus cookie size)
		float xLimit = Mathf.Abs(initPos.x) + lightCookieSize;

		// Set a limit for the X-axis position (equal to the initial position plus cookie size)
		float zLimit = Mathf.Abs(initPos.z) + lightCookieSize;

		if (xPos >= xLimit)
			// IF current X-axis position is more or equal to X-axis limit, THEN reset it to its initial value
			pos.x = initPos.x;

		if (zPos >= zLimit)
			// IF current Z-axis position is more or equal to X-axis limit, THEN reset it to its initial value
			pos.z = initPos.z;

		// Update transform position
		transform.position = pos;

		// Float variable for translating light object on X-axis 
		float windX = Time.deltaTime * windSpeedX;

		// Float variable for translating light object on Z-axis 
		float windZ = Time.deltaTime * windSpeedZ;

		//Translate light object
		transform.Translate(windX, 0, windZ, Space.World);
	}
}
