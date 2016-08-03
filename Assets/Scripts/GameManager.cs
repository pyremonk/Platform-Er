using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	[HideInInspector] public bool isGamePaused = false;
	public Scene mainMenuScene;
	public int score = 0;
	public int heightScore = 0;
	public GameObject scoreUIText;
	public GameObject heightScoreUIText;
	public GameObject gameOverMenu;
	public GameObject pauseMenu;
	public GameObject howToPlayMenu;
	public GameObject platformManager;
	public GameObject starManager;
	public GameObject obstacleManager;

	private float highestPlayerYWorldPoint;
	private GameObject player;

	// Use this for initialization
	void Start () {
		
		// Hide the game menu
		gameOverMenu.gameObject.SetActive(false);
		pauseMenu.gameObject.SetActive(false);
		howToPlayMenu.gameObject.SetActive(false);

		// Find player (this isn't the best implementation, but since the player is never destroyed, I'll run with it)
		player = GameObject.Find("Player");

		// Set highestPlayerYWorldPoint
		highestPlayerYWorldPoint = player.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		// DEBUGGING STUFFS
		GameObject.Find ("HighestPoint").GetComponent<Text> ().text = highestPlayerYWorldPoint.ToString ();

		// Update the score text object
		scoreUIText.GetComponent<Text>().text = score.ToString();

		// Handle keyboard request to pause
		if (Input.GetKeyDown("p") || Input.GetKeyDown("b")) {
			if(isGamePaused)
			{
				isGamePaused = false;
				pauseMenu.gameObject.SetActive(false);
			} else {
				isGamePaused = true;
				pauseMenu.gameObject.SetActive(true);
			}
		}

		// Handle pause
		if (isGamePaused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}

		// Figure out highest Y world point for player
		if (player.transform.position.y > highestPlayerYWorldPoint) {
			highestPlayerYWorldPoint = player.transform.position.y;
		}

		CalculateHeightScore ();
	}
		

	public void AddToScore(int points) 
	{
		score = score+points;
	}

	void CalculateHeightScore()
	{
		int YWorldPoint;

		if (highestPlayerYWorldPoint > 0) {
			YWorldPoint = Mathf.RoundToInt (highestPlayerYWorldPoint);
			heightScore = YWorldPoint * 100;
			heightScoreUIText.GetComponent<Text> ().text = heightScore.ToString ();
		} else {
			heightScoreUIText.GetComponent<Text> ().text = heightScore.ToString ();
		}
	}

	// End game and present option to restart
	public void GameOver() {
		isGamePaused = true;
		gameOverMenu.gameObject.SetActive(true);
	}

	public void PauseMenu() {
		isGamePaused = true;
		pauseMenu.gameObject.SetActive(true);
	}

	public void ContinueGame() {
		isGamePaused = false;
		pauseMenu.gameObject.SetActive(false);
	}

	// Reload scene to start a new game
	public void RestartScene() {
		//string currentScene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene ("Sandbox");
	}

	// Send player back to main menu
	void MainMenu() {
		//SceneManager.LoadScene (mainMenuScene);
	}

	// Display how to play image/menu
	public void HowToPlay() {
		isGamePaused = true;
		howToPlayMenu.gameObject.SetActive(true);
	}

	public void CloseHowToPlay() {
		howToPlayMenu.gameObject.SetActive(false);
	}
}
