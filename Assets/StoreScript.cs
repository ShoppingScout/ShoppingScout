using UnityEngine;
using System.Collections;
using System;

public class StoreScript : MonoBehaviour {

    public GUISkin storeSkin;
    private int SCREEN_WIDTH = Screen.width;
    private int SCREEN_HEIGHT = Screen.height;
	private int balance;
	private int currentRobotIndex;
    public bool paused = false;
    GUITexture RobotImg;
	GameObject playerBalance;
	GameObject statBox;
	GameObject itemCost;
    Texture lastTexture;
    public static bool levelUpMenu = false;


    // Use this for initialization
    void Start () {
		currentRobotIndex = 0;
        Debug.Log("Hello");
        RobotImg = GameObject.Find("RobotImg").guiTexture;
        RobotImg.texture = (Texture2D)Resources.Load("images/Robots/Green"+ PlayerPrefs.GetInt("startTimeBonusLevel",0), typeof(Texture2D));
		playerBalance = GameObject.Find("PlayerBalance");
		itemCost = GameObject.Find("itemCost");
		balance = PlayerPrefs.GetInt("Balance",0);
		playerBalance.guiText.text = "$ " + balance.ToString ();
		switch (currentRobotIndex){
			case 0: itemCost.guiText.text = " -" +  (PlayerPrefs.GetInt("startTimeBonusLevel",0)*1000 + 1000); break;
			default: itemCost.guiText.text = "Oops"; break;
		}

    }

    
        void OnGUI () {
            storeSkin.button.fontSize = SCREEN_WIDTH/20;

            GUI.skin = storeSkin;


            

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


