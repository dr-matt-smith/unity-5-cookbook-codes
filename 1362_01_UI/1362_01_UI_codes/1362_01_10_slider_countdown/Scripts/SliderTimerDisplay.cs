using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderTimerDisplay : MonoBehaviour
{
	private CountdownTimer countdownTimer;
	private Slider sliderUI;
	private int startSeconds = 30;

	//----------------------------
	void Start ()
	{
		SetupSlider();
		SetupTimer();
	}

	//----------------------------
	// each frame we get the proportion of countdown left as a value from 0.0 - 1.0
	// and set the slider to display that proportion (e.g. 0.5 - slider handle in the center etc.)
	// and display it in console text message
	void Update ()
	{
		sliderUI.value = countdownTimer.GetProportionTimeRemaining();
		print (countdownTimer.GetProportionTimeRemaining());
	}

	//----------------------------
	// set slider to represent values from 0.0 - 1.0
	// which just happens to correspond to the values received from
	// countdown time method: GetProportionTimeRemaining()
	private void SetupSlider ()
	{
		sliderUI = GetComponent<Slider>();
		sliderUI.minValue = 0;
		sliderUI.maxValue = 1;
		sliderUI.wholeNumbers = false;
	}

	//----------------------------
	// get a reference to the CountdownTimer object that is a componet of our parent GameObject
	// and start that timer to countdown from the value in variable 'startSeconds'
	private void SetupTimer ()
	{
		countdownTimer = GetComponent<CountdownTimer>();
		countdownTimer.ResetTimer(startSeconds);
	}

}
