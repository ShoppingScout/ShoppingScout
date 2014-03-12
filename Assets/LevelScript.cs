
using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class LevelScript : MonoBehaviour {
			private static GameObject Button0;
			private static GameObject Button1;
			private static GameObject Button2;
			private static GameObject Button3;
			private static GameObject Button4;
			private static GameObject Button5;
			private void Awake()
			{
				Button0 = GameObject.Find("Button0");
				Button1 = GameObject.Find("Button1");
				Button2 = GameObject.Find("Button2");
				Button3 = GameObject.Find("Button3");
				Button4 = GameObject.Find("Button4");
				Button5 = GameObject.Find("Button5");
				
			}
			
			public LevelScript()
			{
			}
			public static void LoadLevelSettings(int level){
				switch(level){
					case 1:
						HideCat('0');
						HideCat('1');
						Button3.SetActive(false);
						Button2.SetActive(false);
						Button4.SetActive(false);
						Button5.SetActive(false);
						
						//GameObject.Find("Button0").turnOn(1,3,4,2);
						//GameObject.Find("Button1").turnOn(5,7,8,6);
						//StartStackKnown(0, 199);
						//StartStackUnknown(200,219);
						break;		
				}
			}
			private static void HideCat(char buttonid){
				string id = "Button" + buttonid;
				string mid = "GUIMidButton" + buttonid + " (UnityEngine.Transform)";
				for (int i = 0; i < GameObject.Find(id).transform.childCount; i++)
				{	
					if (GameObject.Find(id).transform.GetChild(i).ToString() == mid)
						continue;
					GameObject.Find(id).transform.GetChild(i).gameObject.SetActive(false);
				}
			}
			
			private static void ShowCat(char buttonid){
				string id = "Button" + buttonid;
				string mid = "GUIMidButton" + buttonid + " (UnityEngine.Transform)";
				for (int i = 0; i < GameObject.Find(id).transform.childCount; i++)
				{	
					if (GameObject.Find(id).transform.GetChild(i).ToString() == mid)
						continue;
					GameObject.Find(id).transform.GetChild(i).gameObject.SetActive(true);
				}
			}
			public static void Deinitialize(){
				Button0.SetActive(false);
				Button1.SetActive(false);
				Button2.SetActive(false);
				Button3.SetActive(false);
				Button4.SetActive(false);
				Button5.SetActive(false);
			}
}

