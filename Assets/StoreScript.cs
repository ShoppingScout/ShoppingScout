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
    int itemPrice;
    Texture lastTexture;
    public static bool levelUpMenu = false;
	GUIText Stat1Bonus;
	GUIText Stat1BonusExplanation;
	GUIText Stat1Level;
	GUIText Stat1Title;
	GUIText Stat2Bonus;
	GUIText Stat2BonusExplanation;
	GUIText Stat2Level;
	GUIText Stat2Title;
	GUIText Stat3Bonus;
	GUIText Stat3BonusExplanation;
	GUIText Stat3Level;
	GUIText Stat3Title;
	GUIText Stat4Bonus;
	GUIText Stat4BonusExplanation;
	GUIText Stat4Level;
	GUIText Stat4Title;

    // Use this for initialization
    void Start () {
//		PlayerPrefs.SetInt("Balance", 100000000);


        currentRobotIndex = 0;
        RobotImg = GameObject.Find("RobotImg").guiTexture;
        RobotImg.texture = (Texture2D)Resources.Load("images/Robots/Red"+ PlayerPrefs.GetInt("startTimeBonusLevel",0), typeof(Texture2D));
        playerBalance = GameObject.Find("PlayerBalance");
        itemCost = GameObject.Find("itemCost");
        balance = PlayerPrefs.GetInt("Balance",0);
        playerBalance.guiText.text = "$ " + balance.ToString ();
        switch (currentRobotIndex) {
        case 0:            itemCost.guiText.text = " -" +  (PlayerPrefs.GetInt("startTimeBonusLevel",0)*1000 + 1000);            itemPrice = (PlayerPrefs.GetInt("startTimeBonusLevel",0)*1000 + 1000);            break;
        default:            itemCost.guiText.text = "Oops";            break;
        }
		purchaseColor();
		
		Stat1Bonus = GameObject.Find("Stat1Bonus").guiText;
		Stat1BonusExplanation = GameObject.Find("Stat1BonusExplanation").guiText;
		Stat1Level = GameObject.Find("Stat1Level").guiText;
		Stat1Title = GameObject.Find("Stat1Title").guiText;
		
		Stat2Bonus = GameObject.Find("Stat2Bonus").guiText;
		Stat2BonusExplanation = GameObject.Find("Stat2BonusExplanation").guiText;
		Stat2Level = GameObject.Find("Stat2Level").guiText;
		Stat2Title = GameObject.Find("Stat2Title").guiText;
		
		Stat3Bonus = GameObject.Find("Stat3Bonus").guiText;
		Stat3BonusExplanation = GameObject.Find("Stat3BonusExplanation").guiText;
		Stat3Level = GameObject.Find("Stat3Level").guiText;
		Stat3Title = GameObject.Find("Stat3Title").guiText;
		
		Stat4Bonus = GameObject.Find("Stat4Bonus").guiText;
		Stat4BonusExplanation = GameObject.Find("Stat4BonusExplanation").guiText;
		Stat4Level = GameObject.Find("Stat4Level").guiText;
		Stat4Title = GameObject.Find("Stat4Title").guiText;
		
		Stat1Bonus.fontSize = (int)(Screen.width/15); 
		Stat1BonusExplanation.fontSize = (int)(Screen.width/30);
		Stat1Level.fontSize = (int)(Screen.width/30);
		Stat1Title.fontSize = (int)(Screen.width/27);
		
		Stat2Bonus.fontSize = (int)(Screen.width/15);
		Stat2BonusExplanation.fontSize = (int)(Screen.width/30);
		Stat2Level.fontSize = (int)(Screen.width/30);
		Stat2Title.fontSize = (int)(Screen.width/27);
		
		Stat3Bonus.fontSize = (int)(Screen.width/15);
		Stat3BonusExplanation.fontSize = (int)(Screen.width/30);
		Stat3Level.fontSize = (int)(Screen.width/30);
		Stat3Title.fontSize = (int)(Screen.width/27);
		
		Stat4Bonus.fontSize = (int)(Screen.width/15);
		Stat4BonusExplanation.fontSize = (int)(Screen.width/30);
		Stat4Level.fontSize = (int)(Screen.width/30);
		Stat4Title.fontSize = (int)(Screen.width/27);
		
		Stat1Level.text = "Level: " + PlayerPrefs.GetInt("startTimeBonusLevel", 0) + "/6"    ;
		Stat2Level.text = "Level: " + PlayerPrefs.GetInt("answerTimeBonusLevel", 0) + "/6"   ;
		Stat3Level.text = "Level: " + PlayerPrefs.GetInt("startMultBonusLevel", 0) + "/6"    ;
		Stat4Level.text = "Level: " + PlayerPrefs.GetInt("streakMultBonusLevel", 0) + "/6"   ;
		
		Stat1Bonus.text = ""+PlayerPrefs.GetFloat("startTimeBonusFactor",0) * PlayerPrefs.GetInt("startTimeBonusLevel",0)   + " sec";
		Stat2Bonus.text = ""+PlayerPrefs.GetFloat("answerTimeBonusFactor",0) * PlayerPrefs.GetInt("answerTimeBonusLevel",0) + " sec";
		Stat3Bonus.text = ""+PlayerPrefs.GetFloat("startMultBonusFactor",0) * PlayerPrefs.GetInt("startMultBonusLevel",0)   + "x";
		Stat4Bonus.text = ""+PlayerPrefs.GetFloat("streakMultBonusFactor",0) * PlayerPrefs.GetInt("streakMultBonusLevel",0) + "x";
	}
	


    void OnGUI () {
        storeSkin.button.fontSize = SCREEN_WIDTH/15;

        GUI.skin = storeSkin;
        
			
		if (currentRobotIndex > 0){
			if (GUI.Button (new Rect (0.03f * SCREEN_WIDTH, 0.08f * SCREEN_HEIGHT, 0.13f * SCREEN_WIDTH, 0.13f * SCREEN_HEIGHT), "", storeSkin.customStyles[0])){
				currentRobotIndex--;
				switch (currentRobotIndex) {
					case 0:  
						itemCost.guiText.text = " -" +  (PlayerPrefs.GetInt("startTimeBonusLevel",0)*1000 + 1000);
						itemPrice = (PlayerPrefs.GetInt("startTimeBonusLevel",0)*1000 + 1000);
						RobotImg.texture = (Texture2D)Resources.Load("images/Robots/Red"+ PlayerPrefs.GetInt("startTimeBonusLevel",0), typeof(Texture2D));
						break;
					case 1:  
						itemCost.guiText.text = " -" +  (PlayerPrefs.GetInt("answerTimeBonusLevel",0)*1000 + 1000);
						itemPrice = (PlayerPrefs.GetInt("answerTimeBonusLevel",0)*1000 + 1000);
						RobotImg.texture = (Texture2D)Resources.Load("images/Robots/Blue"+ PlayerPrefs.GetInt("answerTimeBonusLevel",0), typeof(Texture2D));
						break;
					case 2:  
						itemCost.guiText.text = " -" +  (PlayerPrefs.GetInt("startMultBonusLevel",0)*1000 + 1000);
						itemPrice = (PlayerPrefs.GetInt("startMultBonusLevel",0)*1000 + 1000);
						RobotImg.texture = (Texture2D)Resources.Load("images/Robots/Green"+ PlayerPrefs.GetInt("startMultBonusLevel",0), typeof(Texture2D));
						break;
					default: break;
				}
				purchaseColor();
			}
		}
		if (currentRobotIndex < 3){
			if (GUI.Button (new Rect (0.43f * SCREEN_WIDTH, 0.08f * SCREEN_HEIGHT, 0.13f * SCREEN_WIDTH, 0.13f * SCREEN_HEIGHT), "", storeSkin.customStyles[1])){
				currentRobotIndex++;
				switch (currentRobotIndex) {
					case 1:  
						itemCost.guiText.text = " -" +  (PlayerPrefs.GetInt("answerTimeBonusLevel",0)*1000 + 1000);
						itemPrice = (PlayerPrefs.GetInt("answerTimeBonusLevel",0)*1000 + 1000);
						RobotImg.texture = (Texture2D)Resources.Load("images/Robots/Blue"+ PlayerPrefs.GetInt("answerTimeBonusLevel",0), typeof(Texture2D));
						break;
					case 2:  
						itemCost.guiText.text = " -" +  (PlayerPrefs.GetInt("startMultBonusLevel",0)*1000 + 1000);
						itemPrice = (PlayerPrefs.GetInt("startMultBonusLevel",0)*1000 + 1000);
						RobotImg.texture = (Texture2D)Resources.Load("images/Robots/Green"+ PlayerPrefs.GetInt("startMultBonusLevel",0), typeof(Texture2D));
						break;
					case 3:  
						itemCost.guiText.text = " -" +  (PlayerPrefs.GetInt("streakMultBonusLevel",0)*1000 + 1000);
						itemPrice = (PlayerPrefs.GetInt("streakMultBonusLevel",0)*1000 + 1000);
						RobotImg.texture = (Texture2D)Resources.Load("images/Robots/Yellow"+ PlayerPrefs.GetInt("streakMultBonusLevel",0), typeof(Texture2D));
						break;
					default: break;
				}
				purchaseColor();
			}
		}
		
        if (GUI.Button (new Rect (0.0f * SCREEN_WIDTH, 0.91f * SCREEN_HEIGHT, 0.60f * SCREEN_WIDTH, 0.09f * SCREEN_HEIGHT), "Purchase"))
            if (balance >= itemPrice) {

				int prevLvl = (PlayerPrefs.GetInt ("startTimeBonusLevel",0)*1000) + (PlayerPrefs.GetInt("answerTimeBonusLevel",0)*100)
					+ (PlayerPrefs.GetInt("startMultBonusLevel",0)*10) + PlayerPrefs.GetInt("streakMultBonusLevel",0);
				PlayerPrefs.SetInt("PrevLvls", prevLvl);
			UnityEngine.Debug.Log("PrevLvls = " + PlayerPrefs.GetInt ("PrevLvls"));

				balance -= itemPrice;
				PlayerPrefs.SetInt("Balance", balance);
				playerBalance.guiText.text = "$ " + PlayerPrefs.GetInt("Balance", 0);
				switch (currentRobotIndex) {
					case 0:  
						PlayerPrefs.SetInt("startTimeBonusLevel", PlayerPrefs.GetInt("startTimeBonusLevel",0)+1);
						itemCost.guiText.text = " -" +  (PlayerPrefs.GetInt("startTimeBonusLevel",0)*1000 + 1000);
						itemPrice = (PlayerPrefs.GetInt("startTimeBonusLevel",0)*1000 + 1000);
						RobotImg.texture = (Texture2D)Resources.Load("images/Robots/Red"+ PlayerPrefs.GetInt("startTimeBonusLevel",0), typeof(Texture2D));
						Stat1Level.text = "Level: " + PlayerPrefs.GetInt("startTimeBonusLevel", 0) + "/6"    ;
						Stat1Bonus.text = ""+PlayerPrefs.GetFloat("startTimeBonusFactor",0) * PlayerPrefs.GetInt("startTimeBonusLevel",0)+ " sec";
						break;
					case 1:  
						PlayerPrefs.SetInt("answerTimeBonusLevel", PlayerPrefs.GetInt("answerTimeBonusLevel",0)+1);
						itemCost.guiText.text = " -" +  (PlayerPrefs.GetInt("answerTimeBonusLevel",0)*1000 + 1000);
						itemPrice = (PlayerPrefs.GetInt("answerTimeBonusLevel",0)*1000 + 1000);
						RobotImg.texture = (Texture2D)Resources.Load("images/Robots/Blue"+ PlayerPrefs.GetInt("answerTimeBonusLevel",0), typeof(Texture2D));
						Stat2Level.text = "Level: " + PlayerPrefs.GetInt("answerTimeBonusLevel", 0) + "/6"   ;
						Stat2Bonus.text = ""+PlayerPrefs.GetFloat("answerTimeBonusFactor",0) * PlayerPrefs.GetInt("answerTimeBonusLevel",0)+ " sec";
						break;
					case 2:  
						PlayerPrefs.SetInt("startMultBonusLevel", PlayerPrefs.GetInt("startMultBonusLevel",0)+1);
						itemCost.guiText.text = " -" +  (PlayerPrefs.GetInt("startMultBonusLevel",0)*1000 + 1000);
						itemPrice = (PlayerPrefs.GetInt("startMultBonusLevel",0)*1000 + 1000);
						RobotImg.texture = (Texture2D)Resources.Load("images/Robots/Green"+ PlayerPrefs.GetInt("startMultBonusLevel",0), typeof(Texture2D));
						Stat3Level.text = "Level: " + PlayerPrefs.GetInt("startMultBonusLevel", 0) + "/6"    ;
						Stat3Bonus.text = ""+PlayerPrefs.GetFloat("startMultBonusFactor",0) * PlayerPrefs.GetInt("startMultBonusLevel",0)+"x";
						break;
					case 3:  
						PlayerPrefs.SetInt("streakMultBonusLevel", PlayerPrefs.GetInt("streakMultBonusLevel",0)+1);
						itemCost.guiText.text = " -" +  (PlayerPrefs.GetInt("streakMultBonusLevel",0)*1000 + 1000);
						itemPrice = (PlayerPrefs.GetInt("streakMultBonusLevel",0)*1000 + 1000);
						RobotImg.texture = (Texture2D)Resources.Load("images/Robots/Yellow"+ PlayerPrefs.GetInt("streakMultBonusLevel",0), typeof(Texture2D));
						Stat4Level.text = "Level: " + PlayerPrefs.GetInt("streakMultBonusLevel", 0) + "/6"   ;
						Stat4Bonus.text = ""+PlayerPrefs.GetFloat("streakMultBonusFactor",0) * PlayerPrefs.GetInt("streakMultBonusLevel",0)+"x";
						break;
					default: break;

				}
				purchaseColor();
				int finalLvl = (PlayerPrefs.GetInt ("startTimeBonusLevel",0)*1000) + (PlayerPrefs.GetInt("answerTimeBonusLevel",0)*100)
				+ (PlayerPrefs.GetInt("startMultBonusLevel",0)*10) + PlayerPrefs.GetInt("streakMultBonusLevel",0);
				PlayerPrefs.SetInt("FinalLvls", finalLvl);
				UnityEngine.Debug.Log("FinalLvls = " + PlayerPrefs.GetInt ("FinalLvls"));
			}
    }

    void Update () {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                CollisionAnswer.jo.Call("vibrate2", 75);
                Application.LoadLevel("Menu");
                return;
            }
        }
    }

	void purchaseColor(){
		if (itemPrice > balance)
            storeSkin.button.active.textColor = Color.white;
        else
            switch (currentRobotIndex) {
				case 0:                	storeSkin.button.active.textColor = new Color(254f/255,18f/255,43f/255);               	break;
				case 1: 				storeSkin.button.active.textColor = new Color(35f/255,76f/255,175f/255);               	break;
				case 2:					storeSkin.button.active.textColor = new Color(35f/255,174f/255,76f/255);				break;	
				case 3:					storeSkin.button.active.textColor = new Color(227f/255,252f/255,46f/255);				break;	
				default:                break;
            }
		switch (currentRobotIndex) {
				case 0:                	storeSkin.button.normal.textColor = new Color(254f/255,18f/255,43f/255);               	break;
				case 1: 				storeSkin.button.normal.textColor = new Color(35f/255,76f/255,175f/255);               	break;
				case 2:					storeSkin.button.normal.textColor = new Color(35f/255,174f/255,76f/255);				break;	
				case 3:					storeSkin.button.normal.textColor = new Color(227f/255,252f/255,46f/255);				break;	
				default:                break;
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



