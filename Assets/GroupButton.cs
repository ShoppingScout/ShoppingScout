using UnityEngine;
using System.Collections;

public class GroupButton : MonoBehaviour {
    //========================== VARIABLES ============================

    // The button containing categories
    private GameObject groupButton;
    // The category buttons
    private GameObject cat1, cat2, cat3, cat4;
    // Total number of button group currently active
    public static int Total_Number_Buttons = 0;
    public static int Total_Button_Group = 0;

    // Scale
    private Vector3 groupButtonScale = new Vector3(0.13f, 0.07f,1f);

    // Debug
    bool DEBUG = true;

    //Controller
    private static GameObject allButtons;


    //========================== VARIABLES ============================
    // Constructor
    public GroupButton(Vector3 position, int posID) {
        if (allButtons == null)
            allButtons = new GameObject();
        groupButton = new GameObject();
        groupButton.transform.parent = allButtons.transform;
        groupButton.AddComponent("GUITexture");
        // Set button texture
        groupButton.guiTexture.texture = (Texture2D)Resources.Load("button");
        groupButton.guiTexture.name = "groupButton" + posID;
        groupButton.guiTexture.transform.position = position;
        // Scale
        setGroupButtonScale(groupButtonScale);
    }
    // TOP -> RIGHT -> BOTTOM -> LEFT
    public void addCategory(int ID1, int ID2, int ID3, int ID4) {
        float spacingx = 0.09f;
        float spacingy = 0.05f;

        if (ID1 != -1) {
            cat1 = new GameObject();
            cat1.transform.parent = groupButton.transform;
            cat1.AddComponent("GUITexture");
            cat1.transform.localScale = new Vector3(0.4f,0.4f,1);
            cat1.guiTexture.texture = (Texture2D)Resources.Load("images/CategoryImages/"+ID1, typeof(Texture2D));
            cat1.guiTexture.name = ID1.ToString();
            cat1.transform.position = new Vector3(groupButton.guiTexture.transform.position.x,
                                                  groupButton.guiTexture.transform.position.y + spacingy, 10f);
            cat1.AddComponent("BoxCollider2D");
			cat1.GetComponent<BoxCollider2D>().size = new Vector2(.7f, .2f);
        }
        if (ID2 != -1) {
            cat2 = new GameObject();
            cat2.transform.parent = groupButton.transform;
            cat2.AddComponent("GUITexture");
            cat2.transform.localScale = new Vector3(0.4f,0.4f,1);
            cat2.guiTexture.texture = (Texture2D)Resources.Load("images/CategoryImages/"+ID2, typeof(Texture2D));
            cat2.guiTexture.name = ID2.ToString();
            cat2.transform.position = new Vector3(groupButton.guiTexture.transform.position.x + spacingx,
                                                  groupButton.guiTexture.transform.position.y, 10f);
			cat2.AddComponent("BoxCollider2D");
			cat2.GetComponent<BoxCollider2D>().size = new Vector2(.7f, .2f);
        }
        if (ID3 != -1) {
            cat3 = new GameObject();
            cat3.transform.parent = groupButton.transform;
            cat3.AddComponent("GUITexture");
            cat3.transform.localScale = new Vector3(0.4f,0.4f,1);
            cat3.guiTexture.texture = (Texture2D)Resources.Load("images/CategoryImages/"+ID3, typeof(Texture2D));
            cat3.guiTexture.name = ID3.ToString();
            cat3.transform.position = new Vector3(groupButton.guiTexture.transform.position.x,
                                                  groupButton.guiTexture.transform.position.y- spacingy, 10f);
			cat3.AddComponent("BoxCollider2D");
			cat3.GetComponent<BoxCollider2D>().size = new Vector2(.7f, .2f);
		}
        if (ID4 != -1) {
            cat4 = new GameObject();
            cat4.transform.parent = groupButton.transform;
            cat4.AddComponent("GUITexture");
            cat4.transform.localScale = new Vector3(0.4f,0.4f,1);
            cat4.guiTexture.texture = (Texture2D)Resources.Load("images/CategoryImages/"+ID4, typeof(Texture2D));
            cat4.guiTexture.name = ID4.ToString();
            cat4.transform.position = new Vector3(groupButton.guiTexture.transform.position.x - spacingx,
                                                  groupButton.guiTexture.transform.position.y, 10f);
			cat4.AddComponent("BoxCollider2D");
			cat4.GetComponent<BoxCollider2D>().size = new Vector2(.7f, .2f);
		}
    }

