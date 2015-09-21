using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using System;

/*
 * class to display a countdown timer in the form:
 * "Countdown seconds remaining = 12"
 * 
 * when finsihed display message:
 * "countdown has finished"
 */
public class DigitalCountdown : MonoBehaviour {
	// reference to UI Text object whose text we'll update with countdowm message
	private Text textClock;

	// how many seconds to count down from
	private float countdownTimerDelay;

	// time at which we start the countdown (milliseconds since the Application was started)
	private float countdownTimerStartTime;

	//---------------------------------
	void Start()
	{
		// get reference to Text component inside our parent GameObject
		textClock = GetComponent<Text>();

		// start our timer, with a countdown total of 30 seconds
		CountdownTimerReset( 30 );
	}

	//---------------------------------
	void Update ()
	{
		// default - timer finished
		string timerMessage = "countdown has finished";

		// get seconds remaining (as a whole number)
		int timeLeft = (int)CountdownTimerSecondsRemaining();

		// if 1 or more seconds left then build String message of seconds left
		if(timeLeft > 0)
			timerMessage = "Countdown seconds remaining = " + LeadingZero( timeLeft );
//		timerMessage = "Countdown seconds remaining = " +  LeadingZero( timeLeft );

		// update 'text' componnent of our UI Text object with string message
		textClock.text = timerMessage;
	}

	/*
	 * reset our countdown at this point in time with the given total
	 */
	private void CountdownTimerReset(float delayInSeconds)
	{
		// store the number of seconds to countdown from
		countdownTimerDelay = delayInSeconds;

		// record the time NOW when timer started
		countdownTimerStartTime = Time.time;
	}

	//---------------------------------
	// return float value of seconds remaining, e.g. 5.05
	private float CountdownTimerSecondsRemaining()
	{
		// elapse time is current time less time when we started the timer
		float elapsedSeconds = Time.time - countdownTimerStartTime;

		// time left in countdown is countdown total less elapsed seconds
		float timeLeft = countdownTimerDelay - elapsedSeconds;

		return timeLeft;
	}

	//---------------------------------
	private string LeadingZero(int n)
	{
		// pad out numbers less than 10 with a leading 0
		// e.g. 1 becomes 01, 4 becomes 04 etc.
		return n.ToString().PadLeft(2, '0');
	}
}
