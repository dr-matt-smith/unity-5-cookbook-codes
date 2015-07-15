using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using System;

public class DigitalCountdown : MonoBehaviour {
	private Text textClock;

	private float countdownTimerDelay;
	private float countdownTimerStartTime;
	
	void Start()
	{
		textClock = GetComponent<Text>();
		CountdownTimerReset( 30 );
	}

	void Update () 
	{
		// default - timer finished
		string timerMessage = "countdown has finished";
		int timeLeft = (int)CountdownTimerSecondsRemaining();
		
		if( timeLeft > 0)
			timerMessage = "Countdown seconds remaining = " + LeadingZero( timeLeft );
//		timerMessage = "Countdown seconds remaining = " +  LeadingZero( timeLeft );

		textClock.text = timerMessage;
	}

	private void CountdownTimerReset(float delayInSeconds)
	{
		countdownTimerDelay = delayInSeconds;
		countdownTimerStartTime = Time.time;
	}

	private float CountdownTimerSecondsRemaining()
	{
		float elapsedSeconds = Time.time - countdownTimerStartTime;
		float timeLeft = countdownTimerDelay - elapsedSeconds;
		return timeLeft;
	}

	private string LeadingZero(int n)
	{
		return n.ToString().PadLeft(2, '0');
	}
}
