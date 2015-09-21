using UnityEngine;
using System.Collections;

/*
 * simple class, to flip sprite left / right based on arrow keys
 */
public class BugFlip : MonoBehaviour
{
	// flag - are we facing right?
	// (or if false, then we are facing left...)
	private bool facingRight = true;

	//----------------------------------
	void Update()
	{
		// flip if we are facing LEFT and press LEFT arrow key
		if (Input.GetKeyDown(KeyCode.LeftArrow) && facingRight)
			Flip ();

		// flip if we are facing LEFT (!right) and press RIGHT arrow key
		if (Input.GetKeyDown(KeyCode.RightArrow) && !facingRight)
			Flip ();
	}
	
	//----------------------------------
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		// this results in left/right mirrow image swap
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}

