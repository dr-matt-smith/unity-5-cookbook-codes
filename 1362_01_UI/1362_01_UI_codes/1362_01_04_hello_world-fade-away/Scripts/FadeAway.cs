using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof (CountdownTimer))]
public class FadeAway : MonoBehaviour {
	private CountdownTimer countdownTimer;
	private Text textUI;

	// number of seconds before text completely fades away ...
	private int startSeconds = 5;
	private bool fading = false;

	//---------------------------------
	void Start ()
	{
		// get reference to our screen text object & our scripted timer object
		textUI = GetComponent<Text>();	
		countdownTimer = GetComponent<CountdownTimer>();

		// let's start fading that on screen text ...

		StartFading(startSeconds);
	}

	//---------------------------------
	void Update ()
	{
		// test the flag - only fade text if 'fading' is TRUE
		if(fading){
			// get the time remaining as a float between 0.0 and 1.0
			float alphaRemaining = countdownTimer.GetProportionTimeRemaining();
			print (alphaRemaining);
			Color c = textUI.material.color;

			// set alpha to our time remaining percentage
			// so 1.0 means full text color, and 0.5 means half transparent and so on..
			c.a = alphaRemaining;
			textUI.material.color = c;

			// stop fading when very small number
			if(alphaRemaining < 0.01)
				fading = false;
		}
	}

	//---------------------------------
	// start our fading timer, for the given duration of seconds
	private void StartFading (int timerTotal)
	{
		countdownTimer.ResetTimer(timerTotal);

		// set flag to TRUE - so our fading logic will kick in
		fading = true;
	}

}
