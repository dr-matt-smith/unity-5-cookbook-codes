using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/* ----------------------------------------
 * class to demonstrate how to implement
 * a mini-map using a second camera
 */ 
public class MiniMap : MonoBehaviour
{
	// Transform variable to be populated with the player's character, car, etc.
	public Transform target;
	// Gameobject variable fot the GUI element representing the player's avatar
	public GameObject marker;
	// Float variable for offsetting camera's Y-axis position. Try setting its value to the top of the scene's tallest location.   
	public float height = 10.0f;
	// Float variable for apparent distance of the map's camera. Higher values result in a broader view.
	public float distance = 10.0f;
	// boolean variable for locking the character's rotation, making the map orbit around it
	public bool freezeRotation = true;
	// private var for the camera's transform rotation in Euler angles
	private Vector3 camAngle;
	// private var for the camera's transform position
	private Vector3 camPos;
	// private var for the target's transform rotation in Euler angles
	private Vector3 targetAngle;
	// private var for the target's transform position
	private Vector3 targetPos;
	// private var for the camera's Camera component
	private Camera cam;

	/* ----------------------------------------
	 * At Start, (a) get the Camera component, (b) set initial camera rotation
	 */
	void Start(){
		// A shorthand for the Camera component
		cam = GetComponent<Camera> ();

		// Get camera's transform Euler Angles  
		camAngle = transform.eulerAngles;

		// Get character's transform Euler Angles 
		targetAngle = target.transform.eulerAngles;

		// Set camAngle X-axis rotation to 90 (making it look top-down)
		camAngle.x = 90;

		// Set camAngle Y-axis rotation to match the character's Y-axis rotation 
		camAngle.y = targetAngle.y;

		// Apply camAngle to the camera's transform Euler angles rotation
		transform.eulerAngles = camAngle;
	}

	/* ----------------------------------------
	 * During update, get target's position, adjust camera's position and rotation, 
	 * set camera's ortographic projection size, and update GUI's marker position
	 */
	void Update(){
		// shorthand for target's transform position
		targetPos = target.transform.position;

		// make Vector 'camPos' equal to target's position
		camPos = targetPos;

		// Offset camPos Y-axis value 
		camPos.y += height;

		// set camera'a position to Vector 'camPos' 
		transform.position = camPos;

		// set camera's ortographic projection size
		cam.orthographicSize = distance;

		if (freezeRotation){
			// IF the 'freezeRotation' option is checked, THEN set camAngle Y-axis rotation equal to character's
			camAngle.y = target.transform.eulerAngles.y;

			// ... AND update camera's rotation based on camAngle
			transform.eulerAngles = camAngle;
		}

		// convert targetPos from world position (Vector3) to screen point (Vector2) 
		targetPos = cam.WorldToScreenPoint (targetPos);

		// set GUI marker position to screen position (in pixels) of the target
		marker.GetComponent<RectTransform> ().position = targetPos;
	}
}
