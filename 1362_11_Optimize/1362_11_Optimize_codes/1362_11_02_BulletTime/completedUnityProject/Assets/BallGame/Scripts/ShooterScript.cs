// file: ShooterScript
using UnityEngine;
using System.Collections;

/*
 * Class allowing using to fire bullet with the 'Fire1' key
 * 
 * hide mouse cursor
 * 
 * each frame check if(Fire1 key pressed AND time for next bullet has been passed)
 * 	if so, instantiate a bullet prefab in direction users FPS camera is facing
 */
public class ShooterScript : MonoBehaviour
{
	// reference to the bullet to be fired
	public Rigidbody projectile;

	// minimum time to wait between each bullet to be fired
	public float fireRate = 0.5f;

	// force (speed) bullet to be initiated with
	public float projectileForce = 5000.0f;

	// variable representing the time which much be passed before a new bullet can be fired
	// (updated each time a bullet is fired)
	private float nextFire = 0.0f;

	// when scene starts, HIDE the user's mouse cursor
	private void Start() {
		Cursor.visible = false;        
	}

	// each frame, see if we shoud fire a bullet
	private void Update() {	
		// IF user pressed Fire1 key AND we have passed the time a next bullet is allowed
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			// THEN
			//		-1- 	calculate soonest future time another bullet can be fired
			//				(current time + minimum delay between bullets)
			nextFire = Time.time + fireRate;

			//		-2-		instantiate bullet prefab at current position and direction
			Rigidbody clone = (Rigidbody) Instantiate(projectile, Camera.main.transform.position, Camera.main.transform.rotation);

			//		-3-		more the bullet prefab (add force) forwards
			clone.AddForce(clone.transform.forward * projectileForce);
		}
	}           
}