using UnityEngine;
using System.Collections;

public class Read_Scores : MonoBehaviour {

	private GUIText text_box;
	private int SCREEN_WIDTH = Screen.width;
	private int SCREEN_HEIGHT = Screen.height;


	// Use this for initialization
	void Start () {
		text_box = GameObject.Find ("Stats").guiText;
		Print_Scores();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI () {

		if (GUI.Button (new Rect (0.20f * SCREEN_WIDTH, 0.8f * SCREEN_HEIGHT, 0.60f * SCREEN_WIDTH, 0.07f * SCREEN_HEIGHT), "Main Menu")) {
			Application.LoadLevel("Menu");
		}
	}
		
	void Print_Scores () {
		text_box.text = "Balance: " + PlayerPrefs.GetInt("Balance").ToString();
		
	}
}