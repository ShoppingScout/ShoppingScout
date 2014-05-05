using UnityEngine;
using System.Collections;

public class Pause_Menu : MonoBehaviour {
	
	public GUISkin pauseSkin;
	private int SCREEN_WIDTH = Screen.width;
	private int SCREEN_HEIGHT = Screen.height;
	bool paused = false;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	
	void OnGUI () {
		pauseSkin.button.fontSize = SCREEN_WIDTH/20;

		GUI.skin = pauseSkin;
		
		if (paused) {
			if (GUI.Button (new Rect (0.20f * SCREEN_WIDTH, 0.2f * SCREEN_HEIGHT, 0.60f * SCREEN_WIDTH, 0.07f * SCREEN_HEIGHT), "Unpause")) {
				paused = togglePause();
			}
			
			if (GUI.Button (new Rect (0.20f * SCREEN_WIDTH, 0.3f * SCREEN_HEIGHT, 0.60f * SCREEN_WIDTH, 0.07f * SCREEN_HEIGHT), "Main Menu")) {
				paused = togglePause ();
				Application.LoadLevel("Menu");
			}
		}
		
		else {
			if (GUI.Button (new Rect (0.05f * SCREEN_WIDTH, 0.9f * SCREEN_HEIGHT, 0.2f * SCREEN_WIDTH, 0.05f * SCREEN_HEIGHT), "Pause")) {
				paused = togglePause();
			}
		}
		
	}
	
	bool togglePause()
	{
		if (Time.timeScale == 0f) {
			Time.timeScale = 1f;
			return (false);
		}
		else {
			Time.timeScale = 0f;
			return(true);
		}
	}
}
