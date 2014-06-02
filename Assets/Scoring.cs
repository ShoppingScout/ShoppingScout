/*using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour {
	private int totalBalance;
	private GameObject GUIProductImg;
	private PopupText popup;
	private GameObject debugText;
	private Texture[] productImages;
	private int currentProduct;

	// Use this for initialization
	void Awake () {
		currentProduct = 0;
		productImages = new Texture[10];
		productImages[0] = (Texture)Resources.LoadAssetAtPath("Assets/Resources/office.png", typeof (Texture));
		productImages[1] = (Texture)Resources.LoadAssetAtPath("Assets/Resources/baby.png", typeof (Texture));
		productImages[2] = (Texture)Resources.LoadAssetAtPath("Assets/Resources/grocery.png", typeof (Texture));
		productImages[3] = (Texture)Resources.LoadAssetAtPath("Assets/Resources/banana.png", typeof (Texture));

		debugText = GameObject.Find("DebugText");
		totalBalance = 0;
		GUIProductImg = GameObject.Find("GUIProductImg");
		popup = gameObject.GetComponent<PopupText> ();

		GUIProductImg.guiTexture.texture = productImages[0];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CheckAnswer(string category){
		
		if(category.Equals("GUILeftButton0") && GUIProductImg.guiTexture.texture.name.Equals("office")){
			NextImage("+$5");
		}
		else if(category.Equals("GUIBottomButton1") && GUIProductImg.guiTexture.texture.name.Equals("baby")){
			NextImage("+$5");
		}
		else if(category.Equals("GUILeftButton1") && GUIProductImg.guiTexture.texture.name.Equals("grocery")){
			NextImage("+$5");
		}
		else
			NextImage("WRONG!");
	}
	
	//two new functions, one for correct, one for incorrect
	public void Correct(){
		NextImage("+$5");
	}//correct
	
	public void Incorrect(){
			NextImage("WRONG!");
	}//incorrect

	private void NextImage(string message){
		gameObject.GetComponent<PopupText> ().enabled = true; 
		StartCoroutine (popup.ShowPopupMessage (message, 0.5f));
		//change image
		currentProduct++;
		GUIProductImg.guiTexture.texture = productImages[currentProduct];
		
	}
}
*/