using UnityEngine;
using System.Collections;

/*----------------------------------------------
 * logic for game LOST state
 */
public class StateGameLost : GameState
{
	public StateGameLost(GameManager manager):base(manager){}

	/*---------------------------------------
	 * display message saying we have entered this state
	 */
	public override void OnMyStateEntered()
	{
		string stateEnteredMessage = "ENTER state: StateGameLost";
		gameManager.DisplayStateEnteredMessage(stateEnteredMessage);
		Debug.Log(stateEnteredMessage);
	}

	/*---------------------------------------
	 * no special actions for exit/update/button
	 */
	public override void OnMyStateExit(){}
	public override void StateUpdate() {}
	public override void OnButtonClick(ButtonType button){}
}
