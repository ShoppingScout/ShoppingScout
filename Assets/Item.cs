using UnityEngine;
using System.Collections;

public class Item {
	private int LocalID,
				ProductID;
	private string ProductName;
	private string Image;
	private int[] Category;

	Item(int LID, int PID, string PName,string Img){
		LocalID = LID;
		ProductID = PID;
		ProductName = PName;
		Image = Img;
		Category = new int[20];
	}

	// Accessor functions
	int get_LID(){ return LocalID; }
	int get_PID(){ return ProductID; }
	string get_PName(){ return ProductName; }
	string get_IMG(){ return Image; }
	int get_ctg(int index){ 
		if(index < 20)
			return Category[index];
		else
			return Category[0];	// Index zero contains "ALL Products" Category
	}

	// Mutator for Item's categories
	void set_ctg(int index, int ctg){
		Category[index] = ctg;
	}






}
