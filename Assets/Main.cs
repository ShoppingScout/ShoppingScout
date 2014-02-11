using UnityEngine;
using System.Collections;

public class Item{
	//so from baby to unknown, the categories will correspond to an int from 0 to 7
	//public int Level_1 { get; set; }
	//public int Level_1;
	/*Future levels
	public int Level_Baby { get; set; }
	public int Level_Beauty { get; set; }
	...*/
	/*
	//public string FileName { get; set; } //filename for image

    public Item(int level_1){
        Level_1 = level_1;
		//FileName = filename;
    }//item

	*/

	// Field 
	public string name;
	
	// Constructor that takes no arguments. 
	public Item()
	{
		name = "unknown";
	}
	
	// Constructor that takes one argument. 
	public Item(string nm)
	{
		name = nm;
	}
	
	// Method 
	public void SetName(string newName)
	{
		name = newName;
	}
}//item

public class Main : MonoBehaviour {
	public Texture btnTexture;
	public GUIStyle myGUIStyle;
	

	void Start(){
		//pretend this is the first install, every time
		//later we will make this value permanently set for non-first installs
		bool first_install = true;

		//First check whether or not this is the user's first install
		if(first_install == true){
			//If it is, create a data structure of Items with their image filenames and categories (int 0-7)
			Item[] items = new Item[5];
			int i = 0;

			Random random = new Random();
			int r = Random.Range(0, 7);

			//here we would normally import info from the database
			//but instead we'll make sure random sample products
			//here we'll use Emmanuel's product selection function
			while(i < 5) {
				//items[0].Level_1 = whatever the category is 0-7
				//items[i].Level_1 = r;
				items[i].name = "test";
				i++;
			}
		}//if
		
		CategoryButtons categoryButtons = new CategoryButtons(4);
		
		//while timer != 0
		
			//get current item's category

			//get user input
			
			//check if user input is same as item's category
				//if item category is 0, put user input into item's category
				//else if, user input == item category execute scoring.correct
				//else, user is wrong so execute scoring.incorrect
				
		//make game end when timer runs out
	}

	void Update (){
		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.GetKey(KeyCode.Escape))
			{
				Application.Quit();	
				return;
			}
		}
	}
}