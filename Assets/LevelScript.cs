
using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class LevelScript : MonoBehaviour {
			private Vector3 pos1, pos2, pos3, pos4, pos5, pos6, resetPos;
			GroupButton Button1, Button2, Button3, Button4, Button5, Button6;
			
			//Default position of buttons
			private void Awake()
			{
				pos1 = new Vector3 (0.5f, 0.4f, 0f);
				pos2 = new Vector3 (0.8f, 0.32f, 0f);
				pos3 = new Vector3 (0.8f, 0.18f, 0f);
				pos4 = new Vector3 (0.5f, 0.1f, 0f);
				pos5 = new Vector3 (0.2f, 0.18f, 0f);
				pos6 = new Vector3 (0.2f, 0.32f, 0f);
			}
			
			void Start(){
			}
			
			public LevelScript()
			{
			}
			
			//Switch to determine which layout and categories to load
			public void LoadLevelSettings(int level){
				switch(level){
					case 1:
					Button1 = new GroupButton(pos1, 1);
					Button1.addCategory(3,2,4,1);
					Button4 = new GroupButton(pos4, 4);
					Button4.addCategory(3,2,4,1);
					GameObject.Find("Game Object Clock").GetComponent<Clock_Script>().SetStartTime(30);
						//GameObject.Find("Button0").turnOn(1,3,4,2);
						//GameObject.Find("Button1").turnOn(5,7,8,6);
						//StartStackKnown(0, 199);
						//StartStackUnknown(200,219);
						break;		
				}
			}
			
			//Function to make buttons invisible when timer runs out
			public void Deinitialize(){
				GroupButton.deleteGroupButtons();
				
			}
}

