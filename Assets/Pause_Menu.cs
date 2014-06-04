using UnityEngine;
using System.Collections;
using System;

public class Pause_Menu : MonoBehaviour {

    public GUISkin pauseSkin;
    private int SCREEN_WIDTH = Screen.width;
    private int SCREEN_HEIGHT = Screen.height;
    public bool paused = false;
    GameObject pImg, pName;
    Texture lastTexture;
    public static bool levelUpMenu = false;
	private bool done;

    // Use this for initialization
    void Start () {
        pImg = GameObject.Find("GUIProductImg");
        pName = GameObject.Find("GUIProductName");

    }

	void Update () {
		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.GetKey(KeyCode.Escape))
			{
				CollisionAnswer.jo.Call("vibrate2", 75);
				if(paused){
					paused = togglePause();
				}
				LevelScript.Deinitialize();
				Application.LoadLevel("Menu");
				return;
			}
		}
	}

    void OnGUI () {
        pauseSkin.button.fontSize = SCREEN_WIDTH/20;

        GUI.skin = pauseSkin;


		GameObject finished = GameObject.Find ("PlayerBalance");
		done = finished.GetComponent<Scoring_Money> ().done; 

        if (paused && !done) {

            pImg.guiTexture.texture = (Texture2D) Resources.Load("Smiley");
            pName.guiText.text = "Paused!";
            if (GUI.Button (new Rect (0.20f * SCREEN_WIDTH, 0.2f * SCREEN_HEIGHT, 0.60f * SCREEN_WIDTH, 0.07f * SCREEN_HEIGHT), "Unpause")) {
                paused = togglePause();
                GameObject.Find("GUIProductImg").guiTexture.texture = lastTexture;
                GameObject.Find("GUIProductName").guiText.text = LevelScript.currentItem.get_PName();
            }

            if (GUI.Button (new Rect (0.20f * SCREEN_WIDTH, 0.3f * SCREEN_HEIGHT, 0.60f * SCREEN_WIDTH, 0.07f * SCREEN_HEIGHT), "Main Menu")) {
                paused = togglePause ();
                LevelScript.Deinitialize();
                Application.LoadLevel("Menu");
            }
        }

        if(!paused && !done) {
            if (GUI.Button (new Rect (0.05f * SCREEN_WIDTH, 0.0075f * SCREEN_HEIGHT, 0.2f * SCREEN_WIDTH, 0.05f * SCREEN_HEIGHT), "Pause")) {
                paused = togglePause();
                lastTexture = pImg.guiTexture.texture;
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
	/*
	bool togglePause(bool on)
	{
		if (on) {
			Time.timeScale = 0f;
			return(true);
		}

		else {
			Time.timeScale = 1f;
			return (false);
		}
	}
	*/
}