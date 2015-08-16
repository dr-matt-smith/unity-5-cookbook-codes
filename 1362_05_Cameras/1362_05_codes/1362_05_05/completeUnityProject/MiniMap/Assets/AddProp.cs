using UnityEngine;
using System.Collections;
/* ----------------------------------------
 * class to demonstrate how to attach
 * a rigid prop to a Character Controller
 */ 
public class AddProp : MonoBehaviour {
	// GameObject variable to be populated with the prefab for the selected prop
	public GameObject prop;
	// Transform variable to be populated with the bone where to attach the prop to
	public Transform targetBone;
	// Vector3 variable for position offset of the prop, relative to the targetbone
	public Vector3 positionOffset;
	// Vector3 variable for rotation offset of the prop, relative to the targetbone
	public Vector3 rotationOffset;
	// boolean variable for destroying the trigger where this script is attached to after adding the prop to the character
	public bool  destroyTrigger = true;

	/* ----------------------------------------
	 * When entering the Trigger, check if prop already exists. If not, instantiate it into the 
	 * right position and make it a child of the target bone. When all is done, destroy trigger object,
	 * if necessary.
	 */
	void  OnTriggerEnter ( Collider collision  ){
		
		if (targetBone.IsChildOf(collision.transform)){
			// IF the target bone is a child of the game object that collided with the trigger, THEN create a boolean for checking if the prop is already in place...
			bool  checkProp = false;
			// Check every child of the target bone...
			foreach(Transform child in targetBone){
				if (child.name == prop.name)
					// ... IF a child if the target bone has the same name of the prop, THEN set checkProp as 'true'
					checkProp = true;    	
			}
			
			if(!checkProp){  
				// IF prop is not in place yet, THEN create a new game object...
				GameObject newprop;

				// ... AND make the new game object an instance of the selected prop and place it over the target bone
				newprop = Instantiate(prop, targetBone.position, targetBone.rotation) as GameObject;

				//... AND name the new game object as the prefab...
				newprop.name = prop.name;

				//... AND make the new game object a child of the target bone...
				newprop.transform.parent = targetBone;
				//... AND adjust its local position according to the Position Offset...
				newprop.transform.localPosition += positionOffset; 

				//... AND adjust its local rotation according to the Rotation Offset...
				newprop.transform.localEulerAngles += rotationOffset;    

				if(destroyTrigger)
					// IF destroyTrigger boolean is set as 'true', THEM destroy this trigger's game object.
					Destroy(gameObject);
			}
		}
	}
}

