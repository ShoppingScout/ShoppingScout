using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System;

public class button_touching_chris : MonoBehaviour {
	
	private int SCREEN_WIDTH = Screen.width;
	private int SCREEN_HEIGHT = Screen.height;
	private GUITexture logo;
	public static int load_number;
	
	public GUISkin myGuiSkin;
	// Use this for initialization
	void Start () {
		logo = GameObject.Find ("Logo").guiTexture;
		logo.guiTexture.transform.localScale = new Vector3(0.1f, 0.1f, 0); // format the logo
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))
			{
				Application.Quit();
			}
	}
	
	void OnGUI () {
		GUI.skin = myGuiSkin;
		
		if (GUI.Button (new Rect (0.20f * SCREEN_WIDTH, 0.4f * SCREEN_HEIGHT, 0.60f * SCREEN_WIDTH, 0.1f * SCREEN_HEIGHT), "All Items")) {
			Application.LoadLevel("Buttons");
			load_number = 1;
		} 
		
		if (GUI.Button (new Rect (0.20f * SCREEN_WIDTH, 0.55f * SCREEN_HEIGHT, 0.60f * SCREEN_WIDTH, 0.1f * SCREEN_HEIGHT), "Grocery")) {
			Application.LoadLevel("Buttons");
			load_number = 2;
		} // load level 2 and set static variable
		
		
		if (GUI.Button (new Rect (0.20f * SCREEN_WIDTH, 0.7f * SCREEN_HEIGHT, 0.60f * SCREEN_WIDTH, 0.1f * SCREEN_HEIGHT), "Level 3")) {
			Application.LoadLevel("Buttons");
			load_number = 3;
		} // load level 3 and set static variable
		
		if (GUI.Button (new Rect (0.20f * SCREEN_WIDTH, 0.85f * SCREEN_HEIGHT, 0.60f * SCREEN_WIDTH, 0.1f * SCREEN_HEIGHT), "Quit Game")) {
			Application.Quit();
		} // quit game
		
	}
}

