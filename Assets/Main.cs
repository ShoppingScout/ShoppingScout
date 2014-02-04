//jesse: testing, testing
//jesse: second test
//jesse: third test

using UnityEngine;
using System.Collections;

public class Item{
	//so from baby to unknown, the categories will correspond to an int from 0 to 7
	public int Level_1 { get; set; }
	/*Future levels
	public int Level_Baby { get; set; }
	public int Level_Beauty { get; set; }
	...*/
	
	//public string FileName { get; set; }

    public Item(int level_1){
        Level_1 = level_1;
		//FileName = filename;
    }//item
}//item

//TEST
//mgsteinkamp
public class Main : MonoBehaviour {
	public Texture btnTexture;
	public GUIStyle myGUIStyle;
	

	void Start(){
		//First check whether or not this is the user's first install
		if(first_install == true){
			//If it is, create a data structure of Items with their image filenames and categories (int 0-7)
			Stack items = new Stack();
			int i = 0;
			
			do{
				items.Push(new Item);
				//items[0].Level_1 = whatever the category is 0-7
				items.[i].Level_1 = 0;
				//items[0].FileName = image filename
				i++;
			} while()
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