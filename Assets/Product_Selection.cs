using UnityEngine;
using System;
using System.IO;
using System.Collections;

public class Product_Selection : MonoBehaviour {
	private string path;
	private GameObject product;

	public static string[] known;
	public static string[] unknown;

	string MyString = "Hello World!";
	char[] MyChar = {'.','j','p','g'};
	string ProductImgFile;
	static int index;


	Product_Selection(){
		// Get all image file names
		path = Directory.GetCurrentDirectory();
		path += @"\Assets\Resources";
		known = Directory.GetFiles(path + @"\known", "*");
		unknown = Directory.GetFiles(path + @"\unknown", "*");

		index = known[0].IndexOf ("Resources");
		ProductImgFile = index.ToString();

	}




	// Use this for initialization
	void Start () {
		product = new GameObject();
		product.AddComponent("GUITexture");
		//ProductImgFile = unknown[0].Remove(0,52);
		//ProductImgFile.Replace("\\","/");

		ProductImgFile = known[0].Remove(0,index+10);
		ProductImgFile = ProductImgFile.Replace("\\","/");
		Debug.Log (ProductImgFile.TrimEnd(MyChar));
		//product.guiTexture.texture = (Texture2D)Resources.Load(ProductImgFile.TrimEnd(MyChar));
		product.guiTexture.texture = (Texture2D)Resources.Load("known/Image001");


		//Debug.Log (ProductImgFile.TrimEnd(MyChar));

	
	}
	
	// Update is called once per frame
	void Update () {
				
	}
}
