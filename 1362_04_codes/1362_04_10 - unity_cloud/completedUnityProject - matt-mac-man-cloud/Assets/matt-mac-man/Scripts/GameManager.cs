using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	private Player player;
	public Text scoreText;

	void Start(){
		GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
		player = playerGO.GetComponent<Player>();
	}

	void Update () {
		int score = player.GetScore();
		scoreText.text = "" + score;
	}
}
