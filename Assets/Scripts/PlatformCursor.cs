using UnityEngine;
using System.Collections;

public class PlatformCursor : MonoBehaviour {

	private Vector3 mousePos;
	private GameObject player;
	private GameObject platformMgr;
	private float scaleWidth;
	public bool scaleMe = true;
	public GameManager gameMgr;

	void Start ()
	{
		Cursor.visible = false;
		player = GameObject.FindWithTag("Player");
		platformMgr = GameObject.Find ("Platform Manager");
	}

	void Update ()
	{
		CursorPosition();

		if (scaleMe) {
			ScaleCursor ();
		}

		if (gameMgr.isGamePaused) {
			Cursor.visible = true;
		} else {
			Cursor.visible = false;
		}
	}

	void CursorPosition()
	{
		float playerDistance = Vector3.Distance(Camera.main.transform.position, player.transform.position);
		mousePos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,playerDistance);
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		transform.position = mousePos;
	}

	void ScaleCursor()
	{
		scaleWidth = platformMgr.GetComponent<PlatformManager> ().leftoverWidth;

		transform.localScale = new Vector3( scaleWidth, 1, 1);
	}

	void ShowMouseCursor()
	{
		Cursor.visible = true;
	}
}
