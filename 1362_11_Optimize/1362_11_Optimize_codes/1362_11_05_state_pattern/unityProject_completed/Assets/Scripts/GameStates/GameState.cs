using UnityEngine;
using System.Collections;

public abstract class GameState {
	public enum ButtonType {
		ButtonWinGame,
		ButtonLoseGame
	}

	protected GameManager gameManager;	
	public GameState(GameManager manager) {
		gameManager = manager;
	}
	
	public abstract void OnMyStateEntered();
	public abstract void OnMyStateExit();
	public abstract void StateUpdate();
	public abstract void OnButtonClick(ButtonType button);
}
