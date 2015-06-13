using UnityEngine;
using System.Collections;

public class StateGameLost : GameState {
	public StateGameLost(GameManager manager):base(manager){}
	
	public override void OnMyStateEntered(){
		string stateEnteredMessage = "ENTER state: StateGameLost";
		gameManager.DisplayStateEnteredMessage(stateEnteredMessage);
		Debug.Log(stateEnteredMessage);
	}
	public override void OnMyStateExit(){}
	public override void StateUpdate() {}
	public override void OnButtonClick(ButtonType button){}
}
