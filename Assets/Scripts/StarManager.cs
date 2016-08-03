using UnityEngine;
using System.Collections;

public class StarManager : MonoBehaviour {

	public int maxStars = 3;
	public GameObject starPrefab;
	public GameManager gameMgr;

	private int currentStars = 0;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnStar", 3, 3);
	}
		
	void SpawnStar () {
		if (!gameMgr.isGamePaused) {
			// Find random place to spawn somewhere in the upper range of the camera view

			// x value is mostly anywhere left to right, y value is in the top 30% of the screen to above the camera view
			Vector3 position = Camera.main.ViewportToWorldPoint (new Vector3 (Random.Range (0.1F, 0.9F), Random.Range (0.7F, 1.5F), 10F));
			var newStar = Instantiate (starPrefab, position, Quaternion.identity) as GameObject;
			newStar.transform.parent = GameObject.Find ("Dynamic Objects").transform;
		}
	}
}
