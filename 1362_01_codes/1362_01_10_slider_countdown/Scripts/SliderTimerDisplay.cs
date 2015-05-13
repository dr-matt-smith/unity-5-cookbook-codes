using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderTimerDisplay : MonoBehaviour {
	private CountdownTimer countdownTimer;
	private Slider sliderUI;
	private int startSeconds = 30;

	void Start (){
		SetupSlider();
		SetupTimer();
	}

	void Update () {
		sliderUI.value = countdownTimer.GetProportionTimeRemaining();
		print (countdownTimer.GetProportionTimeRemaining());
	}

	private void SetupSlider (){
		sliderUI = GetComponent<Slider>();
		sliderUI.minValue = 0;
		sliderUI.maxValue = 1;
		sliderUI.wholeNumbers = false;
	}

	private void SetupTimer (){
		countdownTimer = GetComponent<CountdownTimer>();
		countdownTimer.ResetTimer(startSeconds);
	}

}