    public GameObject getCat(int cat) {
        if (cat ==1)
            return cat1;
        else if (cat==2)
            return cat2;
        else if (cat==3)
            return cat3;
        else if (cat==4)
            return cat4;
        else
            return null;
    }

    // move button by touch
    public void transformButton(string buttonName, float curTouchx, float curTouchy) {

        switch (buttonName) {
        case "ButtonGroup1":
            groupButton.transform.position = new Vector3 (groupButton.transform.position.x, curTouchy+.02f, 7f);
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

        case "ButtonGroup6":
            //curButton.transform.position = new Vector3 (curTouchPositionx, (-BUTTON_SLOPE * curTouchPositionx) + 0.366f, 7f);

            break;
        }

    }
    public static void deleteGroupButtons() {
        Transform temp;
        while (allButtons.transform.childCount > 0) {
            temp = allButtons.transform.GetChild(0);
            temp.parent = null;
            Destroy(temp.gameObject);
        }
    }
    // GroupButton movement
    public GameObject getGroupButton() {
        return groupButton;
    }

    public void setGroupButtonScale(Vector3 scale) {
        groupButton.guiTexture.transform.localScale = scale;
    }

    public void setCategoriesScale( float ratio) {
        float spacingx = 0.18f;
        float spacingy = 0.10f;
        float scale = 1.5f;
        float height = 10f;
        scale = 0.4f * (4 - 3 * ratio);
        spacingx = 0.09f * (3 - 2 * ratio);
        spacingy = 0.05f * (3 - 2 * ratio);

        if (cat1 != null) {
            cat1.transform.localScale = new Vector3(scale,scale,1);
            cat1.transform.position = new Vector3(groupButton.guiTexture.transform.position.x,
                                                  groupButton.guiTexture.transform.position.y + spacingy, height);

        }
        if (cat2 != null) {
            cat2.transform.localScale = new Vector3(scale,scale,1);
            cat2.transform.position = new Vector3(groupButton.guiTexture.transform.position.x + spacingx,
                                                  groupButton.guiTexture.transform.position.y, height);

        }
        if (cat3 != null) {
            cat3.transform.localScale = new Vector3(scale,scale,1);
            cat3.transform.position = new Vector3(groupButton.guiTexture.transform.position.x,
                                                  groupButton.guiTexture.transform.position.y- spacingy, height);

        }
        if (cat4 != null) {
            cat4.transform.localScale = new Vector3(scale,scale,1);
            cat4.transform.position = new Vector3(groupButton.guiTexture.transform.position.x - spacingx,
                                                  groupButton.guiTexture.transform.position.y, height);

        }
    }
    public void resetCategoriesScale() {
        float spacingx = 0.09f;
        float spacingy = 0.05f;
        float scale = 0.4f;
        if (cat1 != null) {
            cat1.transform.localScale = new Vector3(scale,scale,1);
            cat1.transform.position = new Vector3(groupButton.guiTexture.transform.position.x,
                                                  groupButton.guiTexture.transform.position.y + spacingy, 10f);

        }
        if (cat2 != null) {
            cat2.transform.localScale = new Vector3(scale,scale,1);
            cat2.transform.position = new Vector3(groupButton.guiTexture.transform.position.x + spacingx,
                                                  groupButton.guiTexture.transform.position.y, 10f);

        }
        if (cat3 != null) {
            cat3.transform.localScale = new Vector3(scale,scale,1);
            cat3.transform.position = new Vector3(groupButton.guiTexture.transform.position.x,
                                                  groupButton.guiTexture.transform.position.y- spacingy, 10f);

        }
        if (cat4 != null) {
            cat4.transform.localScale = new Vector3(scale,scale,1);
            cat4.transform.position = new Vector3(groupButton.guiTexture.transform.position.x - spacingx,
                                                  groupButton.guiTexture.transform.position.y, 10f);

        }
    }
    /*void OnTriggerExit2D(Collider2D other) {
        GUIText debugText = GameObject.Find ("DebugText").guiText;
        debugText.text = other.guiTexture.name;
    }
    void OnTriggerStay2D(Collider2D other) {
        GUIText debugText = GameObject.Find ("DebugText").guiText;
        debugText.text = "Entered!";
		}*/

}