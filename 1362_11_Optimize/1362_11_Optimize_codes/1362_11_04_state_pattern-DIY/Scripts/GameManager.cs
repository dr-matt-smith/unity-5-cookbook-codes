using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Text textStateMessages;
	public Button buttonWinGame;
	public Button buttonLoseGame;

	/*--------------------------------------------
	 * the 4 possible game states
	 */
	private enum GameStateType
	{
		Other,
		GamePlaying,
		GameWon,
		GameLost,
	}
	
	private GameStateType currentState = GameStateType.Other;
	private float timeGamePlayingStarted;
	private float timeToPressAButton = 5;

	/*--------------------------------------------
	 * move game into state 'GamePlaying'
	 */
	void Start ()
	{
		NewGameState( GameStateType.GamePlaying );
	}
	
	/*--------------------------------------------
	 * actions when we are chaning the game state
	 *
	 * first do any state EXIT actions
	 * then store the new state
	 * then do any state ENTER actions
	 */
	private void NewGameState(GameStateType newState)
	{

		// (1) state EXIT actions
		OnMyStateExit(currentState);

		// (2) change current state
		currentState = newState;
		
		// (3) state ENTER actions
		OnMyStateEnter(currentState);

		// display lines in console, to make reading the 'log' easier
		PostMessageDivider();
	}

	/*--------------------------------------------
	 * display horizontal line (of "-" minus signs) to make reading the 'log' easier
	 */
	public void PostMessageDivider()
	{
		string newLine = "\n";
		string divider = "-----------------------------------";
		textStateMessages.text += newLine + divider;
	}

	/*--------------------------------------------
	 * add a new message in the UI Text on screen
	 */
	public void PostMessage(string message)
	{
		string newLine = "\n";
		string timeTo2DecimalPlaces = String.Format("{0:0.00}", Time.time); 
		textStateMessages.text += newLine + timeTo2DecimalPlaces + " :: " + message;
	}
	
	/*--------------------------------------------
	 * action for WIN GAME button - move game into GameWon state
	 */
	public void BUTTON_CLICK_ACTION_WIN_GAME()
	{
		string message = "Win Game BUTTON clicked";
		PostMessage(message);
		NewGameState( GameStateType.GameWon );
	}
	
	/*--------------------------------------------
	 * action for LOSE GAME button - move game into GameLost state
	 */
	public void BUTTON_CLICK_ACTION_LOSE_GAME(){
		string message = "Lose Game BUTTON clicked";
		PostMessage(message);
		NewGameState( GameStateType.GameLost );
	}

	/*--------------------------------------------
	 * remove the 2 button GameObjects
	 */
	private void DestroyButtons(){
		Destroy (buttonWinGame.gameObject);
		Destroy (buttonLoseGame.gameObject);
	}

	/*--------------------------------------------
	 * OnMyStateEnter[ S ] - state-specific actions when we enter a state
	 */
	private void OnMyStateEnter(GameStateType state)
	{
		string enterMessage = "ENTER state: " + state.ToString();
		PostMessage(enterMessage);

		switch (state){
		case GameStateType.GamePlaying:
			OnMyStateEnterGamePlaying();
			break;
		case GameStateType.GameWon:
			// do nothing
			break;
		case GameStateType.GameLost:
			// do nothing
			break;
		}
	}
	
	/*--------------------------------------------
	 * actions when we enter GamePlaying state
	 */
	private void OnMyStateEnterGamePlaying()
	{
		// record time we enter state
		timeGamePlayingStarted = Time.time;
	}

	/*--------------------------------------------
	 * OnMyStateExit[ S ] - state-specific actions when we leave a state
	 */
	private void OnMyStateExit(GameStateType state)
	{
		string exitMessage = "EXIT state: " + state.ToString();
		PostMessage(exitMessage);

		switch (state){
		case GameStateType.GamePlaying:
			OnMyStateExitGamePlaying();
			break;
		case GameStateType.GameWon:
			// do nothing
			break;
		case GameStateType.GameLost:
			// do nothing
			break;
		case GameStateType.Other:
			// cope with game starting in state 'Other'
			// do nothing
			break;
		}
	}
	
	/*--------------------------------------------
	 * actions when we exit GamePlaying state
	 */
	private void OnMyStateExitGamePlaying()
	{
		// if leaving gamePlaying state then destroy the 2 buttons
		DestroyButtons();
	}
	
	/*--------------------------------------------
	 * Update[ S ] - state-specific actions for each frame we are in a state
	 */
	//---------  ---------
	void Update ()
	{
		switch (currentState){
		case GameStateType.GamePlaying:
			UpdateStateGamePlaying();
			break;
		case GameStateType.GameWon:
			// do nothing
			break;
		case GameStateType.GameLost:
			// do nothing
			break;
		}
	}

	/*--------------------------------------------
	 * actions for each frame that game is in GamePlaying state
	 */
	private void UpdateStateGamePlaying()
	{
		// calc time since we entered GamePlaying state
		float timeSinceGamePlayingStarted = Time.time - timeGamePlayingStarted;

		// if user has waited longer than 'timeToPressAButton' seconds
		// then automatically make game go into GameLost state
		if (timeSinceGamePlayingStarted > timeToPressAButton){
			string message = "User waited too long - automatically going to Game LOST state";
			PostMessage(message);
			NewGameState(GameStateType.GameLost);
		}
	}
}