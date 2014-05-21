using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System;
using System.IO;


public class Scoring_Money : MonoBehaviour
{
	private static int balance;
	public static float myMultiplier;
	public int streak;
	private GUIText playerBalance;
	private double timeLeft;

	private int myDepth;

	private int[] arID;
	private int[] arResponses;
	private int itemCount;


	void Start ()
	{		
		playerBalance = GameObject.Find ("PlayerBalance").guiText;
		//PlayerPrefs.DeleteAll ();	// For testing purposes, resets balance
		balance = PlayerPrefs.GetInt ("Balance", 0); // Look into an alternative for saving player's balance other than PlayerPrefs
		
		streak = 1;
		timeLeft = 30.0f;

		arID = new int[50];
		arResponses = new int[50];
		itemCount = 0;
	}

	public void initialize(int depth)
	{
		myDepth = depth - 1;
		myMultiplier = 1 +  PlayerPrefs.GetInt("startMultBonusLevel",0) * PlayerPrefs.GetFloat("startMultBonusFactor",0) ;
	}

	/*void Update ()
	{
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			timeLeft = 0;
			Application.LoadLevel("Statistics");
		}
	}*/

	public void Deinitialize() {
//		PlayerPrefs.SetInt ("Balance",  overallBalance + balance);
//		GUIText debugText = GameObject.Find ("DebugText").guiText;
//		debugText.text = "FINAL: " + PlayerPrefs.GetInt ("Balance");
		WriteToFile();
		//testingFile();
	}

	
	void Inc_Balance (bool correct)
	{
		if (correct) {
			if (streak % 10 == 0){
				myMultiplier = (float)(myMultiplier * Math.Pow(1 + PlayerPrefs.GetFloat("streakMultBonusFactor",0), PlayerPrefs.GetInt("streakMultBonusLevel", 0)));
				myMultiplier++;
			}
			balance = balance + (int) (5 * myMultiplier);
			PlayerPrefs.SetInt ("Balance", balance);
			GUIText debugText = GameObject.Find ("DebugText").guiText;
			debugText.text = "" + myMultiplier;
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
//			LevelScript.currentItem.set_responses(answer);
			SaveResponses(answer);
			GameObject.Find("Game Object Clock").GetComponent<Clock_Script>().addTime(.3f +  PlayerPrefs.GetInt("answerTimeBonusLevel",0) * PlayerPrefs.GetFloat("answerTimeBonusFactor",0));
			StartCoroutine(GameObject.Find("center").GetComponent<CollisionAnswer>().flashAnswer(true));
		}

		else if (LevelScript.currentItem.get_ctg(myDepth) == answer) {
			Inc_Balance (true);
//			LevelScript.currentItem.set_responses(answer);
			SaveResponses(answer);
			GameObject.Find("Game Object Clock").GetComponent<Clock_Script>().addTime(.3f +  PlayerPrefs.GetInt("answerTimeBonusLevel",0) * PlayerPrefs.GetFloat("answerTimeBonusFactor",0));
			StartCoroutine(GameObject.Find("center").GetComponent<CollisionAnswer>().flashAnswer(true));
		}
		
		else {
			Inc_Balance (false);
//			LevelScript.currentItem.set_responses(answer);
			SaveResponses(answer);
			StartCoroutine(GameObject.Find("center").GetComponent<CollisionAnswer>().flashAnswer(false));
		}
	}



	public void SaveResponses(int response)
	{
		arID[itemCount] = LevelScript.currentItem.get_PID();
		arResponses[itemCount] = response;
		itemCount++;
	}

	public void WriteToFile()
	{
		GUIText debugText = GameObject.Find ("DebugText").guiText;
		debugText.text = Application.persistentDataPath;
		
		StreamWriter _writer = null;
		
		FileInfo t = new FileInfo(Application.persistentDataPath + "/" + "responses.csv");
		if(!t.Exists)
			_writer = t.CreateText();
		else{
			t.Delete ();
			_writer=t.CreateText ();
		}
		
		for(int i = 0; i < itemCount; i++)
			_writer.Write(arID[i] + "," + arResponses[i] + "\n");
		
		_writer.Close ();
	}


	void OnGUI ()
	{
		playerBalance.text = "$ " + balance.ToString ();
		

	}
	
	public static void setBalance(int b){
		balance = b;
	}
}