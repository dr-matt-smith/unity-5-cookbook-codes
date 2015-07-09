using UnityEngine;
using System.Collections;

public class StateGamePlaying : GameState {
	public StateGamePlaying(GameManager manager):base(manager){}

	public override void OnMyStateEntered(){
		string stateEnteredMessage = "ENTER state: StateGamePlaying";
		gameManager.DisplayStateEnteredMessage(stateEnteredMessage);
		Debug.Log(stateEnteredMessage);
	}
	public override void OnMyStateExit(){}
	public override void StateUpdate() {}


	public override void OnButtonClick(ButtonType button){
		if( ButtonType.ButtonWinGame == button )
			gameManager.NewGameState(gameManager.stateGameWon);
		
		if( ButtonType.ButtonLoseGame == button )
			gameManager.NewGameState(gameManager.stateGameLost);
	}
}
