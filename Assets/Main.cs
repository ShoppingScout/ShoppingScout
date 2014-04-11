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

    //Constants
    private const float BUTTON_SLOPE = (0.07f) / (0.3f);
    private int SCREEN_WIDTH = Screen.width;
    private int SCREEN_HEIGHT = Screen.height;

    // DEBUG
    private bool DEBUG = true;
    private int levelGroup = 1;
    public GameObject level;
    public GroupButton groupie;
    public GroupButton[] groupies;
	public GameObject centerMark;


    //============= VARIABLES END =============

    //=====================================================================//
    //================ START ==============================================//
    //=====================================================================//o
    void Start() {
        //for debug
        debugText = GameObject.Find ("DebugText").guiText;
        hitTest = Camera.main.GetComponent<GUILayer> ();
        level = new GameObject();
        level.AddComponent("GUITexture");
        level.guiTexture.name = "level";
        level.AddComponent("LevelScript");
        levelGroup = Main_Menu.load_number;
        level.GetComponent<LevelScript>().LoadLevelSettings(levelGroup);


        //========= BUTTON ============
    }

    //=====================================================================//
    //================ UPDATE =============================================//
    //=====================================================================//
    void Update () {
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
				centerMark = GameObject.Find("center");
                groupies = new GroupButton[6];
                groupies[0] = GameObject.Find("level").GetComponent<LevelScript>().Button1;

                groupies[1] = GameObject.Find("level").GetComponent<LevelScript>().Button2;

                groupies[2] = GameObject.Find("level").GetComponent<LevelScript>().Button3;

                groupies[3] = GameObject.Find("level").GetComponent<LevelScript>().Button4;

                groupies[4] = GameObject.Find("level").GetComponent<LevelScript>().Button5;

                groupies[5] = GameObject.Find("level").GetComponent<LevelScript>().Button6;
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
                }
                if (DEBUG) {
                    debugText.text = "Debug: finger pos: " + Input.GetTouch (0).position.x / Screen.width + ", " + Input.GetTouch (0).position.y / Screen.height
                                     + "\n" + touchObject.guiTexture.name + "\nbutton pos: " + curButton.transform.position.x + ", " + curButton.transform.position.y;
                }
            }

            //================== Button movement and animation ===================
            if (Input.GetTouch (0).phase == TouchPhase.Stationary || Input.GetTouch (0).phase == TouchPhase.Moved) {
                curTouchPositionx = Input.GetTouch (0).position.x / SCREEN_WIDTH;
                curTouchPositiony = Input.GetTouch(0).position.y / SCREEN_HEIGHT;

                // snap the dragging button to the center if it is near.
                if (curButton!=null && (curButton.transform.position.x > 0.4f && curButton.transform.position.x < 0.6f) &&  (curButton.transform.position.y > 0.22f && curButton.transform.position.y < 0.28f)) {
                    if (curButton.name.Equals("groupButton1") || curButton.name.Equals("groupButton2") ||
                            curButton.name.Equals("groupButton3") || curButton.name.Equals("groupButton4") ||
                            curButton.name.Equals("groupButton5") || curButton.name.Equals("groupButton6")) {
                        curButton.transform.position = new Vector3 (.5f, .25f, 7f);
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
						selectAnswerPhaseTwo();
                    }
                }
                else {// (curButton.transform.position!= new Vector3 (.5f, .25f, 7f)) {
                    switch (curButton.name) {
                    case "groupButton1":
                        if (Vector3.Distance(new Vector3 (curButton.transform.position.x, curTouchPositiony, 7f), new Vector3 (.5f, .25f, 7f))
                                <= Vector3.Distance((resetPos + new Vector3 (0,0,7f)), new Vector3 (.5f, .25f, 7f))) {
                            curButton.transform.position = new Vector3 (curButton.transform.position.x, curTouchPositiony-.02f, 7f);


                            groupies[0].setCategoriesScale(Vector3.Distance(curButton.transform.position, new Vector3 (.5f, .25f, 7f)) / Vector3.Distance((resetPos + new Vector3 (0,0,7f)), new Vector3 (.5f, .25f, 7f)));

                        }
                        break;
                    case "groupButton2":
                        if (Vector3.Distance(new Vector3 (curTouchPositionx, (BUTTON_SLOPE * curTouchPositionx), 7f), new Vector3 (.5f, .25f, 7f))
                                <= Vector3.Distance((resetPos + new Vector3 (0,0,7f)), new Vector3 (.5f, .25f, 7f))) {
                            curButton.transform.position = new Vector3 (curTouchPositionx, (BUTTON_SLOPE * curTouchPositionx) + 0.133f, 7f);

                            groupies[1].setCategoriesScale(Vector3.Distance(curButton.transform.position, new Vector3 (.5f, .25f, 7f)) / Vector3.Distance((resetPos + new Vector3 (0,0,7f)), new Vector3 (.5f, .25f, 7f)));
                        }
                        break;
                    case "groupButton3":
                        if (Vector3.Distance(new Vector3 (curTouchPositionx, (-BUTTON_SLOPE * curTouchPositionx) + 0.366f, 7f), new Vector3 (.5f, .25f, 7f))
                                <= Vector3.Distance((resetPos + new Vector3 (0,0,7f)), new Vector3 (.5f, .25f, 7f)))
                            curButton.transform.position = new Vector3 (curTouchPositionx, (-BUTTON_SLOPE * curTouchPositionx) + 0.366f, 7f);

                        groupies[2].setCategoriesScale(Vector3.Distance(new Vector3 (curTouchPositionx, (BUTTON_SLOPE * curTouchPositionx), 7f), new Vector3 (.5f, .25f, 7f)) / Vector3.Distance((resetPos + new Vector3 (0,0,7f)), new Vector3 (.5f, .25f, 7f)));

                        break;
                    case "groupButton4":
                        if (Vector3.Distance(new Vector3 (curButton.transform.position.x, curTouchPositiony, 7f), new Vector3 (.5f, .25f, 7f))
                                <= Vector3.Distance((resetPos + new Vector3 (0,0,7f)), new Vector3 (.5f, .25f, 7f)))
                            curButton.transform.position = new Vector3 (curButton.transform.position.x, curTouchPositiony+.02f, 7f);

                        groupies[3].setCategoriesScale(Vector3.Distance(new Vector3 (curButton.transform.position.x, curTouchPositiony, 7f), new Vector3 (.5f, .25f, 7f)) / Vector3.Distance((resetPos + new Vector3 (0,0,7f)), new Vector3 (.5f, .25f, 7f)));

                        break;
                    case "groupButton5":
                        if (Vector3.Distance(new Vector3 (curTouchPositionx, (BUTTON_SLOPE * curTouchPositionx), 7f), new Vector3 (.5f, .25f, 7f))
                                <= Vector3.Distance((resetPos + new Vector3 (0,0,7f)), new Vector3 (.5f, .25f, 7f)))
                            curButton.transform.position = new Vector3 (curTouchPositionx, (BUTTON_SLOPE * curTouchPositionx) + 0.133f, 7f);

                        groupies[4].setCategoriesScale(Vector3.Distance(new Vector3 (curTouchPositionx, (BUTTON_SLOPE * curTouchPositionx), 7f), new Vector3 (.5f, .25f, 7f)) / Vector3.Distance((resetPos + new Vector3 (0,0,7f)), new Vector3 (.5f, .25f, 7f)));

                        break;
                    case "groupButton6":
                        if (Vector3.Distance(new Vector3 (curTouchPositionx, (-1* BUTTON_SLOPE * curTouchPositionx) + 0.366f, 7f), new Vector3 (.5f, .25f, 7f))
                                <= Vector3.Distance((resetPos + new Vector3 (0,0,7f)), new Vector3 (.5f, .25f, 7f)))
                            curButton.transform.position = new Vector3 (curTouchPositionx, (-1 * BUTTON_SLOPE * curTouchPositionx) + 0.366f, 7f);

                        groupies[5].setCategoriesScale(Vector3.Distance(new Vector3 (curTouchPositionx, (-1* BUTTON_SLOPE * curTouchPositionx) + 0.366f, 7f), new Vector3 (.5f, .25f, 7f)) / Vector3.Distance((resetPos + new Vector3 (0,0,7f)), new Vector3 (.5f, .25f, 7f)));

                        break;
                    }
                    if (DEBUG) {
                        debugText.text = centerMark.transform.position.z + "        "  +groupies[0].getCat(1).transform.position.z;
						
						
						/*"Debug: finger pos: " + Input.GetTouch (0).position.x / Screen.width + ", " + Input.GetTouch (0).position.y / Screen.height
                                         + "\n" + curButton.name + "\nbutton pos: " + curButton.transform.position.x + ", " + curButton.transform.position.y + '\n' + "ResetPosDist"
                                         + (Vector3.Distance((resetPos + new Vector3 (0,0,7f)), new Vector3 (.5f, .25f, 7f))) + '\n' + "TouchPos:" + Vector3.Distance(new Vector3 (curButton.transform.position.x, curTouchPositiony, 7f),
                                                 new Vector3 (.5f, .25f, 7f)) + "     " + resetPos;*/
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
    public void selectAnswerPhaseTwo() {
		centerMark.transform.position = new Vector3 (curTouchPositionx, curTouchPositiony, 11f);

    }

}