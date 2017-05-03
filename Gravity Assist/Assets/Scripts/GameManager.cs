using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{
	Menu,	//default menu state
	NewGame,	//Load objects into game
	Start		//Playing the game
}

public class GameManager : MonoBehaviour {

	public GameState gameState;


	// Use this for initialization
	void Start () {
		gameState = GameState.Menu;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameState == GameState.NewGame) {
			//Instantiate the player into the game
			//(Set camera to his position)
		}


	}
}
