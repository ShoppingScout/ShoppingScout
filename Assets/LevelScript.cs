//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System;

public class LevelScript : MonoBehaviour {

			void LoadLevelSettings(int level){
				switch(level){
					case 1:
						GameObject.Find("Button0").active = true;
						GameObject.Find("Button1").active = true;
						//GameObject.Find("Button0").turnOn(1,3,4,2);
						//GameObject.Find("Button1").turnOn(5,7,8,6);
						//StartStackKnown(0, 199);
						//StartStackUnknown(200,219);
						break;		
				}
			}
}
