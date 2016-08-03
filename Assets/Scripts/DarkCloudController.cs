using UnityEngine;
using System.Collections;

public class DarkCloudController : MonoBehaviour {

	public float rightLimit = 0.9f;
	public float leftLimit = 0.25f;
	public float speed = 2.0f;
	private int direction = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// TODO Figure out where the platform was instantiated and set limits on movement based on this position
		// TODO Platform moves left or right based on which side the platform was instantiated

		if (transform.position.x > rightLimit) {
			direction = 1;
		}
		else if (transform.position.x < leftLimit) {
			direction = -1;
		}

		var movement = Vector3.right * direction * speed * Time.deltaTime; 
		transform.Translate(movement); 

		Vector3 screenPosition = Camera.main.WorldToScreenPoint (this.transform.position);
		if ( screenPosition.y < -50) {
			Destroy (this.gameObject);
			// Tell obstacle manager that cloud was destroyed
			// GameObject.Find ("Cloud Manager").GetComponent<CloudManager> ().RemoveCloud ();
		}
	}

	void OnCollisionEnter2D ( Collision2D enterObj ){

		/* TODO


		if (enterObj.gameObject.tag == "Player") {
			enterObj.gameObject.GetComponent<PlayerStateManager> ().KillPlayer ();
		}

		*/
	}
}
