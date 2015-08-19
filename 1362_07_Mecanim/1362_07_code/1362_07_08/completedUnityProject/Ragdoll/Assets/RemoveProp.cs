using UnityEngine;
using System.Collections;
/* ----------------------------------------
 * class to demonstrate how to delete
 * a rigid prop from a Character 
 */ 
public class RemoveProp : MonoBehaviour {
	// String variable for the name of the prop to be deleted
	public string propName;
	// Transform variable to be populated with the bone where the prop is attached to
	public Transform targetBone;

	/* ----------------------------------------
	 * When entering the Trigger, check if prop is attached to the targetBone. If so, destroy it. 
	 * When all is done, destroy trigger object, if necessary.
	 */
	void  OnTriggerEnter ( Collider collision  ){
    
    	if (targetBone.IsChildOf(collision.transform)){
			// IF the target bone is a child of the game object that collided with the trigger, THEN check every child of the target bone...
			foreach(Transform child in targetBone){
				if (child.name == propName)
					// ... IF a child if the target bone has the same name of the prop, THEN destroy it	
          			Destroy (child.gameObject);    	
  	 		} 
    	}
	}
}