using UnityEngine;
using System.Collections;

/*----------------------------------------------
 * logic for game PLAYING state
 */
public class StateGamePlaying : GameState
{
	public StateGamePlaying(GameManager manager):base(manager){}

	/*---------------------------------------
	 * display message saying we have entered this state
	 */
	public override void OnMyStateEntered()
	{
		string stateEnteredMessage = "ENTER state: StateGamePlaying";
		gameManager.DisplayStateEnteredMessage(stateEnteredMessage);
		Debug.Log(stateEnteredMessage);
	}

	/*---------------------------------------
	 * no special actions for exit/update
	 */
	public override void OnMyStateExit(){}
	public override void StateUpdate() {}


	/*---------------------------------------
	 * if win or lost button clicked while we are in gme Playing state
	 *
	 * then tell game manager to change into corresponding won/lost state
	 */
	public override void OnButtonClick(ButtonType button)
	{
		if( ButtonType.ButtonWinGame == button )
			gameManager.NewGameState(gameManager.stateGameWon);
		
		if( ButtonType.ButtonLoseGame == button )
			gameManager.NewGameState(gameManager.stateGameLost);
	}
}
