using UnityEngine;
using System.Collections;
/* ----------------------------------------
 * class to demonstrate how to apply Ragdoll physics 
 * to a character previously set up with Ragdoll Wizard
 */ 
public class RagdollCharacter : MonoBehaviour {	
	/* ----------------------------------------
	 * At Start, deactivate all components that allow for ragdoll physics. 
	 * Also starting a coroutine that restores the character after 5 seconds
	 */
	void Start () {
		// Call DeactivateRagdoll function 
	    DeactivateRagdoll();
    }

	/* ----------------------------------------
	 * A function to activate all components that allow for ragdoll physics
	 */
    public void ActivateRagdoll(){
		// Disable Character Controller component
		gameObject.GetComponent<CharacterController> ().enabled = false;

		//  Disable character's Basic Controller component (a C# script that controls Mecanim system)
		gameObject.GetComponent<BasicController> ().enabled = false;

		//  Disable Animator component 
		gameObject.GetComponent<Animator> ().enabled = false;

		// Find every Rigidbody in character's hierarchy
		foreach (Rigidbody bone in GetComponentsInChildren<Rigidbody>()) {
				// Set bone's rigidbody component as not kinematic
				bone.isKinematic = false;
				
				//Enable collision detection for rigidbody component 
				bone.detectCollisions = true;
		}

		// Find every Collider in character's hierarchy
		foreach (Collider col in GetComponentsInChildren<Collider>()) {
				// Enable Collider
				col.enabled = true;
		}

		// Start coroutine to restore character
		StartCoroutine (Restore ());

    }

	/* ----------------------------------------
	 * A function to deactivate all components that allow for ragdoll physics
	 */
	public void DeactivateRagdoll(){
		// Enable Character Controller component
		gameObject.GetComponent<BasicController>().enabled = true;

		//  Enable Animator component 
		gameObject.GetComponent<Animator>().enabled = true;

		// Position character at Spawnpoint gameobject's position
		transform.position = GameObject.Find("Spawnpoint").transform.position;

		// Rotate character according to Spawnpoint gameobject's rotation
		transform.rotation = GameObject.Find("Spawnpoint").transform.rotation;

		// Find every Rigidbody in character's hierarchy
		foreach(Rigidbody bone in GetComponentsInChildren<Rigidbody>()){
			// Set bone's rigidbody component as  kinematic
			bone.isKinematic = true;
			// Disable collision detection for rigidbody component 
			bone.detectCollisions = false;
	    }

		// Find every Collider in character's hierarchy
		foreach(Collider col in GetComponentsInChildren<Collider>()){
			// Disable Collider
			col.enabled = false;
		}

		//  Enable character's Basic Controller component (a C# script that controls Mecanim system)
		gameObject.GetComponent<CharacterController>().enabled = true;

    }

	/* ----------------------------------------
	 * A function to restore the character after five seconds
	 */
	IEnumerator Restore(){
		// Wait for five seconds
		yield return new WaitForSeconds(5);

		// Deactivate Ragdoll 
		DeactivateRagdoll();
	}
}
