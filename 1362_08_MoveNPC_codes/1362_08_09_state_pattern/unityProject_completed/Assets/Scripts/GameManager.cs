using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public Text textStateMessages;
	public Button buttonWinGame;
	public Button buttonLoseGame;

	public StateGamePlaying stateGamePlaying{get; set;}
	public StateGameWon stateGameWon{get; set;}
	public StateGameLost stateGameLost{get; set;}
	
	private GameState currentState;

	private void Awake () {
		stateGamePlaying = new StateGamePlaying(this);
		stateGameWon = new StateGameWon(this);
		stateGameLost = new StateGameLost(this);
	}
	
	private void Start () {
		NewGameState( stateGamePlaying );
	}

	private void Update () {
		if (currentState != null)
			currentState.StateUpdate();
	}
	
	public void NewGameState(GameState newState)
	{
		if( null != currentState)
			currentState.OnMyStateExit();
		
		currentState = newState;
		currentState.OnMyStateEntered();
	}

	public void DisplayStateEnteredMessage(string stateEnteredMessage){
		textStateMessages.text = stateEnteredMessage;
	}
	
	public void BUTTON_CLICK_ACTION_WIN_GAME(){
		if( null != currentState){
			currentState.OnButtonClick(GameState.ButtonType.ButtonWinGame);
			DestroyButtons();
		}
	}
	
	public void BUTTON_CLICK_ACTION_LOSE_GAME(){
		if( null != currentState){
			currentState.OnButtonClick(GameState.ButtonType.ButtonLoseGame);
			DestroyButtons();
		}
	}

	private void DestroyButtons(){
		Destroy (buttonWinGame.gameObject);
		Destroy (buttonLoseGame.gameObject);
	}
}
