using UnityEngine;
using System.Collections;
/* ----------------------------------------
 * class to demonstrate how to make a character throw an object
 * when an animation clip reaches a specific point. 
 */ 
public class ThrowObject : MonoBehaviour {
	// A GameObject variable for storing the object to be thrown
	public GameObject prop;

	// Vector3 variable for adjusting the object's position relative to the character's hand 
	public Vector3 posOffset;

	// Vector3 variable for setting the force of the throw
	public Vector3 force;

	// Transform variable for the character's hand
	public Transform hand;

	// float variable for compensating the object's direction, if necessary
	public float compensationYAngle = 0f;
		
	/* ----------------------------------------
	 * Prepare function: instantiates the object to be thrown, placing it as a child of the character's hand 
	 * transform and removing its physics properties, making it purely kinematic.
	 */
	public void Prepare () {
		// Instantiate the prop prefab, placing it on the character's hand
		prop = Instantiate(prop, hand.position, hand.rotation) as GameObject;

		if(prop.GetComponent<Rigidbody>())
			// IF the prop prefab has a Rigidbody component, THEN destroy such component, making it kinematic
			Destroy(prop.GetComponent<Rigidbody>());

		// Disable the prop's Sphere Collider component, to avoid collisions with the Character Controller
		prop.GetComponent<SphereCollider>().enabled = false;		

		// name the prop as 'projectile'
		prop.name = "projectile";

		// make prop a child of the character's hand
		prop.transform.parent = hand;

		// adjust the prop's position according to the posOffset variable 
		prop.transform.localPosition = posOffset;

		// reset the porp's rotation
		prop.transform.localEulerAngles = Vector3.zero;		
	}	

	/* ----------------------------------------
	 * Throw function: adjusts prop rotation, dettaches it from the character's hand, 
	 * restores its physics properties, makes it ignore character's collider and throws it 
	 */
	public void Throw () {
		// Vector3 variable for getting the character's transform rotation
		Vector3 dir = transform.rotation.eulerAngles;

		// Adjust Y-axis of 'dir' Vector to compensate character's direction, if necessary
		dir.y += compensationYAngle;

		// set prop's transform rotation equal to 'dir' (character's rotation plus Y-Axis compensation)
		prop.transform.rotation = Quaternion.Euler(dir);

		// Dettach prop from character's hand, making it an independent object
		prop.transform.parent = null;		

		// Enable  prop's Sphere Collider component
		prop.GetComponent<SphereCollider>().enabled = true;		

		// Add Rigidbody component to prop
		Rigidbody rig = prop.AddComponent<Rigidbody>();

		// Collider variable for getting the prop's collider
		Collider propCollider = prop.GetComponent<Collider> ();

		// Collider variable for getting the character's collider
		Collider col = GetComponent<Collider> ();

		// Ignore collision between prop and character's colliders
		Physics.IgnoreCollision(propCollider, col);

		// Add force to prop, throwing it
		rig.AddRelativeForce(force);	
	}
}
