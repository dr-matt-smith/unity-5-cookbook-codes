using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public Text textStateMessages;
	public Button buttonWinGame;
	public Button buttonLoseGame;
	
	private enum GameStateType {
		Other,
		GamePlaying,
		GameWon,
		GameLost,
	}
	
	private GameStateType currentState = GameStateType.Other;
	private float timeGamePlayingStarted;
	private float timeToPressAButton = 5;

	void Start () {
		NewGameState( GameStateType.GamePlaying );
	}
	
	private void NewGameState(GameStateType newState) {

		// (1) state EXIT actions
		OnMyStateExit(currentState);

		// (2) change current state
		currentState = newState;
		
		// (3) state ENTER actions
		OnMyStateEnter(currentState);

		PostMessageDivider();
	}

	public void PostMessageDivider(){
		string newLine = "\n";
		string divider = "-----------------------------------";
		textStateMessages.text += newLine + divider;
	}
	
	public void PostMessage(string message){
		string newLine = "\n";
		string timeTo2DecimalPlaces = String.Format("{0:0.00}", Time.time); 
		textStateMessages.text += newLine + timeTo2DecimalPlaces + " :: " + message;
	}
	
	public void BUTTON_CLICK_ACTION_WIN_GAME(){
		string message = "Win Game BUTTON clicked";
		PostMessage(message);
		NewGameState( GameStateType.GameWon );
	}
	
	public void BUTTON_CLICK_ACTION_LOSE_GAME(){
		string message = "Lose Game BUTTON clicked";
		PostMessage(message);
		NewGameState( GameStateType.GameLost );
	}

	private void DestroyButtons(){
		Destroy (buttonWinGame.gameObject);
		Destroy (buttonLoseGame.gameObject);
	}

	//--------- OnMyStateEnter[ S ] - state specific actions ---------
	private void OnMyStateEnter(GameStateType state){
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
	
	private void OnMyStateEnterGamePlaying(){
		// record time we enter state
		timeGamePlayingStarted = Time.time;
	}

	//--------- OnMyStateExit[ S ] - state specific actions ---------
	private void OnMyStateExit(GameStateType state){
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
	
	private void OnMyStateExitGamePlaying(){
		// if leaving gamePlaying state then destroy the 2 buttons
		DestroyButtons();
	}
	
	//--------- Update[ S ] - state specific actions ---------
	void Update () {
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

	private void UpdateStateGamePlaying(){
		float timeSinceGamePlayingStarted = Time.time - timeGamePlayingStarted;
		if(timeSinceGamePlayingStarted > timeToPressAButton){
			string message = "User waited too long - automatically going to Game LOST state";
			PostMessage(message);
			NewGameState(GameStateType.GameLost);
		}
	}
}