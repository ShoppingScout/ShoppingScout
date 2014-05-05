
using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class LevelScript : MonoBehaviour {
    private Vector3 pos1, pos2, pos3, pos4, pos5, pos6, resetPos;
    public static GroupButton Button1, Button2, Button3, Button4, Button5, Button6;
	public static Item currentItem;
	int depth;
	GUIText pName;

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

    public LevelScript()
    {
    }

    //Switch to determine which layout and categories to load
    public void LoadLevelSettings(int level) {
		GameObject.Find("center").SetActive(true);
		pName = GameObject.Find ("GUIProductName").guiText;
		pName.gameObject.SetActive(true);
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
            GameObject.Find("Game Object Clock").GetComponent<Clock_Script>().SetStartTime(10);
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
        case 2:
            Button2 = new GroupButton(pos2, 2);
            Button2.addCategory(24017, 24015, 24013, 24012);
            Button3 = new GroupButton(pos3, 3);
            Button3.addCategory(28488, 23182, 23186, 24048);
            Button5 = new GroupButton(pos5, 5);
            Button5.addCategory(-1, 24002, 23105, 24008);
            Button6 = new GroupButton(pos6, 6);
            Button6.addCategory(24011, 24009, 24004, 24003);
            GameObject.Find("Game Object Clock").GetComponent<Clock_Script>().SetStartTime(30);
			depth = 2;
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
    public void Deinitialize() {
        GroupButton.deleteGroupButtons();
		GameObject.Find("GUIProductImg").guiTexture.texture = (Texture2D) Resources.Load("Smiley");
		pName.gameObject.SetActive(false);
		//Application.LoadLevel("Statistics");
		
    }
}

