using UnityEngine;
using System.Collections;
using System;

public class TouchButton : MonoBehaviour
{

	//declare GUITexture buttons as GameObject, use GameObject.guiTexture to reference the GUITexture.
	//button 1
	private GameObject topButton0, bottomButton0, leftButton0, rightButton0, middleButton0;
	//button 2
	private GameObject topButton1, bottomButton1, leftButton1, rightButton1, middleButton1;
	//button 3
	private GameObject topButton2, bottomButton2, leftButton2, rightButton2, middleButton2;
	//button 4
	private GameObject topButton3, bottomButton3, leftButton3, rightButton3, middleButton3;
	//button 5
	private GameObject topButton4, bottomButton4, leftButton4, rightButton4, middleButton4;
	//button 6
	private GameObject topButton5, bottomButton5, leftButton5, rightButton5, middleButton5;

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

	//Constants
	private const float BUTTON_SLOPE = (0.07f) / (0.3f);
	private int SCREEN_WIDTH = Screen.width;
	private int SCREEN_HEIGHT = Screen.height;

	//scoring
	public Scoring score;
	void Start ()
	{
			//used for returning the GameObject that is being touched.
			hitTest = Camera.main.GetComponent<GUILayer> ();

			//scoring
			score = gameObject.GetComponent<Scoring>();
			
			//Find all GameObjects on current scene and set them to a variable
			FindGameObjects ();			

			midButtonColor = new Color(.33725f,.56862f,.18039f,1f);
			
	}

