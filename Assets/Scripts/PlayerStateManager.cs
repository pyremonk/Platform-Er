using UnityEngine;
using System.Collections;

public class PlayerStateManager : MonoBehaviour {

	public int lives = 1; // How many times the player will be saved if they fall
	public GameManager gameMgr;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 screenPosition = Camera.main.WorldToScreenPoint (this.transform.position);
		if ( screenPosition.y < -50) {
			PlayerFell ();
		}
	}

	// Determine if we save or ask to restart
	void PlayerFell() {
		KillPlayer ();
	}

	// If player falls below viewport once, jump them back up for the player to save
	void SavePlayer() {

	}

	// If player falls below viewport a second time, send game over to game manager and destroy player object and child objects
	public void KillPlayer() {
		// Tell game manager that the player has died
		gameMgr.GetComponent<GameManager>().GameOver();
	}
}
