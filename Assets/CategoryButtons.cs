using UnityEngine;
using System.Collections;

public class CategoryButtons {

	//Button groups
	private GameObject buttonGroup1, 
					   buttonGroup2, 
					   buttonGroup3, 
					   buttonGroup4, 
					   buttonGroup5, 
					   buttonGroup6;

	//buttonGroup position
	private Vector3 pos1 = new Vector3 (0.5f, 0.4f, 0f),
					pos2 = new Vector3 (0.8f, 0.32f, 0f),
					pos3 = new Vector3 (0.8f, 0.18f, 0f),
					pos4 = new Vector3 (0.5f, 0.1f, 0f),
					pos5 = new Vector3 (0.2f, 0.18f, 0f),
					pos6 = new Vector3 (0.2f, 0.32f, 0f);
	private Vector3 buttonGroupScale = new Vector3(0.13f, 0.07f,0f);



	//used for button animation when touched/no touch
	private Texture2D buttonNoPress, buttonPress;
	private Vector2 deltaPosition;

	//used to detect which object is being touched
	private GUILayer hitTest;
	private GUIElement touchObject;
	private GUITexture curButton;

	//used for outputing
	private GUIText debugText;
	private float curTouchPositionx;
	private float curTouchPositiony;

	private Color midButtonColor;
	private float opacity;

	/*Constructor:
		Create the center and surrounding buttons
		numOfButtons: number of surrounding buttons
	*/

	public CategoryButtons(int numOfButtons){
		initializeButtons();
		//The center is positioned at (x,y) = (0.5, 0.25)
		switch(numOfButtons){
			//create 2 buttons and position them
			case 2: buttonGroup1.guiTexture.transform.position = new Vector3(0.2f, 0.25f, 0f);
					buttonGroup2.guiTexture.transform.position = new Vector3(0.8f, 0.25f, 0f);
					buttonGroup1.SetActive(true);
					buttonGroup2.SetActive(true);
					break;
			case 3: buttonGroup1.guiTexture.transform.position = pos1;
					buttonGroup2.guiTexture.transform.position = pos3;
					buttonGroup3.guiTexture.transform.position = pos5;
					buttonGroup1.SetActive(true);
					buttonGroup2.SetActive(true);
					buttonGroup3.SetActive(true);
					break;
			case 4: buttonGroup1.guiTexture.transform.position = pos2;
					buttonGroup2.guiTexture.transform.position = pos3;
					buttonGroup3.guiTexture.transform.position = pos5;
					buttonGroup4.guiTexture.transform.position = pos6;
					buttonGroup1.SetActive(true);
					buttonGroup2.SetActive(true);
					buttonGroup3.SetActive(true);
					buttonGroup4.SetActive(true);
					break;
			case 5: buttonGroup1.guiTexture.transform.position = pos1;
					buttonGroup2.guiTexture.transform.position = pos2;
					buttonGroup3.guiTexture.transform.position = pos3;
					buttonGroup4.guiTexture.transform.position = pos5;
					buttonGroup5.guiTexture.transform.position = pos6;
					buttonGroup1.SetActive(true);
					buttonGroup2.SetActive(true);
					buttonGroup3.SetActive(true);
					buttonGroup4.SetActive(true);
					buttonGroup5.SetActive(true);
					break;
			case 6: buttonGroup1.guiTexture.transform.position = pos1;
					buttonGroup2.guiTexture.transform.position = pos2;
					buttonGroup3.guiTexture.transform.position = pos3;
					buttonGroup4.guiTexture.transform.position = pos4;
					buttonGroup5.guiTexture.transform.position = pos5;
					buttonGroup6.guiTexture.transform.position = pos6;
					buttonGroup1.SetActive(true);
					buttonGroup2.SetActive(true);
					buttonGroup3.SetActive(true);
					buttonGroup4.SetActive(true);
					buttonGroup5.SetActive(true);
					buttonGroup6.SetActive(true);
					break;
		}
	}
	//Initialize the buttonGroup
	private void initializeButtons(){
		buttonGroup1 = new GameObject();
		buttonGroup2 = new GameObject();
		buttonGroup3 = new GameObject();
		buttonGroup4 = new GameObject();
		buttonGroup5 = new GameObject();
		buttonGroup6 = new GameObject();
		buttonGroup1.AddComponent("GUITexture");
		buttonGroup2.AddComponent("GUITexture");
		buttonGroup3.AddComponent("GUITexture");
		buttonGroup4.AddComponent("GUITexture");
		buttonGroup5.AddComponent("GUITexture");
		buttonGroup6.AddComponent("GUITexture");
		buttonGroup1.guiTexture.name = "Group1";
		buttonGroup2.guiTexture.name = "Group2";
		buttonGroup3.guiTexture.name = "Group3";
		buttonGroup4.guiTexture.name = "Group4";
		buttonGroup5.guiTexture.name = "Group5";
		buttonGroup6.guiTexture.name = "Group6";
		buttonGroup1.guiTexture.texture = (Texture2D)Resources.Load("button");
		buttonGroup2.guiTexture.texture = (Texture2D)Resources.Load("button");
		buttonGroup3.guiTexture.texture = (Texture2D)Resources.Load("button");
		buttonGroup4.guiTexture.texture = (Texture2D)Resources.Load("button");
		buttonGroup5.guiTexture.texture = (Texture2D)Resources.Load("button");
		buttonGroup6.guiTexture.texture = (Texture2D)Resources.Load("button");
		buttonGroup1.guiTexture.transform.localScale = buttonGroupScale;
		buttonGroup2.guiTexture.transform.localScale = buttonGroupScale;
		buttonGroup3.guiTexture.transform.localScale = buttonGroupScale;
		buttonGroup4.guiTexture.transform.localScale = buttonGroupScale;
		buttonGroup5.guiTexture.transform.localScale = buttonGroupScale;
		buttonGroup6.guiTexture.transform.localScale = buttonGroupScale;
		buttonGroup1.SetActive(false);
		buttonGroup2.SetActive(false);
		buttonGroup3.SetActive(false);
		buttonGroup4.SetActive(false);
		buttonGroup5.SetActive(false);
		buttonGroup6.SetActive(false);
	}
}




