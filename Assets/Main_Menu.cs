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
	// Use this for initialization
	void Start () {
//		logo = GameObject.Find ("Logo").guiTexture;
//		logo.guiTexture.transform.localScale = new Vector3(0.1f, 0.1f, 0); // format the logo
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
		myGuiSkin.button.fontSize = SCREEN_WIDTH/15;

		GUI.skin = myGuiSkin;
		
		if (GUI.Button (new Rect (0.25f * SCREEN_WIDTH, 0.8f * SCREEN_HEIGHT, 0.50f * SCREEN_WIDTH, 0.1f * SCREEN_HEIGHT), "")) {
			Application.LoadLevel("Buttons");
			load_number = 1;
		} 
		
	}
}

