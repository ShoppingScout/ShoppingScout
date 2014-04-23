using UnityEngine;
using System.Collections;
using System;
public class CollisionAnswer : MonoBehaviour {
	private Item currentItem;
	
	void OnTriggerEnter2D(Collider2D other) {
		currentItem = LevelScript.currentItem;
		GUIText debugText = GameObject.Find ("DebugText").guiText;
		GameObject checker = GameObject.Find ("PlayerBalance");
		Main.itemAnswer = Convert.ToInt32 (other.guiTexture.name);
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
	
	void onTriggerExit2D(Collider2D other){
		Main.itemAnswer = -1;
	}
	
	
}