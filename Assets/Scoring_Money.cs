using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System;

public class Scoring_Money : MonoBehaviour
{
	
	public static int balance;	// public in case needed in another script
	public static int myMultiplier;
	private float startTime;
	private float elapsedTime;
	private float timeLeft;
	private int count;
	private GUIText timer, playerBalance;
	private GameObject popupText;
	private PopupText popup;
	
	void Awake ()
	{
		popup = gameObject.GetComponent<PopupText> ();
		//popup message
		popupText = GameObject.Find ("PopupText");
		//multiplier array

		timer = GameObject.Find ("Timer").guiText;
		playerBalance = GameObject.Find ("PlayerBalance").guiText;
		PlayerPrefs.DeleteAll ();	// For testing purposes, resets balance
		balance = PlayerPrefs.GetInt ("Balance", 0); // Look into an alternative for saving player's balance other than PlayerPrefs
		myMultiplier = 1;
		//startTime = Time.time;
		timeLeft = 30.0f;
		count = 1;
		// E: Took out update(), don't need it here; update() is called by the game every frame
	}
	
	/*
	void Inc_Balance(int multiplier)	// Placeholder function
	{
		//Event e = Event.current;
		if(Event.current.type == EventType.MouseDown){	// For testing purposes
			//balance = balance + (10*multiplier);
			balance = balance + (myMultiplier);
			myMultiplier++;
			PlayerPrefs.SetInt("Balance", balance);	// Save new balance
		}
	}
	*/
	
	/*
	void Inc_Balance(int multiplier)
	{
		timeLeft -= Time.deltaTime;
		if(Event.current.type == EventType.MouseDown) {
			if(startTime == 0) {
				startTime = Time.time;
				balance = balance + (myMultiplier);
				myMultiplier++;
			}

			if(startTime > 0) {
				elapsedTime = Time.time - startTime;
				balance = balance + (myMultiplier);
				myMultiplier++;
			}
		}
	}
	*/
	//int i=0;
	void Update ()
	{
		timeLeft -= Time.deltaTime;
				
		if (Input.touches.Length <= 0) {
			//if no touches	
		} else { //if there is touch	
			//execute this code for current touch[0] on screen
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				gameObject.GetComponent<PopupText> ().enabled = true;
				StartCoroutine (popup.ShowPopupMessage ("+$" + myMultiplier * 5, 0.2f));
			}
		}
	}
	
	void Inc_Balance (int multiplier)
	{
		if (Event.current.type == EventType.MouseDown) {
			if (count % 5 == 0)
				timeLeft += 5;
			if (count % 10 == 0)
				myMultiplier++;
			balance = balance + (5 * myMultiplier);
			PlayerPrefs.SetInt ("Balance", balance);
			count++;
			
			
		} // if key up/correct answer
		
		if (Event.current.type == EventType.KeyDown) {
			balance -= 5;
			myMultiplier = 1;
			count = 1;
			PlayerPrefs.SetInt ("Balance", balance);
		} // if key down/incorrect answer
		
	}
	
	void OnGUI ()
	{
		GUILayout.Space (3);
		// Can change text color and font to fit with the rest of the game's graphics
		GUI.color = Color.black;
		

		
		playerBalance.text = "$ " + balance.ToString ();
		

		timer.text = timeLeft.ToString ("N0");
		if (timeLeft < 0)
			timeLeft = 0; // GAME OVER
		//GUI.Label (new Rect(300, 100, 100, 20), (elapsedTime.ToString()));
		Inc_Balance (1);		// May be better if called from sendmessage from another script
	}
	
	IEnumerator ShowPopupMessage (string message, float delay)
	{
		
		popupText.guiText.text = message;
		popupText.SetActive (true);
		yield return new WaitForSeconds(delay);
		popupText.SetActive (false);
	}
}