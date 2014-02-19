using UnityEngine;
using System.Collections;
using System;

public class Item{
	//so from baby to unknown, the categories will correspond to an int from 0 to 7
	//public int Level_1 { get; set; }
	//public int Level_1;
	/*Future levels
	public int Level_Baby { get; set; }
	public int Level_Beauty { get; set; }
	...*/
	/*
	//public string FileName { get; set; } //filename for image

    public Item(int level_1){
        Level_1 = level_1;
		//FileName = filename;
    }//item

	*/

	// Field 
	public string name;
	
	// Constructor that takes no arguments. 
	public Item()
	{
		name = "unknown";
	}
	
	// Constructor that takes one argument. 
	public Item(string nm)
	{
		name = nm;
	}
	
	// Method 
	public void SetName(string newName)
	{
		name = newName;
	}
}//item

public class Main : MonoBehaviour {
	//============== VARIABLES =================
	public Texture btnTexture;
	public GUIStyle myGUIStyle;
	
	private Vector3 pos1 = new Vector3 (0.5f, 0.4f, 0f),
					pos2 = new Vector3 (0.8f, 0.32f, 0f),
					pos3 = new Vector3 (0.8f, 0.18f, 0f),
					pos4 = new Vector3 (0.5f, 0.1f, 0f),
					pos5 = new Vector3 (0.2f, 0.18f, 0f),
					pos6 = new Vector3 (0.2f, 0.32f, 0f);

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


    //============= VARIABLES END =============

	void Start(){
		//pretend this is the first install, every time
		//later we will make this value permanently set for non-first installs
		bool first_install = true;

		//First check whether or not this is the user's first install
		if(first_install == true){
			//If it is, create a data structure of Items with their image filenames and categories (int 0-7)
			Item[] items = new Item[5];
			int i = 0;

			//Random random = new Random();
			//int r = Random.Range(0, 7);

			//here we would normally import info from the database
			//but instead we'll make sure random sample products
			//here we'll use Emmanuel's product selection function
			while(i < 5) {
				//items[0].Level_1 = whatever the category is 0-7
				//items[i].Level_1 = r;
				//items[i].name = "test";
				i++;
			}
		}//if
		
		CategoryButtons categoryButtons = new CategoryButtons(6);
		//  (button ID, Vector3 button position)
		categoryButtons.setPosition(0,pos1);
		categoryButtons.setPosition(1,pos2);
		categoryButtons.setPosition(2,pos3);
		categoryButtons.setPosition(3,pos4);
		categoryButtons.setPosition(4,pos5);
		categoryButtons.setPosition(5,pos6);
		//  (button ID, int number of category)
		categoryButtons.setCategoryNum(0,4);
		categoryButtons.setCategoryNum(1,4);
		categoryButtons.setCategoryNum(2,4);
		categoryButtons.setCategoryNum(3,4);
		categoryButtons.setCategoryNum(4,4);
		categoryButtons.setCategoryNum(5,4);

		
		//while timer != 0
		
			//get current item's category

			//get user input
			
			//check if user input is same as item's category
				//if item category is 0, put user input into item's category
				//else if, user input == item category execute scoring.correct
				//else, user is wrong so execute scoring.incorrect
				
		//make game end when timer runs out
		// ========= BUTTON ============
		//used for returning the GameObject that is being touched.
		hitTest = Camera.main.GetComponent<GUILayer> ();

		//========= BUTTON ============
	}

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

							curButton = touchObject.guiTexture;				
						}
					//================== Button movement and animation ===================
					if (Input.GetTouch (0).phase == TouchPhase.Stationary || Input.GetTouch (0).phase == TouchPhase.Moved) {
							curTouchPositionx = Input.GetTouch (0).position.x / SCREEN_WIDTH;
							curTouchPositiony = Input.GetTouch(0).position.y / SCREEN_HEIGHT;

							// snap the dragging button to the center if it is near.
							if(curButton!=null && (curTouchPositionx > 0.4f && curTouchPositionx < 0.6f) &&  (curTouchPositiony > 0.155f && curTouchPositiony < 0.27f)){
								curButton.transform.position = new Vector3 (.5f, .25f, 7f);
								
							}
							if(curButton.transform.position!=new Vector3 (.5f, .25f, 7f)){
								switch (curButton.name) {
								case "GUIMidButton0":
										curButton.transform.position = new Vector3 (curButton.transform.position.x, curTouchPositiony+.02f, 7f);
										
										break;
								case "GUIMidButton1":
										curButton.transform.position = new Vector3 (curTouchPositionx, (BUTTON_SLOPE * curTouchPositionx) + 0.133f, 7f);
										
										break;	
								case "GUIMidButton2":
										curButton.transform.position = new Vector3 (curTouchPositionx, (-BUTTON_SLOPE * curTouchPositionx) + 0.366f, 7f);
										
										break;
								case "GUIMidButton3":
										curButton.transform.position = new Vector3 (curButton.transform.position.x, curTouchPositiony+.02f, 7f);
										
										break;	
								case "GUIMidButton4":
										curButton.transform.position = new Vector3 (curTouchPositionx, (BUTTON_SLOPE * curTouchPositionx) + 0.133f, 7f);
										
										break;
								case "GUIMidButton5":
										curButton.transform.position = new Vector3 (curTouchPositionx, (-BUTTON_SLOPE * curTouchPositionx) + 0.366f, 7f);
										
										break;
								}			
							}
							
						}
							debugText.text = "Debug: finger pos: " + Input.GetTouch (0).position.x / Screen.width + ", " + Input.GetTouch (0).position.y / Screen.height 
							+ "\n" + curButton.name + "\nbutton pos: " + curButton.transform.position.x + ", " + curButton.transform.position.y;
			}

		//========================= Button area =======================
		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.GetKey(KeyCode.Escape))
			{
				Application.Quit();	
				return;
			}
		}
	}
}