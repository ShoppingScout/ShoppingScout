using UnityEngine;
using System.Collections;

public class PopupText : MonoBehaviour {
	private GameObject popupText;
	Vector3 oldPopupTextPosition;
	
	
	
	// Use this for initialization
	void Awake () {
		popupText = GameObject.Find ("PopupText");	
		oldPopupTextPosition = popupText.transform.position;
		
	}
	
	float speed=.2f;
	public void Update () {
		
		popupText.transform.Translate(Vector3.up * Time.deltaTime * speed);
		
		
	}
	
	public void test(string message){
		popupText.guiText.text = message;
	}
	
	public IEnumerator ShowPopupMessage(string message, float delay){
		popupText.transform.position = oldPopupTextPosition;
		popupText.guiText.text = message;
		popupText.SetActive(true);
		yield return new WaitForSeconds(delay);
		popupText.SetActive(false);
		this.enabled = false;

	}
	
}
