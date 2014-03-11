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
	private GUIText playerBalance;
	private int correct;
	private float current_time;
	
	void Awake ()
	{
		
		correct = 1;

		playerBalance = GameObject.Find ("PlayerBalance").guiText;
		PlayerPrefs.DeleteAll ();	// For testing purposes, resets balance
		balance = PlayerPrefs.GetInt ("Balance", 0); // Look into an alternative for saving player's balance other than PlayerPrefs
		myMultiplier = 1;
		//startTime = Time.time;
		timeLeft = 30.0f;
		count = 1;
		// E: Took out update(), don't need it here; update() is called by the game every frame
	}
	void Update ()
	{
		timeLeft -= Time.deltaTime;
		
		if(correct == 0) {
			current_time = timeLeft;
			//			playerBalance.color = Color.red;
			//			StartCoroutine(Wait());
			correct = 1;
		}
	}

	
	void Inc_Balance (int multiplier)
	{
		correct = 1;
		if (Event.current.type == EventType.MouseDown) {
			if (count % 5 == 0)
				timeLeft += 5;
			if (count % 10 == 0)
				myMultiplier++;
			balance = balance + (5 * myMultiplier);
			PlayerPrefs.SetInt ("Balance", balance);
			count++;
			correct = 1;
		} // if key up/correct answer
		
		if (Event.current.type == EventType.KeyDown) {
			balance -= 5;
			myMultiplier = 1;
			count = 1;
			PlayerPrefs.SetInt ("Balance", balance);
			correct = 0;
		} // if key down/incorrect answer
		
	}
	
	void OnGUI ()
	{
		GUILayout.Space (3);
		// Can change text color and font to fit with the rest of the game's graphics
		GUI.color = Color.black;
		
		
		
		playerBalance.text = "$ " + balance.ToString ();
		if (timeLeft < 0)
			timeLeft = 0; // GAME OVER
		Inc_Balance (1);		// May be better if called from sendmessage from another script
	}
	
}