	void Update ()
	{
			//is there a touch on screen?
			if (Input.touches.Length <= 0) {
					//if no touches	
					activeButton("GUIMidButton0", false);
					activeButton("GUIMidButton1", false);
					activeButton("GUIMidButton2", false);
					activeButton("GUIMidButton3", false);
					activeButton("GUIMidButton4", false);
					activeButton("GUIMidButton5", false);
					ChangeButtonOpacity(1f);
					curButton = null;
			} else { //if there is touch	
					//execute this code for current touch[0] on screen
					
					if (Input.GetTouch (0).phase == TouchPhase.Began) {
							touchObject = hitTest.HitTest (Input.GetTouch (0).position);
	
							//get current touch position in decimal. [0-1]
							curTouchPositionx = Input.GetTouch (0).position.x / SCREEN_WIDTH;
							curTouchPositiony = Input.GetTouch(0).position.y / SCREEN_HEIGHT;
							if (touchObject == null) {
								debugText.text = "Debug: touchObject is null";
							}
							//check for touch around the buttons to increase the touch radius for smoother dragging.
							if((curTouchPositionx > 0.4f && curTouchPositionx < 0.6f) &&  (curTouchPositiony > 0.3f && curTouchPositiony < 0.4f)){
								curButton = middleButton0.guiTexture;
							}
							else if((curTouchPositionx > 0.72f && curTouchPositionx < 0.9f) &&  (curTouchPositiony > 0.24f && curTouchPositiony < 0.32f)){
								curButton = middleButton1.guiTexture;
							} 
							else if((curTouchPositionx > 0.72f && curTouchPositionx < 0.9f) &&  (curTouchPositiony > 0.09f && curTouchPositiony < 0.17f)){
								curButton = middleButton2.guiTexture;
							}
							else if((curTouchPositionx > 0.4f && curTouchPositionx < 0.6f) &&  (curTouchPositiony > 0.01f && curTouchPositiony < 0.1f)){
								curButton = middleButton3.guiTexture;
							}
							else if((curTouchPositionx > 0.15f && curTouchPositionx < 0.27f) &&  (curTouchPositiony > 0.09f && curTouchPositiony < 0.17f)){
								curButton = middleButton4.guiTexture;
							}
							else if((curTouchPositionx > 0.15f && curTouchPositionx < 0.27f) &&  (curTouchPositiony > 0.24f && curTouchPositiony < 0.32f)){
								curButton = middleButton5.guiTexture;
							}
			
							//debugText.text = "Debug: " + curButton.name;
					}

					//Restrict the dragging on a straight line.
					//BUTTON_SLOPE =  0.07/0.3, this is a constant that is used to calculate the movement of the non straight buttons
					//Button1 and button4 y=(BUTTON_SLOPE)*x + 0.133f
					//button3 and button5 y=BUTTON_SLOPE*x + 0.366
					if (Input.GetTouch (0).phase == TouchPhase.Stationary || Input.GetTouch (0).phase == TouchPhase.Moved) {
							curTouchPositionx = Input.GetTouch (0).position.x / SCREEN_WIDTH;
							curTouchPositiony = Input.GetTouch(0).position.y / SCREEN_HEIGHT;

							//snap the dragging button to the center if it is near.
							if(curButton!=null && (curTouchPositionx > 0.4f && curTouchPositionx < 0.6f) &&  (curTouchPositiony > 0.155f && curTouchPositiony < 0.27f)){
								curButton.transform.position = new Vector3 (.5f, .25f, 7f);
								activeButton(curButton.guiTexture.name, true);
							}
							if(curButton.transform.position!=new Vector3 (.5f, .25f, 7f)){
								switch (curButton.name) {
								case "GUIMidButton0":
										curButton.transform.position = new Vector3 (curButton.transform.position.x, curTouchPositiony+.02f, 7f);
										opacity = (curTouchPositiony-0.25f)/0.15f;
										ChangeButtonOpacity(opacity);
										break;
								case "GUIMidButton1":
										curButton.transform.position = new Vector3 (curTouchPositionx, (BUTTON_SLOPE * curTouchPositionx) + 0.133f, 7f);
										opacity = (float)Math.Sqrt((Math.Pow(curTouchPositionx-0.5f,2)+Math.Pow(curTouchPositiony-0.25f,2)))/0.40f;
										ChangeButtonOpacity(opacity);
										break;	
								case "GUIMidButton2":
										curButton.transform.position = new Vector3 (curTouchPositionx, (-BUTTON_SLOPE * curTouchPositionx) + 0.366f, 7f);
										opacity = (float)Math.Sqrt((Math.Pow(curTouchPositionx-0.5f,2)+Math.Pow(curTouchPositiony-0.25f,2)))/0.40f;
										ChangeButtonOpacity(opacity);
										break;
								case "GUIMidButton3":
										curButton.transform.position = new Vector3 (curButton.transform.position.x, curTouchPositiony+.02f, 7f);
										opacity = (0.18f - curTouchPositiony)/0.15f;
										ChangeButtonOpacity(opacity);
										break;	
								case "GUIMidButton4":
										curButton.transform.position = new Vector3 (curTouchPositionx, (BUTTON_SLOPE * curTouchPositionx) + 0.133f, 7f);
										opacity = (float)Math.Sqrt((Math.Pow(curTouchPositionx-0.5f,2)+Math.Pow(curTouchPositiony-0.25f,2)))/0.40f;
										ChangeButtonOpacity(opacity);
										break;
								case "GUIMidButton5":
										curButton.transform.position = new Vector3 (curTouchPositionx, (-BUTTON_SLOPE * curTouchPositionx) + 0.366f, 7f);
										opacity = (float)Math.Sqrt((Math.Pow(curTouchPositionx-0.5f,2)+Math.Pow(curTouchPositiony-0.25f,2)))/0.40f;
										ChangeButtonOpacity(opacity);
										break;
								}			
							}
							
							debugText.text = "Debug: opacity:" + opacity + "\nfinger pos: " + Input.GetTouch (0).position.x / Screen.width + ", " + Input.GetTouch (0).position.y / Screen.height 
							+ "\n" + curButton.name + "\nbutton pos: " + curButton.transform.position.x + ", " + curButton.transform.position.y;
					}

					if (Input.GetTouch (0).phase == TouchPhase.Ended) {				
							//Set position of middleButton. We do this to scale/position across all resolutions

							touchObject = hitTest.HitTest (Input.GetTouch (0).position);
							
							//debugText.text = "Debug: " + touchObject.guiTexture.name;
							
							
							middleButton0.guiTexture.transform.position = new Vector3 (0.5f, 0.4f, 0f);
							middleButton1.guiTexture.transform.position = new Vector3 (0.8f, 0.32f, 0f);
							middleButton2.guiTexture.transform.position = new Vector3 (0.8f, 0.18f, 0f);
							middleButton3.guiTexture.transform.position = new Vector3 (0.5f, 0.1f, 0f);
							middleButton4.guiTexture.transform.position = new Vector3 (0.2f, 0.18f, 0f);
							middleButton5.guiTexture.transform.position = new Vector3 (0.2f, 0.32f, 0f);
							
							
							

							score.CheckAnswer(touchObject.guiTexture.name);
												
					} 
		
			}
	}

