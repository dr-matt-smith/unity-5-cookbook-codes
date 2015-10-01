using UnityEngine;
using System.Collections;

public class DisableWhenNotVisible : MonoBehaviour
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
	 * IF this gameObject becomes 'visible' make it enabled
	 * visible means object is withing viewing frustrum of any of the active cameras in the scene
	 *
	 * NOTE - this includes the Scene panel - so test with Game panel 'maximized on run'
	 */
	void OnBecameVisible()
	{
		enabled = true;
		print ("cube became visible again");
	}
	
	/*----------------------------------------------------
	 * IF this gameObject becomes 'invisible' make it enabled
	 */
	void OnBecameInvisible()
	{
		enabled = false;
		print ("cube became invisible");
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
