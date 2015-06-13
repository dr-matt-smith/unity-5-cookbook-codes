using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathTimeExample : MonoBehaviour { 
	public void BUTTON_ACTION_StartDying() {
		deathTime = Time.time + deathDelay;
	}
	
	public float deathDelay = 4f;
	private float deathTime = -1;

	public Text buttonText;

	void Update(){
		if(deathTime > 0){
			UpdateTimeDisplay();
			CheckDeath();
		}
	}

	private void UpdateTimeDisplay(){
		float timeLeft = Time.time - deathTime;
		timeLeft = Mathf.Abs(timeLeft);
		string timeMessage = "time left: " + timeLeft;
		buttonText.text = timeMessage;
	}

	private void CheckDeath(){
		if(Time.time > deathTime) Destroy( gameObject );
	}
}