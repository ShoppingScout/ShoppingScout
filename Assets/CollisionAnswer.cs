using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;
public class CollisionAnswer : MonoBehaviour {
    private Item currentItem;
    public static AndroidJavaClass Vibrate;
    public static AndroidJavaObject jo;
    public static AndroidJavaClass jc;
    void Start() {
        if (Application.platform == RuntimePlatform.Android) {
            try {
                Vibrate  = new AndroidJavaClass("vibrate.ShoppingScout.app.MainActivity");
                jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                jo = Vibrate.GetStatic<AndroidJavaObject>("test");
            }
            catch (Exception e) {
                GUIText debugText = GameObject.Find ("DebugText").guiText;
                debugText.text = e.Message;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        currentItem = LevelScript.currentItem;
        GUIText debugText = GameObject.Find ("DebugText").guiText;
        GameObject checker = GameObject.Find ("PlayerBalance");
        if (Main.middle) {
            Main.itemAnswer = Convert.ToInt32 (other.guiTexture.name);
            //debugText.text = other.guiTexture.name;
            if (Application.platform == RuntimePlatform.Android) {
                try {
                    //Call Vibration function in Java, vibrationTime
                    jo.Call("vibrate2", 5);
                }
                catch (Exception e) {
                    debugText.text = e.Message;
                }
            }
        }
        //if (Input.GetTouch (0).phase == TouchPhase.Ended) {
//			GameObject.FindGameObjectWithTag("PlayerBalance").GetComponent < Scoring_Money > ().Check_Answer(other.guiTexture.name);
        //	Main.itemUpdate = Convert.ToInt32 (other.guiTexture.name);
        /*checker.GetComponent <Scoring_Money> ().Check_Answer(other.guiTexture.name);
        LevelScript.currentItem = GameObject.Find("Scripts").GetComponent<Product_DB>().next_Item();
        currentItem = LevelScript.currentItem;
        debugText.text = currentItem.get_PName();
        GameObject.Find("GUIProductImg").guiTexture.texture = (Texture2D) Resources.Load("Sample_pictures/"+currentItem.get_IMG());*/
        //}
    }
    void OnTriggerExit2D(Collider2D other) {
        Main.itemAnswer = -1;
        GUIText debugText = GameObject.Find ("DebugText").guiText;
        debugText.text = "Exited!!  " + Main.itemAnswer;
    }
    public IEnumerator flashAnswer(bool answer) {
        Color green = new Color(19f/255,113f/255,43f/255, 0);
        Color red = new Color(135f/255,15f/255,15f/255, 0);
        int flag;
        int flashFrames = 15;
        GameObject button = GameObject.Find("scorebox");
        if (answer) {
            flag = 0;
            for (int i = 0; i < flashFrames; i++) {
                button.guiTexture.color= new Color(((128 +((19f -128f)/flashFrames)*i)/255), ((128 +((113f -128f)/flashFrames)*i)/255), ((128 +((43f -128f)/flashFrames)*i)/255), ((128 +((80f -128f)/flashFrames)*i)/255) );
                yield return null;
            }
        }
        else {
            flag = 1;
            for (int i = 0; i < flashFrames; i++) {
                button.guiTexture.color= new Color(((128 +((135f -128f)/flashFrames)*i)/255), ((128 +((15f -128f)/flashFrames)*i)/255), ((128 +((15f -128f)/flashFrames)*i)/255), ((128 +((80f -128f)/flashFrames)*i)/255) );
                yield return null;
            }
        }
        for (int i = flashFrames-1; i >=0; i--) {
            if (flag == 0)
                button.guiTexture.color= new Color(((128 +((19f -128f)/flashFrames)*i)/255), ((128 +((113f -128f)/flashFrames)*i)/255), ((128 +((43f -128f)/flashFrames)*i)/255), ((128 +((80f -128f)/flashFrames)*i)/255) );
            else
                button.guiTexture.color= new Color(((128 +((135f -128f)/flashFrames)*i)/255), ((128 +((15f -128f)/flashFrames)*i)/255), ((128 +((15f -128f)/flashFrames)*i)/255), ((128 +((80f -128f)/flashFrames)*i)/255) );
            yield return null;
        }
    }
}