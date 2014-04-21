using UnityEngine;
using System.Collections;

public class CollisionAnswer : MonoBehaviour {
	private Item currentItem;
	void OnTriggerStay2D(Collider2D other) {
		currentItem = GameObject.Find("Scripts").GetComponent<LevelScript>().currentItem;
		GUIText debugText = GameObject.Find ("DebugText").guiText;
		GameObject checker = GameObject.Find ("PlayerBalance");
		
		if (Input.GetTouch (0).phase == TouchPhase.Ended) {
			debugText.text = "Calling Chris's function"+'\n'+ "with input value: " + other.guiTexture.name;
//			GameObject.FindGameObjectWithTag("PlayerBalance").GetComponent < Scoring_Money > ().Check_Answer(other.guiTexture.name);
			checker.GetComponent <Scoring_Money> ().Check_Answer(other.guiTexture.name);
			GameObject.Find("Scripts").GetComponent<LevelScript>().currentItem = GameObject.Find("Scripts").GetComponent<Product_DB>().next_Item();
			currentItem = GameObject.Find("Scripts").GetComponent<LevelScript>().currentItem;
			debugText.text = currentItem.get_PName();
			GameObject.Find("GUIProductImg").guiTexture.texture = (Texture2D) Resources.Load("Sample_pictures/"+currentItem.get_IMG());
		}
    }
}