using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlatformManager : MonoBehaviour {

	public GameObject platform;
	public GameManager gameMgr;
	public GameObject widthText;
	public float maxWidth = 1f;
	public float minWidth = 0f;

	[HideInInspector]
	public float totalWidth;

	[HideInInspector]
	public float leftoverWidth;

	// Use this for initialization
	void Start () {

	}

	void Update () {

		if(Input.GetButtonDown("Fire1"))
		{
			if (!gameMgr.isGamePaused) {

				var mousePos = Input.mousePosition;
				mousePos.z = 1;

				var objectPos = Camera.main.ScreenToWorldPoint (mousePos);

				var newPlatform = Instantiate (platform, objectPos, Quaternion.identity) as GameObject;

				newPlatform.transform.parent = GameObject.Find ("Dynamic Objects").transform;

				// Set platform width to leftover width
				if (totalWidth == minWidth) {

					// Add platform at full width
					AddWidthTotal(0.9f);

				} else if (totalWidth > minWidth) {

					// Set new platform at leftoverWidth and add leftoverWidth to totalWidth
					newPlatform.transform.localScale = new Vector3( leftoverWidth, 1, 1);
					AddWidthTotal (leftoverWidth);
				}
			}
		}

		SetLeftoverWidth ();

		widthText.GetComponent<Text>().text = totalWidth.ToString();
	}
		
	void SetLeftoverWidth()
	{
		// Get all platforms
		var platforms = GameObject.FindGameObjectsWithTag("Platforms");

		// If no platforms, reset the totalWidth to 0
		if (platforms.Length == 0)
		{
			totalWidth = minWidth;
			leftoverWidth = maxWidth;
		}

		if (totalWidth > 0) 
		{
			leftoverWidth = maxWidth - totalWidth;
		}
	}

	public void AddWidthTotal(float addAmount)
	{
		totalWidth += addAmount;
	}

	public void DecreaseWidthTotal(float decreaseAmount)
	{
		totalWidth -= decreaseAmount;
	}
}
