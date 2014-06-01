using UnityEngine;
using System.Collections;
using System;

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

            cat1.transform.localScale = new Vector3(0.7f,0.7f,1);
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
            cat2.transform.localScale = new Vector3(0.7f,0.7f,1);
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
            cat3.transform.localScale = new Vector3(0.7f,0.7f,1);
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
            cat4.transform.localScale = new Vector3(0.7f,0.7f,1);
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
        spacingx = 0.08f * (3 - 2 * ratio);
        spacingy = 0.04f * (3 - 2 * ratio);

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
        float scale = 0.7f;
        if (cat1 != null) {
            cat1.transform.localScale = new Vector3(scale,scale,1);
            cat1.transform.position = new Vector3(groupButton.guiTexture.transform.position.x,
                                                  groupButton.guiTexture.transform.position.y + spacingy, 10f);
			cat1.guiTexture.texture = (Texture2D)Resources.Load("images/CategoryImages/"+cat1.guiTexture.name, typeof(Texture2D));

        }
        if (cat2 != null) {
            cat2.transform.localScale = new Vector3(scale,scale,1);
            cat2.transform.position = new Vector3(groupButton.guiTexture.transform.position.x + spacingx,
                                                  groupButton.guiTexture.transform.position.y, 10f);
			cat2.guiTexture.texture = (Texture2D)Resources.Load("images/CategoryImages/"+cat2.guiTexture.name, typeof(Texture2D));
        }
        if (cat3 != null) {
            cat3.transform.localScale = new Vector3(scale,scale,1);
            cat3.transform.position = new Vector3(groupButton.guiTexture.transform.position.x,
                                                  groupButton.guiTexture.transform.position.y- spacingy, 10f);
			cat3.guiTexture.texture = (Texture2D)Resources.Load("images/CategoryImages/"+cat3.guiTexture.name, typeof(Texture2D));
        }
        if (cat4 != null) {
            cat4.transform.localScale = new Vector3(scale,scale,1);
            cat4.transform.position = new Vector3(groupButton.guiTexture.transform.position.x - spacingx,
                                                  groupButton.guiTexture.transform.position.y, 10f);
			cat4.guiTexture.texture = (Texture2D)Resources.Load("images/CategoryImages/"+cat4.guiTexture.name, typeof(Texture2D));
        }
    }

    public void addCatTexts() {
        GameObject cat1Text, cat2Text, cat3Text, cat4Text;
        if (cat1 != null) {
            cat1Text = new GameObject();
            cat1Text.AddComponent("GUIText");
            cat1Text.transform.parent = cat1.transform;
			cat1Text.guiText.color = Color.black;
            cat1Text.guiText.text = CategorySwitch.getCategoryFromID(Convert.ToInt32 (cat1.guiTexture.name));
            cat1Text.guiText.fontSize = (int)(Screen.width/20);
            cat1Text.guiText.anchor = TextAnchor.LowerCenter;
            cat1Text.transform.localScale = cat1Text.transform.root.localScale;
            cat1Text.transform.localPosition = new Vector3 (0f,0f,11f);
            cat1Text.guiText.pixelOffset = new Vector2(0,Screen.height / -10);
        }

        if (cat2 != null) {
            cat2Text = new GameObject();
            cat2Text.AddComponent("GUIText");
            cat2Text.transform.parent = cat2.transform;
			cat2Text.guiText.color = Color.black;
            cat2Text.guiText.text = CategorySwitch.getCategoryFromID(Convert.ToInt32 (cat2.guiTexture.name));
            cat2Text.guiText.fontSize = (int)(Screen.width/20);
            cat2Text.guiText.anchor = TextAnchor.LowerCenter;
            cat2Text.transform.localScale = cat2Text.transform.root.localScale;
            cat2Text.transform.localPosition = new Vector3 (0f,0f,11f);
            cat2Text.guiText.pixelOffset = new Vector2(0,Screen.height / -10);
        }

        if (cat3 != null) {
            cat3Text = new GameObject();
            cat3Text.AddComponent("GUIText");
            cat3Text.transform.parent = cat3.transform;
			cat3Text.guiText.color = Color.black;
            cat3Text.guiText.text = CategorySwitch.getCategoryFromID(Convert.ToInt32 (cat3.guiTexture.name));
            cat3Text.guiText.fontSize = (int)(Screen.width/20);
            cat3Text.guiText.anchor = TextAnchor.LowerCenter;
            cat3Text.transform.localScale = cat3Text.transform.root.localScale;
            cat3Text.transform.localPosition = new Vector3 (0f,0f,11f);
            cat3Text.guiText.pixelOffset = new Vector2(0,Screen.height / -10);
        }

        if (cat4 != null) {
            cat4Text = new GameObject();
            cat4Text.AddComponent("GUIText");
            cat4Text.transform.parent = cat4.transform;
			cat4Text.guiText.color = Color.black;
            cat4Text.guiText.text = CategorySwitch.getCategoryFromID(Convert.ToInt32 (cat4.guiTexture.name));
            cat4Text.guiText.fontSize = (int)(Screen.width/20);
            cat4Text.guiText.anchor = TextAnchor.LowerCenter;
            cat4Text.transform.localScale = cat4Text.transform.root.localScale;
            cat4Text.transform.localPosition = new Vector3 (0f,0f,11f);
            cat4Text.guiText.pixelOffset = new Vector2(0,Screen.height / -10);
        }
    }

    public void removeCatTexts() {
        Transform temp;
        if (cat1 != null) {
            temp = cat1.transform.GetChild(0);
            temp.parent = null;
            Destroy(temp.gameObject);
        }
		if (cat2 != null) {
            temp = cat2.transform.GetChild(0);
            temp.parent = null;
            Destroy(temp.gameObject);
        }
		if (cat3 != null) {
            temp = cat3.transform.GetChild(0);
            temp.parent = null;
            Destroy(temp.gameObject);
        }
		if (cat4 != null) {
            temp = cat4.transform.GetChild(0);
            temp.parent = null;
            Destroy(temp.gameObject);
        }
    }

}