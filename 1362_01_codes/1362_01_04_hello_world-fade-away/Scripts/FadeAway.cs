using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof (CountdownTimer))]
public class FadeAway : MonoBehaviour {
	private CountdownTimer countdownTimer;
	private Text textUI;
	private int startSeconds = 5;
	private bool fading = false;

	void Start (){
		textUI = GetComponent<Text>();	
		countdownTimer = GetComponent<CountdownTimer>();

		StartFading(startSeconds);
	}

	void Update () {
		if(fading){
			float alphaRemaining = countdownTimer.GetProportionTimeRemaining();
			print (alphaRemaining);
			Color c = textUI.material.color;
			c.a = alphaRemaining;
			textUI.material.color = c;

			// stop fading when very small number
			if(alphaRemaining < 0.01)
				fading = false;
		}
	}

	private void StartFading (int timerTotal){
		countdownTimer.ResetTimer(timerTotal);
		fading = true;
	}

}
