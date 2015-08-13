// BulletScript.cs
using UnityEngine;
using System.Collections;

/*
 * Class for Bullet behaviour
 * 
 * WHEN bullet hits a collider with a trigger DO the following:
 * 	IF hit object has tag 'Ball'
 * 		-1- destroy the ball object collided with
 *  	-2- instantiate an explosion prefab
 *  ENDIF
 * 
 * 	(Regardless of what we hit)
 *  destroy bullet game object
 */
public class BulletScript : MonoBehaviour 
{
	// reference to the Explosion prefab to be instantiated
	public Transform explosionPrefab;

	// collision logic
	private void OnTriggerEnter(Collider hit) 
	{
		// if we hit something tagged 'Ball' ...
		if( hit.CompareTag("Ball") ){
			// -1- destroy the ball object collided with
			Destroy(hit.gameObject);
			// -2- instantiate an explosion prefab
			Instantiate( explosionPrefab, transform.position, Quaternion.identity );
		}

		// (Regardless of what we hit)
		// destroy bullet game object
		Destroy(gameObject);
	}
}