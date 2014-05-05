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

	private int myDepth;

	void Awake ()
	{		
		playerBalance = GameObject.Find ("PlayerBalance").guiText;
		PlayerPrefs.DeleteAll ();	// For testing purposes, resets balance
		balance = PlayerPrefs.GetInt ("Balance", 0); // Look into an alternative for saving player's balance other than PlayerPrefs
		myMultiplier = 1;
		streak = 1;
		timeLeft = 30.0f;
	}

	public void initialize(int depth)
	{
		myDepth = depth - 1;
	}

	/*void Update ()
	{
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			timeLeft = 0;
			Application.LoadLevel("Statistics");
		}
	}*/
	
	
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

//		debugText.text = "masterIndex: " + currentItem.get_myIndex() + "\ncurrent.answer: " + currentItem.get_ctg(0) + "\nresult: " + answer;
		debugText.text = "responses1:" + LevelScript.currentItem.get_responses(0)
			+ "\nresponse2: " + LevelScript.currentItem.get_responses(1) + "\nresponse3: " + LevelScript.currentItem.get_responses(2);

		if (LevelScript.currentItem.get_ctg(myDepth) == 0) {
			Inc_Balance (true);
			LevelScript.currentItem.set_responses(answer);
			StartCoroutine(GameObject.Find("center").GetComponent<CollisionAnswer>().flashAnswer(true));
		}

		else if (LevelScript.currentItem.get_ctg(myDepth) == answer) {
			Inc_Balance (true);
			LevelScript.currentItem.set_responses(answer);
			StartCoroutine(GameObject.Find("center").GetComponent<CollisionAnswer>().flashAnswer(true));
		}
		
		else {
			Inc_Balance (false);
			LevelScript.currentItem.set_responses(answer);
			StartCoroutine(GameObject.Find("center").GetComponent<CollisionAnswer>().flashAnswer(false));
		}
	}
	
	void OnGUI ()
	{
		playerBalance.text = "$ " + balance.ToString ();

	}
}