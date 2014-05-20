using UnityEngine;
using System.Collections;


public static class LevelUp : object {

	private static int level;
	private static int levelCutoff;
	private static GameObject experienceBar;
	private static float experienceRatio;
	private static int balance;
	private static int resetID;
	private static int startTimeBonusLevel, answerTimeBonusLevel, startMultBonusLevel, streakMultBonusLevel;
	public static float startTimeBonusFactor, answerTimeBonusFactor, startMultBonusFactor, streakMultBonusFactor;
	private static int levelBase, levelConstant;
	
	
	
	static LevelUp(){
		GUIText debugText = GameObject.Find ("DebugText").guiText;
		debugText.text = "Awake";
		resetID = 20;
		levelBase = 150; levelConstant = 10;
		startTimeBonusFactor = 5;
		answerTimeBonusFactor = .05f;
		startMultBonusFactor = .5f;
		streakMultBonusFactor = .1f;
		PlayerPrefs.SetFloat ("startTimeBonusFactor", startTimeBonusFactor);
		PlayerPrefs.SetFloat ("answerTimeBonusFactor", answerTimeBonusFactor);
		PlayerPrefs.SetFloat ("startMultBonusFactor", startMultBonusFactor);
		PlayerPrefs.SetFloat ("streakMultBonusFactor", streakMultBonusFactor);
		if (resetID != PlayerPrefs.GetInt("resetID", 0) || PlayerPrefs.GetInt("Balance", 0) > 5000){
			balance = 0;
			level = 1;
			startTimeBonusLevel = 0;
			answerTimeBonusLevel = 0;
			startMultBonusLevel = 0;
			streakMultBonusLevel = 0;
			
			PlayerPrefs.SetInt ("startTimeBonusLevel", startTimeBonusLevel);
			PlayerPrefs.SetInt ("answerTimeBonusLevel", answerTimeBonusLevel);
			PlayerPrefs.SetInt ("startMultBonusLevel", startMultBonusLevel);
			PlayerPrefs.SetInt ("streakMultBonusLevel", streakMultBonusLevel);
			
			PlayerPrefs.SetInt ("Balance", balance);
			PlayerPrefs.SetInt ("level", level);
			PlayerPrefs.SetInt ("resetID", resetID);
			PlayerPrefs.SetInt ("LevelUp", 0);
			Scoring_Money.setBalance(0);
			
		}
	}
	
	public static void startStage(){
		
		balance = PlayerPrefs.GetInt ("Balance", 0);
		level = PlayerPrefs.GetInt ("level", 1);
		levelCutoff = levelBase + levelConstant * level;
		experienceBar = GameObject.Find("experienceBar");
		updateExperienceBar();
		
	}
	
	public static void checkLevelUp(){
		balance = PlayerPrefs.GetInt ("Balance", 0);
		if (balance >= levelCutoff){
			PlayerPrefs.SetInt("LevelUp", 1);
			
		}
		else{
			updateExperienceBar();
		}
	}

	public static void levelUp(){
		if (balance > levelCutoff){
			balance -= levelCutoff;
			level++;
			levelCutoff = levelBase + levelConstant * level;
		}
		PlayerPrefs.SetInt ("Balance", balance);
		PlayerPrefs.SetInt ("level", level);
		updateExperienceBar();
		GUIText debugText = GameObject.Find ("DebugText").guiText;
		//debugText.text = "here";
		Scoring_Money.setBalance(balance);
		
	}
	
	public static void updateExperienceBar(){
		balance = PlayerPrefs.GetInt ("Balance", 0);
		experienceRatio = ((float) balance * 2) / (float)levelCutoff;
		if (experienceRatio < 0)
			experienceRatio = 0;
		experienceBar.transform.localScale = new Vector3 (experienceRatio, 0, 1);
	}
	
	
}