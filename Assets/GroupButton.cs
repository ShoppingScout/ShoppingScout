using UnityEngine;
using System.Collections;

public class GroupButton {
	//========================== VARIABLES ============================

	// The button containing categories
	private GameObject groupButton;
	// The category buttons
	private GameObject cat1, cat2, cat3, cat4;
	// Total number of button group currently active 
	public static int Total_Number_Buttons = 0;
	public static int Total_Button_Group = 0;

	// Scale
	private Vector3 groupButtonScale = new Vector3(0.13f, 0.07f,0f);

	// Debug
	bool DEBUG = true;

	//========================== VARIABLES ============================
	// Constructor
	public GroupButton(Vector3 position, int posID){
		groupButton = new GameObject();
		groupButton.AddComponent("GUITexture");
		// Set button texture
		groupButton.guiTexture.texture = (Texture2D)Resources.Load("button");
		groupButton.guiTexture.name = "groupButton" + posID;
		groupButton.guiTexture.transform.position = position;
		// Scale
		setGroupButtonScale(groupButtonScale);		
	}
	// TOP -> RIGHT -> BOTTOM -> LEFT
	public void addCategory(int ID1, int ID2, int ID3, int ID4){
		float spacingx = 0.09f;
		float spacingy = 0.05f;

		if(ID1 != -1){
			cat1 = new GameObject();
			cat1.AddComponent("GUITexture");
			cat1.transform.localScale = new Vector3(0.05f,0.03f,1);
			cat1.guiTexture.texture = (Texture2D)Resources.Load("button");
			cat1.guiTexture.name = ID1.ToString();
			cat1.transform.position = new Vector3(groupButton.guiTexture.transform.position.x,
												  groupButton.guiTexture.transform.position.y + spacingy, 10f);
		}	
		if(ID2 != -1){
			cat2 = new GameObject();
			cat2.AddComponent("GUITexture");
			cat2.transform.localScale = new Vector3(0.05f,0.03f,1);
			cat2.guiTexture.texture = (Texture2D)Resources.Load("button");
			cat2.guiTexture.name = ID2.ToString();
			cat2.transform.position = new Vector3(groupButton.guiTexture.transform.position.x + spacingx,
												  groupButton.guiTexture.transform.position.y, 10f);
		}	
		if(ID3 != -1){
			cat3 = new GameObject();
			cat3.AddComponent("GUITexture");
			cat3.transform.localScale = new Vector3(0.05f,0.03f,1);
			cat3.guiTexture.texture = (Texture2D)Resources.Load("button");
			cat3.guiTexture.name = ID3.ToString();
			cat3.transform.position = new Vector3(groupButton.guiTexture.transform.position.x,
												  groupButton.guiTexture.transform.position.y- spacingy, 10f);
		}	
		if(ID4 != -1){
			cat4 = new GameObject();
			cat4.AddComponent("GUITexture");
			cat4.transform.localScale = new Vector3(0.05f,0.03f,1);
			cat4.guiTexture.texture = (Texture2D)Resources.Load("button");
			cat4.guiTexture.name = ID4.ToString();
			cat4.transform.position = new Vector3(groupButton.guiTexture.transform.position.x - spacingx,
												  groupButton.guiTexture.transform.position.y, 10f);
		}	
	}

	// move button by touch
	public void transformButton(string buttonName, float curTouchx, float curTouchy){
		
			switch (buttonName) {
				case "ButtonGroup1":
						groupButton.transform.position = new Vector3 (groupButton.transform.position.x, curTouchy+.02f, 7f);
						break;	
				case "ButtonGroup2":
						//curButton.transform.position = new Vector3 (curTouchPositionx, (-BUTTON_SLOPE * curTouchPositionx) + 0.366f, 7f);
						
						break;
				case "ButtonGroup3":
						//curButton.transform.position = new Vector3 (curButton.transform.position.x, curTouchPositiony+.02f, 7f);
						
						break;	
				case "ButtonGroup4":
						//curButton.transform.position = new Vector3 (curTouchPositionx, (BUTTON_SLOPE * curTouchPositionx) + 0.133f, 7f);
						
						break;
				case "ButtonGroup5":
						//curButton.transform.position = new Vector3 (curTouchPositionx, (-BUTTON_SLOPE * curTouchPositionx) + 0.366f, 7f);
						
						break;
					
				case "ButtonGroup6":
						//curButton.transform.position = new Vector3 (curTouchPositionx, (-BUTTON_SLOPE * curTouchPositionx) + 0.366f, 7f);
						
						break;
			}
					
	}

	// GroupButton movement
	public GameObject getGroupButton(){
		return groupButton;
	}

	public void setGroupButtonScale(Vector3 scale){
		groupButton.guiTexture.transform.localScale = scale;
	}

}