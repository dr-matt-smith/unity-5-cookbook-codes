using UnityEngine;
using System.Collections;
/* ----------------------------------------
 * class to demonstrate how to control a 
 * character using Character Controller and the Mecanim system
 */ 
public class BasicController: MonoBehaviour {
	// Variable for the character's Animator component
	private Animator anim;
	// Variable for the character's Character Controller component
	private CharacterController controller;
	// float variable for dampening speed values
	public float transitionTime = .25f;
	// float variable for speed limit
	private float speedLimit = 1.0f;
	// boolean variable for moving diagonally, combining x and z speed
	public bool moveDiagonally = true;
	// boolean variable for directing the charater's direction with the mouse
	public bool mouseRotate = true;
	// boolean variable for directing the charater's direction with the keyboard
	public bool keyboardRotate = false;
	/* ----------------------------------------
	 * At Start, get character's Animator and Character Controller components
	 */
	void Start () {
		// Assign character's Controller to 'controller' variable
		controller = GetComponent<CharacterController>();
		
		// Assign character's Animator to 'anim' variable
		anim = GetComponent<Animator>();
	}
	
	/* ----------------------------------------
	 * Whenever Directional controls are used, update variables from the Animator
	 */
	void Update () {
		
		// IF Character Controller is grounded...
		if(controller.isGrounded){	
			if (Input.GetKey (KeyCode.RightShift) ||Input.GetKey (KeyCode.LeftShift))
				// IF Shift key is pressed, THEN set speed limit to 0.5, slowing down the character
				speedLimit = 0.5f;
			else 
				// ELSE, set speed limit to full speed (1.0)
				speedLimit = 1.0f;	
			
			// a float variable to get Horizontal Axis input (left/right)
			float h = Input.GetAxis("Horizontal");
			
			// a float variable to get Vertical Axis input (forward/backwards)
			float v = Input.GetAxis("Vertical");
			
			// float variable for horizontal speed and direction, obtained by multiplying Horizontal Axis by the speed limit
			float xSpeed = h * speedLimit;	
			
			// float variable for vertical speed and direction, obtained by multiplying Vertical Axis by the speed limit
			float zSpeed = v * speedLimit;	
			
			// float variable for absolute speed 
			float speed = Mathf.Sqrt(h*h+v*v);
			
			if(v!=0 && !moveDiagonally)
				// IF Vertical Axis input is different than 0 AND moveDiagonally boolean is set to false, THEN set horizontal speed as 0 
				xSpeed = 0;
			
			if(v!=0 && keyboardRotate)
				// IF Vertical Axis input is different than 0 AND keyboardRotate boolean is set to true, THEN rotate character according to Horizontal Axis input
				this.transform.Rotate(Vector3.up * h, Space.World);
			
			if(mouseRotate)
				// IF mouseRotate boolean is set to true, THEN rotate character according to Horizontal mouse movement
				this.transform.Rotate(Vector3.up * (Input.GetAxis("Mouse X")) * Mathf.Sign(v), Space.World);
			
			// Set zSpeed float as 'zSpeed' variable of the Animator, dampening it for the amount of time in 'transitionTime' 
			anim.SetFloat("zSpeed", zSpeed, transitionTime, Time.deltaTime);
			
			// Set xSpeed float as 'xSpeed' variable of the Animator, dampening it for the amount of time in 'transitionTime' 
			anim.SetFloat("xSpeed", xSpeed, transitionTime, Time.deltaTime);
			
			// Set speed float as 'Speed' variable of the Animator, dampening it for the amount of time in 'transitionTime' 
			anim.SetFloat("Speed", speed, transitionTime, Time.deltaTime);
		}
		
		if(Input.GetKeyDown(KeyCode.F)){
			// IF 'F' key is pressed, THEN set 'Grenade' variable of the Animator as true
			anim.SetBool("Grenade", true);
		} else {
			// ELSE, set 'Grenade' variable of the Animator as false
			anim.SetBool("Grenade", false);
		}
		if(Input.GetButtonDown("Fire1")){
			// IF the 'Fire' button is pressed, THEN set 'Fire' variable of the Animator as true
			anim.SetBool("Fire", true);
		}
		if(Input.GetButtonUp("Fire1")){
			// IF the 'Fire' button is released, THEN set 'Fire' variable of the Animator as false
			anim.SetBool("Fire", false);
		}
	}
}
