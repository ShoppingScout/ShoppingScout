using UnityEngine;
using System.Collections;

public class ButtonGroup {

	// The button containing categories
	private GameObject buttonGroup;
	// The category buttons
	private GameObject cat1, cat2, cat3, cat4;
	private GameObject [] categoryArray;
	// Total number of button group currently active 
	static int Total_Number_Buttons = 0;
	static int Total_Button_Group = 0;

	// Scale
	private Vector3 buttonGroupScale = new Vector3(0.13f, 0.07f,0f);
	
	// Constructor
	public ButtonGroup(){
		buttonGroup = new GameObject();
		buttonGroup.AddComponent("GUITexture");
		// Set button texture
		buttonGroup.guiTexture.texture = (Texture2D)Resources.Load("button");
		buttonGroup.guiTexture.name = "ButtonGroup" + Total_Button_Group;
		Total_Button_Group++;
		// Scale
		setButtonGroupScale(buttonGroupScale);


		
	}

	// Add Category
	// Pass in the number of category per button
	public void addCategory(int numOfCategory){
		// Each ButtonGroup has a categoryArray to access the category by index
		if(numOfCategory > 4 || numOfCategory < 1)
			throw new System.ArgumentException("The number of category must be between 1 and 4.");
		// Set array	
		categoryArray = new GameObject[5];
		
		// Setup categoryArray depending on number of category
		for(int i=1;i<5;i++){
				if(i<numOfCategory){
					categoryArray[i] = new GameObject();
					categoryArray[i].AddComponent("GUITexture");
					SetupCategory(categoryArray[i]);
					}//end if
				}//end for
		}		
	
	// Set ButtonGroupPosition
	public void setButtonGroupPosition(Vector3 position){
		buttonGroup.guiTexture.transform.position = position;
	}
	// Set Scale
	public void setButtonGroupScale(Vector3 scale){
		buttonGroup.guiTexture.transform.localScale = scale;
	}
	// Set each category name to corresponding position number and increment total number of category buttons
	private void SetupCategory(GameObject category){
		category.guiTexture.texture = (Texture2D)Resources.Load("button");
		category.transform.localScale = new Vector3(0.05f,0.03f,1);
		Total_Number_Buttons++;
		category.guiTexture.name = ""+Total_Number_Buttons;			
		category.guiTexture.transform.name = ""+Total_Number_Buttons;

	}

}
