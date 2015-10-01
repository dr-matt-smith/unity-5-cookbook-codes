using UnityEngine;
using System.Collections;

/**
 * our abstract state class
 *
 * the 'template' which each possible state sub-class must follow
 */
public abstract class GameState
{
	// our 2 possible buttons
	public enum ButtonType
	{
		ButtonWinGame,
		ButtonLoseGame
	}

	// each state object will have a reference back to the GameManager object
	protected GameManager gameManager;	

	/*----------------------------------------------------------
	 * constructor method,
	 * which takes as input a reference to the scenes GameManager object
	 */
	public GameState(GameManager manager)
	{
		gameManager = manager;
	}
	
	/*----------------------------------------------------------
	 * actions when state entered
	 */
	public abstract void OnMyStateEntered();

	/*----------------------------------------------------------
	 * actions when state exited
	 */
	public abstract void OnMyStateExit();

	/*----------------------------------------------------------
	 * actions for each frame that game is in current state
	 */
	public abstract void StateUpdate();

	/*----------------------------------------------------------
	 * actions if a button clicked when we are in a state
	 */
	public abstract void OnButtonClick(ButtonType button);
}