	void ChangeButtonOpacity(float opacity){
		midButtonColor.a = opacity;
		middleButton0.guiTexture.color = midButtonColor;
		middleButton1.guiTexture.color = midButtonColor;
		middleButton2.guiTexture.color = midButtonColor;
		middleButton3.guiTexture.color = midButtonColor;
		middleButton4.guiTexture.color = midButtonColor;
		middleButton5.guiTexture.color = midButtonColor;
	}
	/// <summary>
	/// Changes the middle button texture. We use this along with activeButton
	/// </summary>
	/// <param name='active'>
	/// A boolean, true means button is pressed, false means button is not pressed
	/// </param>
	/// <param name='name'>
	/// The name of the middle button
	/// </param>
	void ChangeMidButtonTexture (string name, bool active)
	{
			if (active) {
					GameObject.Find (name).guiTexture.texture = buttonPress;
			} else {
					GameObject.Find (name).guiTexture.texture = buttonNoPress;
			}
	}
	/// <summary>
	/// Activate the surrounding buttons depending on which middle button is touched.
	/// </summary>
	/// <param name='active'>
	/// A boolean, true means button is pressed, false means button is not pressed
	/// </param>
	/// <param name='name'>
	/// The name of the middle button
	/// </param>
	void activeButton (string name, bool active)
	{
			switch (name) {
			case "GUIMidButton0":	
		//button set 1
					topButton0.SetActive (active);
					bottomButton0.SetActive (active);
					rightButton0.SetActive (active);
					leftButton0.SetActive (active);
				
					break;
			case "GUIMidButton1":	
		//button set 2
					topButton1.SetActive (active);
					bottomButton1.SetActive (active);
					rightButton1.SetActive (active);
					leftButton1.SetActive (active);
					
					break;
			case "GUIMidButton2":	
		//button set 3
					topButton2.SetActive (active);
					bottomButton2.SetActive (active);
					rightButton2.SetActive (active);
					leftButton2.SetActive (active);
					
					break;
			case "GUIMidButton3":	
		//button set 4
					topButton3.SetActive (active);
					bottomButton3.SetActive (active);
					rightButton3.SetActive (active);
					leftButton3.SetActive (active);
					
					break;
			case "GUIMidButton4":	
		//button set 5
					topButton4.SetActive (active);
					bottomButton4.SetActive (active);
					rightButton4.SetActive (active);
					leftButton4.SetActive (active);
					
					break;
			case "GUIMidButton5":	
		//button set 6
					topButton5.SetActive (active);
					bottomButton5.SetActive (active);
					rightButton5.SetActive (active);
					leftButton5.SetActive (active);
				
					break;
			default:
					break;
			}
	}	
	/// <summary>
	/// Reposition the game buttons surrounding the middle .
	/// </summary>
	/// <param name='xButtonSpacing'>
	/// Horizontal spacing of buttons on left and right of middle button. By percentage [0-1]
	/// </param>
	/// <param name='yButtonSpacing'>
	/// Vertical spacing of buttons on left and right of middle button. By percentage [0-1]
	/// </param>
	void RepositionGameButtons (float xbuttonSpacing, float ybuttonSpacing)
	{
			if (xbuttonSpacing > 1 || xbuttonSpacing < 0 || ybuttonSpacing > 1 || xbuttonSpacing < 0) {
					throw new System.ArgumentException ("xbuttonSpacing or ybuttonSpacing must be between 0-1");
			}
			//get position of middle buttons. This will be used to calculate relative position of surrounding buttons
			//middle button 1
			float ypos1 = middleButton0.transform.position.y;
			float xpos1 = middleButton0.transform.position.x;
			//middle button 2
			float ypos2 = middleButton1.transform.position.y;
			float xpos2 = middleButton1.transform.position.x;
			//middle button 3
			float ypos3 = middleButton2.transform.position.y;
			float xpos3 = middleButton2.transform.position.x;
			//middle button 4
			float ypos4 = middleButton3.transform.position.y;
			float xpos4 = middleButton3.transform.position.x;
			//middle button 5
			float ypos5 = middleButton4.transform.position.y;
			float xpos5 = middleButton4.transform.position.x;
			//middle button 6
			float ypos6 = middleButton5.transform.position.y;
			float xpos6 = middleButton5.transform.position.x;
	
			//transform buttons surrounding middle button
			//middle button 1		
			topButton0.guiTexture.transform.position = new Vector3 (xpos1, ypos1 + ybuttonSpacing, 1);
			bottomButton0.guiTexture.transform.position = new Vector3 (xpos1, ypos1 - ybuttonSpacing, 1);
			leftButton0.guiTexture.transform.position = new Vector3 (xpos1 - xbuttonSpacing, ypos1, 1);
			rightButton0.guiTexture.transform.position = new Vector3 (xpos1 + xbuttonSpacing, ypos1, 1);
			//middle button 2
			topButton1.guiTexture.transform.position = new Vector3 (xpos2, ypos2 + ybuttonSpacing, 1);
			bottomButton1.guiTexture.transform.position = new Vector3 (xpos2, ypos2 - ybuttonSpacing, 1);
			leftButton1.guiTexture.transform.position = new Vector3 (xpos2 - xbuttonSpacing, ypos2, 1);
			rightButton1.guiTexture.transform.position = new Vector3 (xpos2 + xbuttonSpacing, ypos2, 1);
			//middle button 3
			topButton2.guiTexture.transform.position = new Vector3 (xpos3, ypos3 + ybuttonSpacing, 1);
			bottomButton2.guiTexture.transform.position = new Vector3 (xpos3, ypos3 - ybuttonSpacing, 1);
			leftButton2.guiTexture.transform.position = new Vector3 (xpos3 - xbuttonSpacing, ypos3, 1);
			rightButton2.guiTexture.transform.position = new Vector3 (xpos3 + xbuttonSpacing, ypos3, 1);
			//middle button 4
			topButton3.guiTexture.transform.position = new Vector3 (xpos4, ypos4 + ybuttonSpacing, 1);
			bottomButton3.guiTexture.transform.position = new Vector3 (xpos4, ypos4 - ybuttonSpacing, 1);
			leftButton3.guiTexture.transform.position = new Vector3 (xpos4 - xbuttonSpacing, ypos4, 1);
			rightButton3.guiTexture.transform.position = new Vector3 (xpos4 + xbuttonSpacing, ypos4, 1);
			//middle button 5
			topButton4.guiTexture.transform.position = new Vector3 (xpos5, ypos5 + ybuttonSpacing, 1);
			bottomButton4.guiTexture.transform.position = new Vector3 (xpos5, ypos5 - ybuttonSpacing, 1);
			leftButton4.guiTexture.transform.position = new Vector3 (xpos5 - xbuttonSpacing, ypos5, 1);
			rightButton4.guiTexture.transform.position = new Vector3 (xpos5 + xbuttonSpacing, ypos5, 1);
			//middle button 6
			topButton5.guiTexture.transform.position = new Vector3 (xpos6, ypos6 + ybuttonSpacing, 1);
			bottomButton5.guiTexture.transform.position = new Vector3 (xpos6, ypos6 - ybuttonSpacing, 1);
			leftButton5.guiTexture.transform.position = new Vector3 (xpos6 - xbuttonSpacing, ypos6, 1);
			rightButton5.guiTexture.transform.position = new Vector3 (xpos6 + xbuttonSpacing, ypos6, 1);
	
	}
	/// <summary>
	/// Finds the game objects and assigns them to variables so we can reference them.
	/// </summary>
	void FindGameObjects ()
	{
			//debug text
			debugText = GameObject.Find ("DebugText").guiText;
	
			//middle button animation.
			buttonPress = (Texture2D)Resources.Load ("button");
			buttonNoPress = (Texture2D)Resources.Load ("button");
	
			//Find game objects to to set position for resolution scaling.
			//Button0
			topButton0 = GameObject.Find ("GUITopButton0");
			bottomButton0 = GameObject.Find ("GUIBottomButton0");
			leftButton0 = GameObject.Find ("GUILeftButton0");
			rightButton0 = GameObject.Find ("GUIRightButton0");
			middleButton0 = GameObject.Find ("GUIMidButton0");
			//Button1
			topButton1 = GameObject.Find ("GUITopButton1");
			bottomButton1 = GameObject.Find ("GUIBottomButton1");
			leftButton1 = GameObject.Find ("GUILeftButton1");
			rightButton1 = GameObject.Find ("GUIRightButton1");
			middleButton1 = GameObject.Find ("GUIMidButton1");
			//Button2
			topButton2 = GameObject.Find ("GUITopButton2");
			bottomButton2 = GameObject.Find ("GUIBottomButton2");
			leftButton2 = GameObject.Find ("GUILeftButton2");
			rightButton2 = GameObject.Find ("GUIRightButton2");
			middleButton2 = GameObject.Find ("GUIMidButton2");
			//Button3
			topButton3 = GameObject.Find ("GUITopButton3");
			bottomButton3 = GameObject.Find ("GUIBottomButton3");
			leftButton3 = GameObject.Find ("GUILeftButton3");
			rightButton3 = GameObject.Find ("GUIRightButton3");
			middleButton3 = GameObject.Find ("GUIMidButton3");
			//Button4
			topButton4 = GameObject.Find ("GUITopButton4");
			bottomButton4 = GameObject.Find ("GUIBottomButton4");
			leftButton4 = GameObject.Find ("GUILeftButton4");
			rightButton4 = GameObject.Find ("GUIRightButton4");
			middleButton4 = GameObject.Find ("GUIMidButton4");
			//Button5
			topButton5 = GameObject.Find ("GUITopButton5");
			bottomButton5 = GameObject.Find ("GUIBottomButton5");
			leftButton5 = GameObject.Find ("GUILeftButton5");
			rightButton5 = GameObject.Find ("GUIRightButton5");
			middleButton5 = GameObject.Find ("GUIMidButton5");		
	}
}
