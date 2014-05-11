using UnityEngine;
using System.Collections;

using System;


public class Main : MonoBehaviour {
    //============== VARIABLES =================
    public Texture btnTexture;
    public GUIStyle myGUIStyle;



    //used to detect which object is being touched
    private GUILayer hitTest;
    private GUIElement touchObject;
    private GUITexture curButton;

    //used for outputing
    private GUIText debugText;

    private float curTouchPositionx;
    private float curTouchPositiony;
    private Vector3 resetPos;
    private Vector3 centerResetPos;

    //Constants
    private const float BUTTON_SLOPE = (0.07f) / (0.3f);
    private int SCREEN_WIDTH = Screen.width;
    private int SCREEN_HEIGHT = Screen.height;

    // DEBUG
    private bool DEBUG = true;
    private int levelGroup = 1;
    public GameObject level;
    public static GroupButton groupie;
    public static GroupButton[] groupies;

    public GameObject centerMark;
    public static bool middle; //Touch button in the middle?
    public static int itemUpdate;
    public static int itemAnswer;


    //============= VARIABLES END =============

    //=====================================================================//
    //================ START ==============================================//
    //=====================================================================//o
    void Start() {
        //for debug
        debugText = GameObject.Find ("DebugText").guiText;
		centerMark = GameObject.Find("center");
		//centerMark.SetActive(false);
		
        hitTest = Camera.main.GetComponent<GUILayer> ();
       
        levelGroup = Main_Menu.load_number;
        LevelScript.LoadLevelSettings(levelGroup);
        middle = false;
        itemUpdate = -1;
        itemAnswer = -1;


        //========= BUTTON ============
    }

