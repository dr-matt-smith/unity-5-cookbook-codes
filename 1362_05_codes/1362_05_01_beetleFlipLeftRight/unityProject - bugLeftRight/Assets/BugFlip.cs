using UnityEngine;
using System.Collections;

public class BugFlip : MonoBehaviour {
	private bool facingRight = true;
	
	void Update() {
		if (Input.GetKeyDown(KeyCode.LeftArrow) && facingRight) Flip ();
		if (Input.GetKeyDown(KeyCode.RightArrow) && !facingRight) Flip ();
	}
	
	void Flip (){
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}

