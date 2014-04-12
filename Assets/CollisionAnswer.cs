using UnityEngine;
using System.Collections;

public class CollisionAnswer : MonoBehaviour {
	void OnTriggerStay2D(Collider2D other) {
		GUIText debugText = GameObject.Find ("DebugText").guiText;
		if (Input.GetTouch (0).phase == TouchPhase.Ended)
			debugText.text = "Calling Chris's function"+'\n'+ "with input value: " + other.guiTexture.name;
		
    }
}