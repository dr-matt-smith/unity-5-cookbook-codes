using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * class to setup and manage changes between game states
 * and ensure enter / update / exit methods called for current state object
 */
public class GameManager : MonoBehaviour 
{
	// UI elements for onscreen messags, and buttons to change states
	public Text textStateMessages;
	public Button buttonWinGame;
	public Button buttonLoseGame;

	// variables that will reference objects for each state we might want our game to visit
	public StateGamePlaying stateGamePlaying{get; set;}
	public StateGameWon stateGameWon{get; set;}
	public StateGameLost stateGameLost{get; set;}

	// reference to the object representing the current state of the game
	private GameState currentState;

	/*------------------------------------------------------------------
	 * create 3 state objects - for playing / won/ lost
	 */
	private void Awake () 
	{
		stateGamePlaying = new StateGamePlaying(this);
		stateGameWon = new StateGameWon(this);
		stateGameLost = new StateGameLost(this);
	}

	/*------------------------------------------------------------------
	 *
	 */
	// move the game into state 'stateGamePlaying'
	private void Start () 
	{
		NewGameState( stateGamePlaying );
	}

	/*------------------------------------------------------------------
	 * if there is a currentState, then call its StateUpdate() method
	 */
	private void Update ()
	{
		if (currentState != null) {
			currentState.StateUpdate ();
		}
	}

	/*------------------------------------------------------------------
	 * actions to move game into a new state
	 */
	public void NewGameState(GameState newState)
	{
		// if there is a current state, then call its OnMyStateExit() method
		if (null != currentState) {
			currentState.OnMyStateExit ();
		}

		// store reference to the new state object in variable 'currentState'
		currentState = newState;

		// call the OnMyStateEntered() method for this new state object
		currentState.OnMyStateEntered();
	}

	/*------------------------------------------------------------------
	 * update the onscreen UI Text to show the message about the state just entered
	 */
	public void DisplayStateEnteredMessage(string stateEnteredMessage)
	{
		textStateMessages.text = stateEnteredMessage;
	}

	/*------------------------------------------------------------------
	 * move the game into the WIN GAME state
	 */
	public void BUTTON_CLICK_ACTION_WIN_GAME()
	{
		if( null != currentState){
			currentState.OnButtonClick(GameState.ButtonType.ButtonWinGame);
			DestroyButtons();
		}
	}

	/*------------------------------------------------------------------
	 * move the game into the LOSE GAME state
	 */
	public void BUTTON_CLICK_ACTION_LOSE_GAME()
	{
		if( null != currentState){
			currentState.OnButtonClick(GameState.ButtonType.ButtonLoseGame);
			DestroyButtons();
		}
	}

	/*------------------------------------------------------------------
	 * remove the 2 UI buttons from the screen
	 */
	private void DestroyButtons()
	{
		Destroy (buttonWinGame.gameObject);
		Destroy (buttonLoseGame.gameObject);
	}
}
