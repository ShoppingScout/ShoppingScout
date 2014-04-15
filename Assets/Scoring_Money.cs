using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System;

public class Scoring_Money : MonoBehaviour
{
	private static int balance;
	public static int myMultiplier;
	public int streak;
	private GUIText playerBalance;
	private double timeLeft;
	
	void Awake ()
	{		
		playerBalance = GameObject.Find ("PlayerBalance").guiText;
		PlayerPrefs.DeleteAll ();	// For testing purposes, resets balance
		balance = PlayerPrefs.GetInt ("Balance", 0); // Look into an alternative for saving player's balance other than PlayerPrefs
		myMultiplier = 1;
		streak = 1;
		timeLeft = 30.0f;
	}
	
	void update()
	{
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			timeLeft = 0;
			Application.LoadLevel("Statistics");
		}
	}
	
	
	void Inc_Balance (bool correct)
	{
		if (correct) {
			if (streak % 10 == 0)
				myMultiplier++;
			balance = balance + (5 * myMultiplier);
			PlayerPrefs.SetInt ("Balance", balance);
			streak++;
		} // if key up/correct answer
		
		else {
			balance -= 5;
			myMultiplier = 1;
			streak = 1;
			PlayerPrefs.SetInt ("Balance", balance);
		} // if key down/incorrect answer
	}
	
	
	public void Check_Answer (string inputAns)
	{
		int answer = Convert.ToInt32 (inputAns);
		GUIText debugText = GameObject.Find ("DebugText").guiText;

		debugText.text = "result: " + answer;

//		if (Item.category[depth == 0]) {
//			Inc_Balance (true);			
//		}

		if (answer % 2 == 0) {
			Inc_Balance (true);
		}
		
		if (answer % 2 == 1) {
			Inc_Balance (false);
		}
	}
	
	void OnGUI ()
	{
		playerBalance.text = "$ " + balance.ToString ();

	}
}