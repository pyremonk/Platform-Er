using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {

	public bool platformsFall = false;
	public float decreaseRate = 0.1f;
	public float decreaseWait = 3f;
	private bool decreaseWidth = false;

	void Start () {
		StartCoroutine ("DecreaseWidth");
	}

	void Update () {

		// Scale down y
		if (decreaseWidth) {

			SpriteRenderer platformSprite = GetComponent<SpriteRenderer> ();
			Color col = platformSprite.color;

			platformSprite.color = col;

			var decreaseAmount = Vector3.right * Time.deltaTime * decreaseRate;

			// Decrease overall width in scene
			GameObject.Find ("Platform Manager").GetComponent<PlatformManager> ().DecreaseWidthTotal (decreaseAmount.x);

			// Reduce sizd of platform
			this.transform.localScale -= decreaseAmount;

		}

		// If width is 0, remove
		if (this.transform.localScale.x < 0) {
			RemoveMe ();
		}

	}
		
	void RemoveMe () {
		Destroy (this.gameObject);
	}

	IEnumerator DecreaseWidth()
	{
		yield return new WaitForSeconds (decreaseWait);

		// Decrease width
		decreaseWidth = true;
	}
}
