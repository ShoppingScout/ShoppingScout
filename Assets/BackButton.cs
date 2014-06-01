using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	public GUISkin pauseSkin;
	private int SCREEN_WIDTH = Screen.width;
	private int SCREEN_HEIGHT = Screen.height;

	void OnGUI () {
		pauseSkin.button.fontSize = SCREEN_WIDTH/20;
		GUI.skin = pauseSkin;

		if (GUI.Button (new Rect (0.05f * SCREEN_WIDTH, 0.0075f * SCREEN_HEIGHT, 0.2f * SCREEN_WIDTH, 0.05f * SCREEN_HEIGHT), "Menu")) {
			CollisionAnswer.jo.Call("vibrate2", 75);
			Application.LoadLevel("Menu");
		}
	}
}
