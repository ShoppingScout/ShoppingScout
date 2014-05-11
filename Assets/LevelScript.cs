
using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class LevelScript : MonoBehaviour {
    private static Vector3 pos1, pos2, pos3, pos4, pos5, pos6, resetPos;
    public static GroupButton Button1, Button2, Button3, Button4, Button5, Button6;
	public static Item currentItem;
	static int depth;
	static GUIText pName;

    //Default position of buttons
    private void Awake()
    {
        pos1 = new Vector3 (0.5f, 0.4f, 0f);
        pos2 = new Vector3 (0.8f, 0.32f, 0f);
        pos3 = new Vector3 (0.8f, 0.18f, 0f);
        pos4 = new Vector3 (0.5f, 0.1f, 0f);
        pos5 = new Vector3 (0.2f, 0.18f, 0f);
        pos6 = new Vector3 (0.2f, 0.32f, 0f);
    }

    void Start() {
    }


    //Switch to determine which layout and categories to load
    public static void LoadLevelSettings(int level) {
		GUIText debugText = GameObject.Find ("DebugText").guiText;
		//fdebugText.text = "here";
		GameObject.Find("center").SetActive(true);
		
		pName = GameObject.Find ("GUIProductName").guiText;
		pName.gameObject.SetActive(true);
		LevelUp.startStage();
        switch (level) {
		/* Buttons
			1
		6		2		
		5		3
			4
		*/
        case 1:
			//GUIText debugText = GameObject.Find ("DebugText").guiText;
			//debugText.text = Application.persistentDataPath;
            Button1 = new GroupButton(pos1, 1);
            Button1.addCategory(4,5,2,28242);
            Button4 = new GroupButton(pos4, 4);
            Button4.addCategory(28347,6,-1,3);
            GameObject.Find("Game Object Clock").GetComponent<Clock_Script>().SetStartTime(10 + PlayerPrefs.GetInt("startTimeBonusLevel",0) * PlayerPrefs.GetFloat("startTimeBonusFactor",0));
			depth = 1;
			GameObject.Find("Scripts").GetComponent<Product_DB>().StartStackKnown(0, 9);
			GameObject.Find("Scripts").GetComponent<Product_DB>().StartStackUnknown(12,15);
			currentItem = GameObject.Find("Scripts").GetComponent<Product_DB>().next_Item();
			//GameObject.Find("GUIProductImg").guiTexture.texture = (Texture2D) Resources.Load("Sample_pictures/"+currentItem.get_IMG());
            pName.color = Color.white;
            pName.fontSize = (int)(Screen.width/15);
            pName.anchor = TextAnchor.MiddleCenter;
            pName.transform.localPosition = new Vector3 (.5f,.55f,11f);
            pName.pixelOffset = new Vector2(0,Screen.height / -10);


			GameObject scorer = GameObject.Find ("PlayerBalance");
			scorer.GetComponent <Scoring_Money> ().initialize(depth);


            //GameObject.Find("Button0").turnOn(1,3,4,2);
            //GameObject.Find("Button1").turnOn(5,7,8,6);
			
            break;
        case 3:
            Button1 = new GroupButton(pos1, 1);
            Button1.addCategory(4,5,2,28242);
            Button2 = new GroupButton(pos2, 2);
            Button2.addCategory(4,5,2,28242);
            Button3 = new GroupButton(pos3, 3);
            Button3.addCategory(4,5,2,28242);
            Button4 = new GroupButton(pos4, 4);
            Button4.addCategory(4,5,2,28242);
            Button5 = new GroupButton(pos5, 5);
            Button5.addCategory(4,5,2,28242);
            Button6 = new GroupButton(pos6, 6);
            Button6.addCategory(4,5,2,28242);
            GameObject.Find("Game Object Clock").GetComponent<Clock_Script>().SetStartTime(30);
			depth = 2;
			
            break;
        }
    }

    //Function to make buttons invisible when timer runs out
    public static void Deinitialize() {
        GroupButton.deleteGroupButtons();
		GameObject.Find("GUIProductImg").guiTexture.texture = (Texture2D) Resources.Load("Smiley");
		pName.gameObject.SetActive(false);
		LevelUp.checkLevelUp();
		Pause_Menu.levelUpMenu = false;

		GameObject.Find ("PlayerBalance").GetComponent <Scoring_Money> ().Deinitialize();

		//Application.LoadLevel("Statistics");
		
    }
}

