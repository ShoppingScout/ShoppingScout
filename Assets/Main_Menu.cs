using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System;

public class Main_Menu : MonoBehaviour {
	
	private int SCREEN_WIDTH = Screen.width;
	private int SCREEN_HEIGHT = Screen.height;
	private GUITexture logo;
	public static int load_number;
	
	public GUISkin myGuiSkin;
	public GUISkin shopGuiSkin;
	public GUISkin pauseSkin;
	// Use this for initialization
	void Start () {
		LevelUp.startStage();
	}
	
	// Update is called once per frame
	void Update () {
	if (Application.platform == RuntimePlatform.Android){
		if (Input.GetKey(KeyCode.Escape))
			{
				CollisionAnswer.jo.Call("vibrate2", 75);
				Application.Quit();
			}
		}		
	}
	
	void OnGUI () {
		myGuiSkin.button.fontSize = SCREEN_WIDTH/20;

		GUI.skin = myGuiSkin;
		
		if (GUI.Button (new Rect (0.25f * SCREEN_WIDTH, 0.8f * SCREEN_HEIGHT, 0.50f * SCREEN_WIDTH, 0.1f * SCREEN_HEIGHT), "")) {
			Application.LoadLevel("Buttons");
			load_number = 1;
		} 
		
		pauseSkin.button.fontSize = SCREEN_WIDTH/20;

		GUI.skin = pauseSkin;

//		if (GUI.Button (new Rect (0.00f * SCREEN_WIDTH, 0.95f * SCREEN_HEIGHT, 0.2f * SCREEN_WIDTH, 0.05f * SCREEN_HEIGHT), "Reset")) {
//			PlayerPrefs.DeleteAll ();
//		}

		if (GUI.Button (new Rect (0.05f * SCREEN_WIDTH, 0.0075f * SCREEN_HEIGHT, 0.2f * SCREEN_WIDTH, 0.05f * SCREEN_HEIGHT), "Shop")) {
			Application.LoadLevel("Shop");
		} 

		if (GUI.Button (new Rect (0.7f * SCREEN_WIDTH, 0.0075f * SCREEN_HEIGHT, 0.25f * SCREEN_WIDTH, 0.05f * SCREEN_HEIGHT), "Tutorial")) {
			Application.LoadLevel("Shop");
		} 
		
	}
}

