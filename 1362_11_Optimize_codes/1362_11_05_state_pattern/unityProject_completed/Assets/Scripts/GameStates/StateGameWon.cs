using UnityEngine;
using System.Collections;

public class StateGameWon : GameState {
	public StateGameWon(GameManager manager):base(manager){}

	public override void OnMyStateEntered(){
		string stateEnteredMessage = "ENTER state: StateGameWon";
		gameManager.DisplayStateEnteredMessage(stateEnteredMessage);
		Debug.Log(stateEnteredMessage);
	}
	public override void OnMyStateExit(){}
	public override void StateUpdate() {}
	public override void OnButtonClick(ButtonType button){}
}
