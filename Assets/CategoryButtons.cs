using UnityEngine;
using System.Collections;

public class CategoryButtons {

	//Button groups
	private ButtonGroup buttonGroup1, 
					    buttonGroup2, 
					    buttonGroup3, 
					    buttonGroup4, 
					    buttonGroup5, 
					    buttonGroup6;
	private ButtonGroup[] buttonGroupArray;
	
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
	//  The center is positioned at (x,y) = (0.5, 0.25)
	public CategoryButtons(int numOfButtons){
		if(numOfButtons < 1 || numOfButtons > 6)
			throw new System.ArgumentException("CategoryButton must be between 1 and 6");
		buttonGroupArray = new ButtonGroup[numOfButtons];
		for(int i=0;i<buttonGroupArray.Length;i++){
			buttonGroupArray[i] = new ButtonGroup();
		}
		
	}
	// set ButtonGroup position
	// numID: ButtonGroup position number, position: Vector3 position
	public void setPosition(int numID, Vector3 position){
		if(numID > buttonGroupArray.Length || numID < 0)
			throw new System.ArgumentException("setPosition: Invalid numID");
		buttonGroupArray[numID].setButtonGroupPosition(position);
	}

	// Set the number of category for ButtonGroup
	// numID: ButtonGroup position number, totalCategory: number of category for that ButtonGroup
	public void setCategoryNum(int numID, int totalCategory){
		if(numID > buttonGroupArray.Length || numID < 0)
			throw new System.ArgumentException("setCategoryNum: Invalid numID");
		else if(totalCategory > 4 || totalCategory < 1)
			throw new System.ArgumentException("setCategoryNum: Invalid totalCategory, must be between 1-4");
		buttonGroupArray[numID].addCategory(totalCategory);
		//set each category position
		buttonGroupArray[numID].setCategoryPosition();
	}
	// used for animation
	public void transformCategory(string buttonName, float curTouchx, float curTouchy){
		
			switch (buttonName) {
			case "ButtonGroup0":
					if((curTouchx > 0.4f && curTouchx < 0.6f) &&  (curTouchy > 0.155f && curTouchy < 0.27f)){
								//curButton.transform.position = new Vector3 (.5f, .25f, 7f);		
								buttonGroupArray[0].moveCategoryPosition(curTouchx, curTouchy);		
							}
					else
						buttonGroupArray[0].moveCategoryPosition(curTouchx, curTouchy);
					break;
			case "ButtonGroup1":
					//curButton.transform.position = new Vector3 (curTouchPositionx, (BUTTON_SLOPE * curTouchPositionx) + 0.133f, 7f);
					
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
				}	
		}
	
}


















