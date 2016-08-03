using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		
		Vector3 screenPosition = Camera.main.WorldToScreenPoint (this.transform.position);
		if ( screenPosition.y < -1) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			GameObject gameMgr = GameObject.Find ("Game Manager");
			gameMgr.GetComponent<GameManager>().AddToScore (100);
			Destroy (gameObject);
		}
	}
}
