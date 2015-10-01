using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*----------------------------------------------------
 * example to illustrate difference between "inactive" and "disabled"
 * once inactive, this scripted object will NOT receive messaged like "OnBecameVisible()"
 *
 * the only way to become active again is if some other GameObject executes code to make this
 * object active
 * 		e.g. by calling our public method BUTTON_ACTION_MakeActive()
 */
public class InactiveWhenNotVisible : MonoBehaviour
{
	/*----------------------------------------------------
	 * once inactive, the only messages it will receive are from public method calls,
	 * such as Button OnClick() actions
	 *
	 * when button is clicked then make this GameObject active agin
	 */
	public void BUTTON_ACTION_MakeActive()
	{
		// make this gameObject active
		gameObject.SetActive(true);

		// so we'll hide the gameObject containing the button to make this active
		makeActiveAgainButton.SetActive(false);
	}

	// reference to GameObject displaying button to make this object active again
	public GameObject makeActiveAgainButton;

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
	 * IF this gameObject becomes 'invisible' make it in-active
	 *
	 * AND display the GameObject containing the button to make this active again
	 * - since when INACTIVE we will not receive OnBecameVisible() events (since we are 'inactive')
	 */
	void OnBecameInvisible()
	{
		gameObject.SetActive(false);
		makeActiveAgainButton.SetActive(true);
		print ("cube became invisible");
	}

	/*----------------------------------------------------
	 * each frame - while this object is 'active'
	 * print out a message to the Console
	 *
	 * since we prefix message with the time, when object is enabled we should see new messages
	 * each frame
	 *
	 * when object is not active, we'll not see any change to what's in the Console panel
	 */
	void Update()
	{
		//do something, so we know when this script is NOT doing something!
		float d = Vector3.Distance( transform.position, player.transform.position);
		print(Time.time + ": distance from player to cube = " + d);
	}
}
