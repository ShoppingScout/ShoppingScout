
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
						Button1.addCategory(1,2,3,4);
						Button4 = new GroupButton(pos4, 4);
						Button4.addCategory(5,6,7,8);
						GameObject.Find("Game Object Clock").GetComponent<Clock_Script>().SetStartTime(30);
						//GameObject.Find("Button0").turnOn(1,3,4,2);
						//GameObject.Find("Button1").turnOn(5,7,8,6);
						//StartStackKnown(0, 199);
						//StartStackUnknown(200,219);
						break;		
					case 2:
						Button1 = new GroupButton(pos1, 1);
						Button1.addCategory(24017, 24015, 24013, 24012);
						Button2 = new GroupButton(pos2, 2);
						Button2.addCategory(28488, 23182, 23186, 24048);
						Button4 = new GroupButton(pos4, 4);
						Button4.addCategory(-1, 24002, 23105, 24008);
						Button6 = new GroupButton(pos6, 6);
						Button6.addCategory(24011, 24009, 24004, 24003);
						GameObject.Find("Game Object Clock").GetComponent<Clock_Script>().SetStartTime(30);
						break;
					case 3:
						Button1 = new GroupButton(pos1, 1);
						Button1.addCategory(24017, 24015, 24013, 24012);
						Button2 = new GroupButton(pos2, 2);
						Button2.addCategory(28488, 23182, 23186, 24048);
						Button3 = new GroupButton(pos3, 3);
						Button3.addCategory(-1, 24002, 23105, 24008);
						Button4 = new GroupButton(pos4, 4);
						Button4.addCategory(24017, 24015, 24013, 24012);
						Button5 = new GroupButton(pos5, 5);
						Button5.addCategory(28488, 23182, 23186, 24048);
						Button6 = new GroupButton(pos6, 6);
						Button6.addCategory(-1, 24002, 23105, 24008);
						GameObject.Find("Game Object Clock").GetComponent<Clock_Script>().SetStartTime(30);
						break;
				}
			}
			
			//Function to make buttons invisible when timer runs out
			public void Deinitialize(){
				GroupButton.deleteGroupButtons();
				
			}
}

