using UnityEngine;
using System.Collections;

public class ButtonGroup {
	//========================== VARIABLES ============================

	// The button containing categories
	private GameObject buttonGroup;
	// The category buttons
	private GameObject cat1, cat2, cat3, cat4;
	private GameObject [] categoryArray;
	// Total number of button group currently active 
	public static int Total_Number_Buttons = 0;
	public static int Total_Button_Group = 0;

	// Scale
	private Vector3 buttonGroupScale = new Vector3(0.13f, 0.07f,0f);

	// Debug
	bool DEBUG = true;

	//========================== VARIABLES ============================
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
		categoryArray = new GameObject[numOfCategory+1];
		
		// Setup categoryArray depending on number of category
		for(int i=1;i<categoryArray.Length;i++){
				categoryArray[i] = new GameObject();
				categoryArray[i].AddComponent("GUITexture");

				// for debugging
				if(DEBUG){
					categoryArray[i].AddComponent("GUIText");
				}
				// for debugging end
				SetupCategory(categoryArray[i]);
				Debug.Log(i);
		}//end for
	}		
	
	// Set ButtonGroupPosition
	public void setButtonGroupPosition(Vector3 position){
		buttonGroup.guiTexture.transform.position = position;
	}
	// return button group position
	public Vector3 getPosition(){
		return buttonGroup.guiTexture.transform.position;
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
		// for debugging
		if(DEBUG){
			category.guiText.material.color = Color.black;
			category.guiText.text = ""+Total_Number_Buttons;	
		}
		// for debugging end		
		category.guiTexture.transform.name = ""+Total_Number_Buttons;

	}
	// Set category button positions
	public void setCategoryPosition(){
		float posx = buttonGroup.guiTexture.transform.position.x;
		float posy = buttonGroup.guiTexture.transform.position.y;
		float posz = buttonGroup.guiTexture.transform.position.z;
		float spacingx = 0.09f;
		float spacingy = 0.05f;

		for(int i=1; i < categoryArray.Length;i++){
			if(i==1){
				categoryArray[i].guiTexture.transform.position = new Vector3(posx,posy+spacingy,posz+1);
			}

			else if(i==2)
				categoryArray[i].guiTexture.transform.position = new Vector3(posx+spacingx,posy,posz+1);
			else if(i==3)
				categoryArray[i].guiTexture.transform.position = new Vector3(posx,posy-spacingy,posz+1);
			else if(i==4)
				categoryArray[i].guiTexture.transform.position = new Vector3(posx-spacingx,posy,posz+1);
		}
	}
		// transition
		// Set category button positions
	public void moveCategoryPosition(float curTouchx, float curTouchy){
		float posx = buttonGroup.guiTexture.transform.position.x;
		float posy = buttonGroup.guiTexture.transform.position.y;
		float posz = buttonGroup.guiTexture.transform.position.z;
		float spacingx = 0.09f;
		float spacingy = 0.05f;
		if((curTouchx > 0.4f && curTouchx < 0.6f) &&  (curTouchy > 0.155f && curTouchy < 0.27f)){
			float snapx = 0.0f;
			float snapy = 0.25f;
			for(int i=1; i < categoryArray.Length;i++){
				if(i==1)
					categoryArray[i].guiTexture.transform.position = new Vector3(snapx,snapy+spacingy,posz+1);
				else if(i==2)
					categoryArray[i].guiTexture.transform.position = new Vector3(snapx+spacingx,snapy,posz+1);
				else if(i==3)
					categoryArray[i].guiTexture.transform.position = new Vector3(snapx,snapy-spacingy,posz+1);
				else if(i==4)
					categoryArray[i].guiTexture.transform.position = new Vector3(snapx-spacingx,snapy,posz+1);
			}	
			
		}
		else
		for(int i=1; i < categoryArray.Length;i++){
			if(i==1){
				categoryArray[i].guiTexture.transform.position = new Vector3(posx,curTouchy+spacingy,posz+1);
			}

			else if(i==2)
				categoryArray[i].guiTexture.transform.position = new Vector3(posx+spacingx,curTouchy,posz+1);
			else if(i==3)
				categoryArray[i].guiTexture.transform.position = new Vector3(posx,curTouchy-spacingy,posz+1);
			else if(i==4)
				categoryArray[i].guiTexture.transform.position = new Vector3(posx-spacingx,curTouchy,posz+1);
		}
	}

}
