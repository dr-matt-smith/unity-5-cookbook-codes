using UnityEngine;
using System.Collections;

public class DisableWhenExitTrigger : MonoBehaviour
{
	// reference to Player GameObject
	private GameObject player;

	/*----------------------------------------------------
	 * get reference to Player GameObject in scene
	 */
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	/*----------------------------------------------------
	 * IF we hit GameObject tagged 'Player'
	 * THEN enable this scripted object again
	 * (so it will begin to receive Update() messages each frame)
	 */
	void OnTriggerEnter(Collider hitObjectCollider)
	{
		if (hitObjectCollider.CompareTag("Player")){
			print ("cube close to Player again");
			enabled = true;
		}
	}
	
	/*----------------------------------------------------
	 * IF we EXIT the collider of the GameObject tagged 'Player'
	 * THEN disable this scripted object again
	 * (so it will NOT receive Update() messages each frame)
	 */
	void OnTriggerExit(Collider hitObjectCollider)
	{
		if (hitObjectCollider.CompareTag("Player")){
			print ("cube away from Player");
			enabled = false;
		}
	}

	/*----------------------------------------------------
	 * each frame - while this object is 'enabled'
	 * print out a message to the Console
	 *
	 * since we prefix message with the time, when object is enabled we should see new messages
	 * each frame
	 *
	 * when object is disabled, we'll not see any change to what's in the Console panel
	 */
	void Update()
	{
		//do something, so we know when this script is NOT doing something!
		float d = Vector3.Distance( transform.position, player.transform.position);
		print(Time.time + ": distance from player to cube = " + d);
	}
}
