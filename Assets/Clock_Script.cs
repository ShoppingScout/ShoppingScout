﻿using UnityEngine;
using System.Collections;


public class Clock_Script : MonoBehaviour {

    public bool isPaused = false;
    float startTime;
    float timeRemaining;
    float percent;
    float clockFGMaxWidth; 
	float callTime;
    public Texture2D rightSide;
    public Texture2D leftSide;
    public Texture2D back;
    public Texture2D blocker;
    public Texture2D finished;
    

	// Use this for initialization
	void Start () {
        startTime = 5.0f;
		callTime = Time.time;
	}
	
	

    public void Countdown()
    {
        timeRemaining = startTime - Time.time + callTime;
        percent = timeRemaining / startTime * 100;
        if (timeRemaining < 0)
        {
            timeRemaining = 0;
            isPaused = true;
            TimeIsUp();
        }
    }
	
	public void SetStartTime(float time)
	{
		startTime = time;
	}

    public void PauseClock() { isPaused = true; }

    public void UnpauseClock() { isPaused = false; }

    void TimeIsUp()
    {
		LevelScript.Deinitialize();
		GameObject.Find ("PlayerBalance").GetComponent <Scoring_Money> ().Deinitialize();
    }

    void OnGUI()
    {
		// Position and Scale clock here; can adjust 
        float pieClockX = Screen.width*0.40f;
        float pieClockY = Screen.height*0.01f;
        //float pieClockW = 60f;
        //float pieClockH = 60f;
		float pieClockW = Screen.width/5;
		float pieClockH = Screen.width/5;	//Use sreen width on both to keep box shape.
        float pieClockHalfW = pieClockW * 0.5f;
        float pieClockHalfH = pieClockH * 0.5f;
        
        bool isPastHalfway = percent < 50;
        Rect clockRect = new Rect(pieClockX, pieClockY, pieClockW, pieClockH);
        float rot = (percent / 100) * 360;
        Vector2 centerPoint = new Vector2(pieClockX + pieClockHalfW, pieClockY + pieClockHalfH);
        Matrix4x4 startMatrix = GUI.matrix;


        GUI.DrawTexture(clockRect, back, ScaleMode.StretchToFill, true, 0);
        if (isPastHalfway)
        {
            GUIUtility.RotateAroundPivot(-rot - 180, centerPoint);
            GUI.DrawTexture(clockRect, leftSide, ScaleMode.StretchToFill, true, 0);
            GUI.matrix = startMatrix;
            GUI.DrawTexture(clockRect, blocker, ScaleMode.StretchToFill, true, 0);
        }
        else
        {
            GUIUtility.RotateAroundPivot(-rot, centerPoint);
            GUI.DrawTexture(clockRect, rightSide, ScaleMode.StretchToFill, true, 0);
            GUI.matrix = startMatrix;
            GUI.DrawTexture(clockRect, leftSide, ScaleMode.StretchToFill, true, 0);
        }

        if (percent < 0)
        {
            GUI.DrawTexture(clockRect, finished, ScaleMode.StretchToFill, true, 0);
        }

        
    }
	
	public void addTime(float time){
		startTime+=time/2;
		if (timeRemaining > time/2)
			timeRemaining-=time/2;
		
	}
}