    //=====================================================================//
    //================ UPDATE =============================================//
    //=====================================================================//
    void Update () {
        //========================= Button area =======================
        //is there a touch on screen?
		if (!GameObject.Find("Game Object Clock").GetComponent<Clock_Script>().isPaused)
			GameObject.Find("Game Object Clock").GetComponent<Clock_Script>().Countdown();
        if (Input.touches.Length <= 0) {
            GameObject checker = GameObject.Find ("PlayerBalance");
            //if no touches
            if (itemUpdate != -1) {
                checker.GetComponent <Scoring_Money> ().Check_Answer(itemUpdate.ToString());
                LevelScript.currentItem = GameObject.Find("Scripts").GetComponent<Product_DB>().next_Item();
				itemUpdate = -1;
				//StartCoroutine(GameObject.Find("center").GetComponent<CollisionAnswer>().flashAnswer(remainder == 0));
                
                
				
            }

            curButton = null;

        } else { //if there is touch
            //execute this code for current touch[0] on screen

            if (Input.GetTouch (0).phase == TouchPhase.Began) {
                touchObject = hitTest.HitTest (Input.GetTouch (0).position);
                //get current touch position in decimal. [0-1]
                curTouchPositionx = Input.GetTouch (0).position.x / SCREEN_WIDTH;
                curTouchPositiony = Input.GetTouch(0).position.y / (SCREEN_HEIGHT);
                //get current touch button
                curButton = touchObject.guiTexture;
                if (curButton.transform.name.Length < 12)
                    if (curButton.transform.parent != null)
                        if (curButton.transform.parent.name.Equals("groupButton1") || curButton.transform.parent.name.Equals("groupButton2") ||
                                curButton.transform.parent.name.Equals("groupButton3") || curButton.transform.parent.name.Equals("groupButton4") ||
                                curButton.transform.parent.name.Equals("groupButton5") || curButton.transform.parent.name.Equals("groupButton6"))
                        {
                            curButton = curButton.transform.parent.guiTexture;
                        }
                resetPos = curButton.transform.position;
                
                centerResetPos = centerMark.transform.position;
                groupies = new GroupButton[6];
                groupies[0] = LevelScript.Button1;

                groupies[1] = LevelScript.Button2;

                groupies[2] = LevelScript.Button3;

                groupies[3] = LevelScript.Button4;

                groupies[4] = LevelScript.Button5;

                groupies[5] = LevelScript.Button6;
            }
            //================== End phase ===================
            if (Input.GetTouch (0).phase == TouchPhase.Ended) {
                touchObject = hitTest.HitTest (Input.GetTouch (0).position);

                centerMark.transform.position = new Vector3 (.5f, .25f, 0f);
                curButton.transform.position = resetPos;
                if (curButton.name.Equals("groupButton1") || curButton.name.Equals("groupButton2") ||
                        curButton.name.Equals("groupButton3") || curButton.name.Equals("groupButton4") ||
                        curButton.name.Equals("groupButton5") || curButton.name.Equals("groupButton6")) {
                    switch ((int)curButton.name[11] - '0') {
                    case 1:
                        groupie = groupies[0];
                        break;

                    case 2:
                        groupie = groupies[1];
                        break;

                    case 3:
                        groupie = groupies[2];
                        break;

                    case 4:
                        groupie = groupies[3];
                        break;

                    case 5:
                        groupie = groupies[4];
                        break;

                    case 6:
                        groupie = groupies[5];
                        break;

                    default:
                        break;
                    }
                    groupie.resetCategoriesScale();
					groupie.removeCatTexts();
                    for (int i = 0; i < 6; i++) {
                        try {
                            groupies[i].getGroupButton().gameObject.SetActive(true);
                        }
                        catch (Exception e) {};

                    }
                    if (itemAnswer != -1) {
                        itemUpdate = itemAnswer;
                        itemAnswer = -1;
                    }
                }
                middle = false;
                //if (DEBUG) {
                //   debugText.text = "Debug: finger pos: " + Input.GetTouch (0).position.x / Screen.width + ", " + Input.GetTouch (0).position.y / Screen.height
                //                    + "\n" + touchObject.guiTexture.name + "\nbutton pos: " + curButton.transform.position.x + ", " + curButton.transform.position.y;
                // }
            }

            //================== Button movement and animation ===================
            if (Input.GetTouch (0).phase == TouchPhase.Stationary || Input.GetTouch (0).phase == TouchPhase.Moved) {
                curTouchPositionx = Input.GetTouch (0).position.x / SCREEN_WIDTH;
                curTouchPositiony = Input.GetTouch(0).position.y / SCREEN_HEIGHT;
                if (!middle) {
                    // snap the dragging button to the center if it is near.
                    if (curButton!=null && (curButton.transform.position.x > 0.4f && curButton.transform.position.x < 0.6f) &&  (curButton.transform.position.y > 0.22f && curButton.transform.position.y < 0.28f )) {
                        if (curButton.name.Equals("groupButton1") || curButton.name.Equals("groupButton2") ||
                                curButton.name.Equals("groupButton3") || curButton.name.Equals("groupButton4") ||
                                curButton.name.Equals("groupButton5") || curButton.name.Equals("groupButton6")) {
                            curButton.transform.position = new Vector3 (.5f, .25f, 0f);
                            switch ((int)curButton.name[11] - '0') {
                            case 1:
                                groupie = groupies[0];
                                break;

                            case 2:
                                groupie = groupies[1];
                                break;

                            case 3:
                                groupie = groupies[2];
                                break;

                            case 4:
                                groupie = groupies[3];
                                break;

                            case 5:
                                groupie = groupies[4];
                                break;

                            case 6:
                                groupie = groupies[5];
                                break;

                            default:
                                break;
                            }
                            groupie.setCategoriesScale(0);
							setMiddle();
                            middle = true;
							
                            groupie.addCatTexts();
                           // groupie.getCat(1).guiText.anchor = TextAnchor.LowerCenter;
                            debugText.text = "working!";

                        }
                    }
                    else {// (curButton.transform.position!= new Vector3 (.5f, .25f, 0f)) {
                        switch (curButton.name) {
                        case "groupButton1":
                            if (Vector3.Distance(new Vector3 (curButton.transform.position.x, curTouchPositiony, 0f), new Vector3 (.5f, .25f, 0f))
                                    <= Vector3.Distance((resetPos + new Vector3 (0,0,0f)), new Vector3 (.5f, .25f, 0f))) {
                                curButton.transform.position = new Vector3 (curButton.transform.position.x, curTouchPositiony-.02f, 0f);


                                groupies[0].setCategoriesScale(Vector3.Distance(curButton.transform.position, new Vector3 (.5f, .25f, 0f)) / Vector3.Distance((resetPos + new Vector3 (0,0,0f)), new Vector3 (.5f, .25f, 0f)));

                            }
                            break;
                        case "groupButton2":
                            if (Vector3.Distance(new Vector3 (curTouchPositionx, (BUTTON_SLOPE * curTouchPositionx), 0f), new Vector3 (.5f, .25f, 0f))
                                    <= Vector3.Distance((resetPos + new Vector3 (0,0,0f)), new Vector3 (.5f, .25f, 0f))) {
                                curButton.transform.position = new Vector3 (curTouchPositionx, (BUTTON_SLOPE * curTouchPositionx) + 0.133f, 0f);

                                groupies[1].setCategoriesScale(Vector3.Distance(curButton.transform.position, new Vector3 (.5f, .25f, 0f)) / Vector3.Distance((resetPos + new Vector3 (0,0,0f)), new Vector3 (.5f, .25f, 0f)));
                            }
                            break;
                        case "groupButton3":
                            if (Vector3.Distance(new Vector3 (curTouchPositionx, (-BUTTON_SLOPE * curTouchPositionx) + 0.366f, 0f), new Vector3 (.5f, .25f, 0f))
                                    <= Vector3.Distance((resetPos + new Vector3 (0,0,0f)), new Vector3 (.5f, .25f, 0f)))
                                curButton.transform.position = new Vector3 (curTouchPositionx, (-BUTTON_SLOPE * curTouchPositionx) + 0.366f, 0f);

                            groupies[2].setCategoriesScale(Vector3.Distance(new Vector3 (curTouchPositionx, (BUTTON_SLOPE * curTouchPositionx), 0f), new Vector3 (.5f, .25f, 0f)) / Vector3.Distance((resetPos + new Vector3 (0,0,0f)), new Vector3 (.5f, .25f, 0f)));

                            break;
                        case "groupButton4":
                            if (Vector3.Distance(new Vector3 (curButton.transform.position.x, curTouchPositiony, 0f), new Vector3 (.5f, .25f, 0f))
                                    <= Vector3.Distance((resetPos + new Vector3 (0,0,0f)), new Vector3 (.5f, .25f, 0f)))
                                curButton.transform.position = new Vector3 (curButton.transform.position.x, curTouchPositiony+.02f, 0f);

                            groupies[3].setCategoriesScale(Vector3.Distance(new Vector3 (curButton.transform.position.x, curTouchPositiony, 0f), new Vector3 (.5f, .25f, 0f)) / Vector3.Distance((resetPos + new Vector3 (0,0,0f)), new Vector3 (.5f, .25f, 0f)));

                            break;
                        case "groupButton5":
                            if (Vector3.Distance(new Vector3 (curTouchPositionx, (BUTTON_SLOPE * curTouchPositionx), 0f), new Vector3 (.5f, .25f, 0f))
                                    <= Vector3.Distance((resetPos + new Vector3 (0,0,0f)), new Vector3 (.5f, .25f, 0f)))
                                curButton.transform.position = new Vector3 (curTouchPositionx, (BUTTON_SLOPE * curTouchPositionx) + 0.133f, 0f);

                            groupies[4].setCategoriesScale(Vector3.Distance(new Vector3 (curTouchPositionx, (BUTTON_SLOPE * curTouchPositionx), 0f), new Vector3 (.5f, .25f, 0f)) / Vector3.Distance((resetPos + new Vector3 (0,0,0f)), new Vector3 (.5f, .25f, 0f)));

                            break;
                        case "groupButton6":
                            if (Vector3.Distance(new Vector3 (curTouchPositionx, (-1* BUTTON_SLOPE * curTouchPositionx) + 0.366f, 0f), new Vector3 (.5f, .25f, 0f))
                                    <= Vector3.Distance((resetPos + new Vector3 (0,0,0f)), new Vector3 (.5f, .25f, 0f)))
                                curButton.transform.position = new Vector3 (curTouchPositionx, (-1 * BUTTON_SLOPE * curTouchPositionx) + 0.366f, 0f);

                            groupies[5].setCategoriesScale(Vector3.Distance(new Vector3 (curTouchPositionx, (-1* BUTTON_SLOPE * curTouchPositionx) + 0.366f, 0f), new Vector3 (.5f, .25f, 0f)) / Vector3.Distance((resetPos + new Vector3 (0,0,0f)), new Vector3 (.5f, .25f, 0f)));

                            break;
                        }
                    }
                }
                else {
                    selectAnswerPhaseTwo();
                }
                //if (DEBUG) {
                //  debugText.text = centerMark.transform.position.z + "        "  +groupies[0].getCat(1).transform.position.z;





                /*"Debug: finger pos: " + Input.GetTouch (0).position.x / Screen.width + ", " + Input.GetTouch (0).position.y / Screen.height
                                 + "\n" + curButton.name + "\nbutton pos: " + curButton.transform.position.x + ", " + curButton.transform.position.y + '\n' + "ResetPosDist"
                                 + (Vector3.Distance((resetPos + new Vector3 (0,0,0f)), new Vector3 (.5f, .25f, 0f))) + '\n' + "TouchPos:" + Vector3.Distance(new Vector3 (curButton.transform.position.x, curTouchPositiony, 0f),
                                         new Vector3 (.5f, .25f, 0f)) + "     " + resetPos;*/
                // }
            }
        }






        //========================= Button area =======================
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
				CollisionAnswer.jo.Call("vibrate2", 75);
				LevelScript.Deinitialize();
                Application.LoadLevel("Menu");
                return;
            }
        }
    }
	public void setMiddle(){
		for (int i = 0; i < 6; i++) {
            if (GameObject.Find("groupButton"+(i+1)))
                if (!groupies[i].getGroupButton().name.Equals(curButton.name))
                    groupies[i].getGroupButton().gameObject.SetActive(false);
		}
        
	}
    public void selectAnswerPhaseTwo() {
        debugText.text = "Level: " + PlayerPrefs.GetInt("level", 1);
        centerMark.transform.position = new Vector3 (curTouchPositionx, curTouchPositiony, 12f);
        //if (DEBUG) {
        //   debugText.text = centerMark.transform.position.z + "        "  +groupies[3].getCat(1).transform.position.z+ "        "  +groupies[0].getCat(1).transform.position.z + '\n'
        //                    + groupies[3].getGroupButton().transform.position.z+ "        "  + groupies[0].getCat(1).GetComponent<CircleCollider2D>().center + '\n' + groupies[0].getCat(1).GetComponent<CircleCollider2D>().radius;
        //}

    }

}