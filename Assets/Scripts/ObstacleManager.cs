using UnityEngine;
using System.Collections;

public class ObstacleManager : MonoBehaviour {

	// TODO
	//	* Keep count of active obstacles
	//	* Increase count of obstacles as time goes by

	public GameObject obstaclePrefab;
	public GameManager gameMgr;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnObstacle", 8, 8);
	}

	void SpawnObstacle () {
		if (!gameMgr.isGamePaused) {
			// Find random place to spawn somewhere in the upper range of the camera view
			// x value is mostly anywhere left to right, y value is in the top 30% of the screen to above the camera view
			Vector3 position = Camera.main.ViewportToWorldPoint (new Vector3 (Random.Range (0.1F, 0.9F), Random.Range (0.7F, 1.5F), 10F));
			var newStar = Instantiate (obstaclePrefab, position, Quaternion.Euler(0,0,180)) as GameObject;
			newStar.transform.parent = GameObject.Find ("Dynamic Objects").transform;
		}
	}
}
