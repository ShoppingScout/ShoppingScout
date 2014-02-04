using UnityEngine;
using System;
using System.IO;
using System.Collections;

public class Product_Selection : MonoBehaviour {
	private string path;
	private GameObject product;

	public string[] known;
	public string[] unknown;

	string MyString = "Hello World!";
	char[] MyChar = {'.','j','p','g'};
	string NewString;
	int index;


	Product_Selection(){
		path = Directory.GetCurrentDirectory();
		path += @"\Assets\Resources";
		known = Directory.GetFiles(path + @"\known", "*");
		unknown = Directory.GetFiles(path + @"\unknown", "*");

		index = known[0].IndexOf ("Resources");
		NewString = index.ToString();
	}


	// Use this for initialization
	void Start () {
		product = new GameObject();
		product.AddComponent("GUITexture");
		//NewString = unknown[0].Remove(0,52);
		//NewString.Replace("\\","/");
		product.guiTexture.texture = (Texture2D)Resources.Load("unknown/baby");

	
	}
	
	// Update is called once per frame
	void Update () {
		NewString = unknown[0].Remove(0,52);
		NewString.Replace("\\","/");
		Debug.Log (NewString.TrimEnd(MyChar));
		
	}
}
