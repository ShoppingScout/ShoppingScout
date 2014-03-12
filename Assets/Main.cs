using UnityEngine;
using System.Collections;
using System;

public class Main : MonoBehaviour {
	//============== VARIABLES =================
	public Texture btnTexture;
	public GUIStyle myGUIStyle;
	GroupButton button1, button2, button3, button4, button5, button6;
	private Vector3 pos1 = new Vector3 (0.5f, 0.4f, 0f),
					pos2 = new Vector3 (0.8f, 0.32f, 0f),
					pos3 = new Vector3 (0.8f, 0.18f, 0f),
					pos4 = new Vector3 (0.5f, 0.1f, 0f),
					pos5 = new Vector3 (0.2f, 0.18f, 0f),
					pos6 = new Vector3 (0.2f, 0.32f, 0f),
					resetPos;

	//used to detect which object is being touched
	private GUILayer hitTest;
	private GUIElement touchObject;
	private GUITexture curButton;

	//used for outputing
	private GUIText debugText;

	private float curTouchPositionx;
	private float curTouchPositiony;

	//Constants
	private const float BUTTON_SLOPE = (0.07f) / (0.3f);
	private int SCREEN_WIDTH = Screen.width;
	private int SCREEN_HEIGHT = Screen.height;

	// DEBUG
	private bool DEBUG = true;


    //============= VARIABLES END =============

	//=====================================================================//
	//================ START ==============================================//
	//=====================================================================//o
	void Start(){
		//for debug
		debugText = GameObject.Find ("DebugText").guiText;
		hitTest = Camera.main.GetComponent<GUILayer> ();

		button1 = new GroupButton(pos1, 1);
		button1.addCategory(3,2,4,1);
		button2 = new GroupButton(pos2, 2);
		button2.addCategory(3,2,4,1);
		button3 = new GroupButton(pos3, 3);
		button3.addCategory(3,2,4,1);
		button4 = new GroupButton(pos4, 4);
		button4.addCategory(3,2,4,1);
		button5 = new GroupButton(pos5, 5);
		button5.addCategory(3,2,4,1);
		button6 = new GroupButton(pos6, 6);
		button6.addCategory(3,2,4,1);


		//========= BUTTON ============
	}

	//=====================================================================//
	//================ UPDATE =============================================//
	//=====================================================================//
	void Update (){
		//========================= Button area =======================
		//is there a touch on screen?
			if (Input.touches.Length <= 0) {
					//if no touches	
				
					curButton = null;

			} else { //if there is touch	
					//execute this code for current touch[0] on screen
					
					if (Input.GetTouch (0).phase == TouchPhase.Began) {
							touchObject = hitTest.HitTest (Input.GetTouch (0).position);
							//get current touch position in decimal. [0-1]
							curTouchPositionx = Input.GetTouch (0).position.x / SCREEN_WIDTH;
							curTouchPositiony = Input.GetTouch(0).position.y / SCREEN_HEIGHT;			
							//get current touch button
							curButton = touchObject.guiTexture;			
							resetPos = curButton.transform.position;	
							
						}
					//================== End phase ===================
					if (Input.GetTouch (0).phase == TouchPhase.Ended) {				
							touchObject = hitTest.HitTest (Input.GetTouch (0).position);
							curButton.transform.position = resetPos;
							if(DEBUG){
									debugText.text = "Debug: finger pos: " + Input.GetTouch (0).position.x / Screen.width + ", " + Input.GetTouch (0).position.y / Screen.height 
									+ "\n" + touchObject.guiTexture.name + "\nbutton pos: " + curButton.transform.position.x + ", " + curButton.transform.position.y;
								}
						}
					
					//================== Button movement and animation ===================
					if (Input.GetTouch (0).phase == TouchPhase.Stationary || Input.GetTouch (0).phase == TouchPhase.Moved) {
							curTouchPositionx = Input.GetTouch (0).position.x / SCREEN_WIDTH;
							curTouchPositiony = Input.GetTouch(0).position.y / SCREEN_HEIGHT;

							// snap the dragging button to the center if it is near.
							if(curButton!=null && (curTouchPositionx > 0.4f && curTouchPositionx < 0.6f) &&  (curTouchPositiony > 0.155f && curTouchPositiony < 0.27f)){
								if(curButton.name.Equals("groupButton1") || curButton.name.Equals("groupButton2") ||
								   curButton.name.Equals("groupButton3") || curButton.name.Equals("groupButton4") ||
								   curButton.name.Equals("groupButton4") || curButton.name.Equals("groupButton6"))
										curButton.transform.position = new Vector3 (.5f, .25f, 7f);	
								//categoryButtons.transformCategory(curButton.name, curButton.transform.position.x, curTouchPositiony+0.02f);	
							}
							if(curButton.transform.position!=new Vector3 (.5f, .25f, 7f)){
								switch (curButton.name) {
								case "groupButton1":
										curButton.transform.position = new Vector3 (curButton.transform.position.x, curTouchPositiony+.02f, 7f);
										//button1.transformButton("ButtonGroup1", curTouchPositionx, curTouchPositiony);
										break;
								case "groupButton2":
										curButton.transform.position = new Vector3 (curTouchPositionx, (BUTTON_SLOPE * curTouchPositionx) + 0.133f, 7f);
		
										break;	
								case "groupButton3":
										curButton.transform.position = new Vector3 (curTouchPositionx, (-BUTTON_SLOPE * curTouchPositionx) + 0.366f, 7f);
										
										break;
								case "groupButton4":
										curButton.transform.position = new Vector3 (curButton.transform.position.x, curTouchPositiony+.02f, 7f);
										
										break;	
								case "groupButton5":
										curButton.transform.position = new Vector3 (curTouchPositionx, (BUTTON_SLOPE * curTouchPositionx) + 0.133f, 7f);
										
										break;
								case "groupButton6":
										curButton.transform.position = new Vector3 (curTouchPositionx, (-BUTTON_SLOPE * curTouchPositionx) + 0.366f, 7f);
										
										break;
								}	
								if(DEBUG){
									debugText.text = "Debug: finger pos: " + Input.GetTouch (0).position.x / Screen.width + ", " + Input.GetTouch (0).position.y / Screen.height 
									+ "\n" + curButton.name + "\nbutton pos: " + curButton.transform.position.x + ", " + curButton.transform.position.y;
								}		
							}
						}
					}

					



		//========================= Button area =======================
		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.GetKey(KeyCode.Escape))
			{
				Application.LoadLevel("Menu");
				//ButtonGroup.Total_Number_Buttons = 0;
				//ButtonGroup.Total_Button_Group = 0;	
				return;
			}
		}
	}
}