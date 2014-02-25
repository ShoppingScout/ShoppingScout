using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System;

public class button_touching_chris : MonoBehaviour {

	private int SCREEN_WIDTH = Screen.width;
	private int SCREEN_HEIGHT = Screen.height;

	public GUISkin myGuiSkin;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnGUI () {
		GUI.skin = myGuiSkin;

		if (GUI.Button (new Rect (0.20f * SCREEN_WIDTH, 0.4f * SCREEN_HEIGHT, 0.60f * SCREEN_WIDTH, 0.25f * SCREEN_HEIGHT), "Start Game")) {
			Application.LoadLevel("Buttons");
		}

		if (GUI.Button (new Rect (0.20f * SCREEN_WIDTH, 0.7f * SCREEN_HEIGHT, 0.60f * SCREEN_WIDTH, 0.25f * SCREEN_HEIGHT), "Quit Game")) {
			Application.Quit();
		}

	}
	
}

