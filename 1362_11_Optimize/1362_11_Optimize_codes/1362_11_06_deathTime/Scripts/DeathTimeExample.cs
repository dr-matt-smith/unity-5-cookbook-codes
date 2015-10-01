using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathTimeExample : MonoBehaviour
{
	/*----------------------------------------------------
	 * calc death time based on current time + 'deathDelay'
	 */
	public void BUTTON_ACTION_StartDying()
	{
		deathTime = Time.time + deathDelay;
	}

	// how long to wait before destroying GameObject after button clicked
	public float deathDelay = 4f;

	// time to die, calculated after button clicked
	// while -1 no action to be taken
	private float deathTime = -1;

	// reference to UI Text on screen to show message
	public Text buttonText;

	/*----------------------------------------------------
	 * if 'deathTime' negative, do nothing (button hasn't been clicked yet)
	 *
	 * otherwise, update display and check if time reacehd to destroy the parent 'gameObject'
	 */
	void Update()
	{
		if (deathTime > 0){
			UpdateTimeDisplay();
			CheckDeath();
		}
	}
	
	/*----------------------------------------------------
	 * update UI Text to show seconds remaining until we destroy parent GameObject
	 */
	private void UpdateTimeDisplay()
	{
		float timeLeft = deathTime - Time.time;
		string timeMessage = "time left: " + timeLeft;
		buttonText.text = timeMessage;
	}
	
	/*----------------------------------------------------
	 * if current time after deathTime then destroy parent 'gameObject'
	 */
	private void CheckDeath()
	{
		if(Time.time > deathTime)
			Destroy( gameObject );
	}
}
