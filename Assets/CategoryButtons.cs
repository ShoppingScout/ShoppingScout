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
	}
}




