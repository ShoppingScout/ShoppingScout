using UnityEngine;
using System.Collections;

public class Item {
	private int LocalID,
				ProductID;
	private string ProductName;
	private string Image;
	private int[] Category;

	private int[] responses;
	private int responseCount;

	public Item(int LID, int PID, string PName,string Img, int index){
		LocalID = LID;
		ProductID = PID;
		ProductName = PName;
		Image = Img;
		Category = new int[5];	// Looking at the category tree, it seems most products do
								// not go deeper than 5 categories
		responses = new int[50];
		responseCount = 0;
	}

	public Item(){
		Category = new int[5];
		responses = new int[50];
	}

	// Accessor functions
	public int get_LID(){ return LocalID; }
	public int get_PID(){ return ProductID; }
	public string get_PName(){ return ProductName; }
	public string get_IMG(){ return Image; }
	public int get_ctg(int index){ 
		if(index < 5)
			return Category[index];
		else
			return -1;	// -1 indicates out of range
	}

	public int get_responses(int index) { return responses[index]; }

	// Mutator functions
	public void set_PID(int pid){ ProductID = pid; }
	public void set_LID(int lid){ LocalID = lid; }
	public void set_PName(string pname){ ProductName = pname; }
	public void set_IMG(string imgname){ Image = imgname; }
	public void set_ctg(int index, int ctg){
		Category[index] = ctg;
	}

	//Item.Load(Int index) return an item


	public void set_responses(int answer) {
		responses[responseCount] = answer;
		responseCount++;
	}

}
