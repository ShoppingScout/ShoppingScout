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


    void OnGUI () {
        pauseSkin.button.fontSize = SCREEN_WIDTH/20;

        GUI.skin = pauseSkin;
        pauseSkin.customStyles[0] = new GUIStyle(pauseSkin.button);
        pauseSkin.customStyles[0].name = "LevelUpStyle";
        pauseSkin.customStyles[0].normal.textColor = Color.red;

        pauseSkin.customStyles[1] = new GUIStyle(pauseSkin.button);
        pauseSkin.customStyles[1].name = "startTimeStyle";
        pauseSkin.customStyles[1].normal.textColor = Color.red;

        pauseSkin.customStyles[2] = new GUIStyle(pauseSkin.button);
        pauseSkin.customStyles[2].name = "answerTimeStyle";
        pauseSkin.customStyles[2].normal.textColor = Color.blue;

        pauseSkin.customStyles[3] = new GUIStyle(pauseSkin.button);
        pauseSkin.customStyles[3].name = "startMultStyle";
        pauseSkin.customStyles[3].normal.textColor = Color.green;

        pauseSkin.customStyles[4] = new GUIStyle(pauseSkin.button);
        pauseSkin.customStyles[4].name = "streakMultStyle";
        pauseSkin.customStyles[4].normal.textColor = Color.yellow;

        pauseSkin.customStyles[5] = new GUIStyle(pauseSkin.button);
        pauseSkin.customStyles[5].name = "Maxed Out";
        pauseSkin.customStyles[5].normal.textColor = Color.grey;

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
            }/*
            else if (levelUpMenu) {

                pImg.guiTexture.texture = (Texture2D) Resources.Load("Smiley");
                pName.guiText.text = "levelUpMenu!";

                //Start Time Bonus
                if (PlayerPrefs.GetInt ("startTimeBonusLevel", 0) < 6) {
                    if (GUI.Button (new Rect (0.10f * SCREEN_WIDTH, 0.2f * SCREEN_HEIGHT, 0.30f * SCREEN_WIDTH, 0.07f * SCREEN_HEIGHT), "Red: " + PlayerPrefs.GetInt ("startTimeBonusLevel", 0), pauseSkin.customStyles[1])) {
                        levelUpMenu = toggleLevelUpMenu();
                        LevelUp.levelUp();
                        GameObject.Find("GUIProductImg").guiTexture.texture = lastTexture;
                        try {
                            GameObject.Find("GUIProductName").guiText.text = LevelScript.currentItem.get_PName();
                        }
                        catch (Exception e) {}
                        PlayerPrefs.SetInt("startTimeBonusLevel", PlayerPrefs.GetInt ("startTimeBonusLevel", 0) + 1);
                        PlayerPrefs.SetInt("LevelUp", 0);
                        LevelUp.checkLevelUp();
                    }
                }
                else {//If maxed, do nothing{
                    if (GUI.Button (new Rect (0.10f * SCREEN_WIDTH, 0.2f * SCREEN_HEIGHT, 0.30f * SCREEN_WIDTH, 0.07f * SCREEN_HEIGHT), "Red: 6 (MAX)", pauseSkin.customStyles[5])) {
                    }
                }

                //Answer Time Bonus
                if (PlayerPrefs.GetInt ("answerTimeBonusLevel", 0) < 6) {
                    if (GUI.Button (new Rect (0.10f * SCREEN_WIDTH, 0.3f * SCREEN_HEIGHT, 0.30f * SCREEN_WIDTH, 0.07f * SCREEN_HEIGHT), "Blue: " + PlayerPrefs.GetInt ("answerTimeBonusLevel", 0), pauseSkin.customStyles[2])) {
                        levelUpMenu = toggleLevelUpMenu ();
                        LevelUp.levelUp();
                        GameObject.Find("GUIProductImg").guiTexture.texture = lastTexture;
                        try {
                            GameObject.Find("GUIProductName").guiText.text = LevelScript.currentItem.get_PName();
                        }
                        catch (Exception e) {}
                        PlayerPrefs.SetInt("answerTimeBonusLevel", PlayerPrefs.GetInt ("answerTimeBonusLevel", 0) + 1);
                        PlayerPrefs.SetInt("LevelUp", 0);
                        LevelUp.checkLevelUp();
                    }
                }
                else {//If maxed, do nothing{
                    if (GUI.Button (new Rect (0.10f * SCREEN_WIDTH, 0.3f * SCREEN_HEIGHT, 0.30f * SCREEN_WIDTH, 0.07f * SCREEN_HEIGHT), "Blue: 6 (MAX)", pauseSkin.customStyles[5])) {
                    }
                }
                //Start Mult. Bonus
                if (PlayerPrefs.GetInt ("startMultBonusLevel", 0) < 6) {
                    if (GUI.Button (new Rect (0.60f * SCREEN_WIDTH, 0.2f * SCREEN_HEIGHT, 0.30f * SCREEN_WIDTH, 0.07f * SCREEN_HEIGHT), "Green: " + PlayerPrefs.GetInt ("startMultBonusLevel", 0), pauseSkin.customStyles[3])) {
                        levelUpMenu = toggleLevelUpMenu();
                        LevelUp.levelUp();
                        GameObject.Find("GUIProductImg").guiTexture.texture = lastTexture;
                        try {
                            GameObject.Find("GUIProductName").guiText.text = LevelScript.currentItem.get_PName();
                        }
                        catch (Exception e) {}
                        PlayerPrefs.SetInt("startMultBonusLevel", PlayerPrefs.GetInt ("startMultBonusLevel", 0) + 1);
                        PlayerPrefs.SetInt("LevelUp", 0);
                        LevelUp.checkLevelUp();
                    }

                }
                else { //If maxed, do nothing{
                    if (GUI.Button (new Rect (0.60f * SCREEN_WIDTH, 0.2f * SCREEN_HEIGHT, 0.30f * SCREEN_WIDTH, 0.07f * SCREEN_HEIGHT), "Green: 6 (MAX)", pauseSkin.customStyles[5])) {
                    }
                }
                //Streak Mult. Bonus
                if (PlayerPrefs.GetInt ("streakMultBonusLevel", 0) < 6) {
                    if (GUI.Button (new Rect (0.60f * SCREEN_WIDTH, 0.3f * SCREEN_HEIGHT, 0.30f * SCREEN_WIDTH, 0.07f * SCREEN_HEIGHT), "Yellow: " + PlayerPrefs.GetInt ("streakMultBonusLevel", 0), pauseSkin.customStyles[4])) {
                        levelUpMenu = toggleLevelUpMenu ();
                        LevelUp.levelUp();
                        GameObject.Find("GUIProductImg").guiTexture.texture = lastTexture;
                        try {
                            GameObject.Find("GUIProductName").guiText.text = LevelScript.currentItem.get_PName();
                        }
                        catch (Exception e) {}
                        PlayerPrefs.SetInt("streakMultBonusLevel", PlayerPrefs.GetInt ("streakMultBonusLevel", 0) + 1);
                        PlayerPrefs.SetInt("LevelUp", 0);
                        LevelUp.
                        checkLevelUp();
                    }
                }
                else {//If maxed, do nothing{
                    if (GUI.Button (new Rect (0.60f * SCREEN_WIDTH, 0.3f * SCREEN_HEIGHT, 0.30f * SCREEN_WIDTH, 0.07f * SCREEN_HEIGHT), "Yellow: 6 (MAX)", pauseSkin.customStyles[5])) {
                    }
                }
            }

            else if (PlayerPrefs.GetInt("LevelUp",0) == 1) {
                if (GUI.Button (new Rect (0.7f * SCREEN_WIDTH, 0.9f * SCREEN_HEIGHT, 0.25f * SCREEN_WIDTH, 0.05f * SCREEN_HEIGHT), "Level Up", pauseSkin.customStyles[0])) {
                    levelUpMenu = toggleLevelUpMenu();
                    lastTexture = pImg.guiTexture.texture;
                }
            }*/
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

    bool toggleLevelUpMenu()
    {
        if (Time.timeScale == 0f) {
            Time.timeScale = 1f;
        }
        else {
            Time.timeScale = 0f;
        }
        return (!levelUpMenu);
    }
}

