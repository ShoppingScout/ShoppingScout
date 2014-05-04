using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text;

public class Product_DB : MonoBehaviour {

	
	//public static Item[] known;
	//public static Item[] unknown;
	public static Item[] master_list;
	//public GameObject product;
	private static int mlist_size;
	private static int known_start_index, known_end_index; 
	private static int unknown_start_index, unknown_end_index;
	private static int known_size, unknown_size;


	Product_DB(){
		//known = new Item[500];	// May need to adjust sizes, keep size large just in case
		//unknown = new Item[500];
		master_list = new Item[250];
		known_start_index = known_end_index = 0;
		unknown_start_index = unknown_end_index = 0;
		known_size = unknown_size = 0;

	}

	public void StartStackKnown(int Begin, int End){
		known_start_index = Begin;
		known_end_index = End;
		known_size = End+1-Begin;
	}

	public void StartStackUnknown(int Begin, int End){
		unknown_start_index = Begin;
		unknown_end_index = End;
		unknown_size = End+1-Begin;
	}

	private Item pop_known(){
		Item temp;
		if(known_start_index == known_end_index){
			known_end_index = known_start_index + known_size - 1;
		}

		int randindex = UnityEngine.Random.Range (known_start_index, known_end_index);
		temp = master_list[randindex];
		master_list[randindex] = master_list[known_end_index];
		master_list[known_end_index] = temp;
		known_end_index--;
		return temp;

	}

	private Item pop_unknown(){
		Item temp;
		if(unknown_start_index == unknown_end_index){
			unknown_end_index = unknown_start_index + unknown_size - 1;
		}

		int randindex = UnityEngine.Random.Range (unknown_start_index,unknown_end_index);

		temp = master_list[randindex];
		master_list[randindex] = master_list[unknown_end_index];
		master_list[unknown_end_index] = temp;
		unknown_end_index--;

		return temp;

	}


	public Item next_Item(){
		Item temp;
		double r, decision = 0.0;
		int MyStreak;

		// Assign random value
		r = UnityEngine.Random.Range(0.0F,1.0F);
		// Obtain player streak of correct categories
		GameObject scorer = GameObject.Find ("PlayerBalance");
		MyStreak = scorer.GetComponent<Scoring_Money> ().streak; 

		// Set chance of getting an unknown product
		if(MyStreak > 5 && MyStreak < 10)
			decision = 0.15;
		else if(MyStreak >= 10 && MyStreak < 25)
			decision = 0.30;
		else if(MyStreak >= 25)
			decision = 0.60;

		Debug.Log (r);
		Debug.Log (MyStreak);
		if(r < decision){
			temp = pop_unknown();
			Debug.Log ("unknown");
		}
		else{
			temp = pop_known ();
			Debug.Log ("known");
		}

		Debug.Log ("Sample_pictures/"+temp.get_IMG ());
		
			/*
		product = new GameObject();
		product.AddComponent ("GUITexture");
		product.guiTexture.texture = (Texture2D)Resources.Load ("Sample_pictures/"+temp.get_IMG ());
		product.transform.position = new Vector3(0.5f,0.73f,4.0f);
		product.transform.localScale = new Vector3(0.6f,0.24f,0f);*/
		return temp;

	}


	void Awake () {
		// Parse product by product from CSV, placing info into Product objects and filling "stacks"
		CsvFileReader reader;
		Stream stream;
		WWW tester; 
		if (Application.platform == RuntimePlatform.Android){
			tester = new WWW(Application.streamingAssetsPath + "/Sample.csv");
			while(!tester.isDone){};
			stream = new MemoryStream(tester.bytes);
			
			reader = new CsvFileReader(stream);	// Use reader object to read in csv file
			}
		else
			reader = new CsvFileReader("Assets/StreamingAssets/Sample.csv");
		
		CsvRow row = new CsvRow();	// row will take in each row in csv file

		// run while there are still rows in the csv file

		mlist_size = 0;

		while(reader.ReadRow (row)){

			if(!String.IsNullOrEmpty(row[3])){ // If first column for categories is not empty, put product in list as known product
				master_list[mlist_size] = new Item();
				master_list[mlist_size].set_PID(System.Convert.ToInt32(row[0]));		// Assign Product ID
				master_list[mlist_size].set_LID(System.Convert.ToInt32(row[1]));		// Assign Local ID
				master_list[mlist_size].set_PName(row[2]);							// Assign Product Name
				master_list[mlist_size].set_IMG("image"+master_list[mlist_size].get_LID());	// Assign image file
				for(int i = 3; i < row.Count; i++){
					master_list[mlist_size].set_ctg (i-3, System.Convert.ToInt32(row[i]));					// Assign categories
				}
				known_size++;
			}
			else{
				master_list[mlist_size] = new Item();
				master_list[mlist_size].set_PID(System.Convert.ToInt32(row[0]));		// Assign Product ID
				master_list[mlist_size].set_LID(System.Convert.ToInt32(row[1]));		// Assign Local ID
				master_list[mlist_size].set_PName(row[2]);							// Assign Product Name
				master_list[mlist_size].set_IMG("image"+master_list[mlist_size].get_LID());	// Assign image file
				unknown_size++;
			}

			mlist_size++;

		} 

		/*
		int mlist_size = 0;
		// Load known products
		for(int i = 0; i < level_1_products_known + level_2_products_known; i++){
			reader.ReadRow (row);
			master_list[mlist_size] = new Item();
			master_list[mlist_size].set_PID(System.Convert.ToInt32(row[0]));		// Assign Product ID
			master_list[mlist_size].set_LID(System.Convert.ToInt32(row[1]));		// Assign Local ID
			master_list[mlist_size].set_PName(row[2]);								// Assign Product Name
			master_list[mlist_size].set_IMG("image"+master_list[mlist_size].get_LID());	// Assign image file
			for(int j = 3; j < row.Count; j++){
				master_list[mlist_size].set_ctg (j-3, System.Convert.ToInt32(row[j]));					// Assign categories
			}
			mlist_size++;
		}
		// Load unknown products
		for(int i = 0; i < level_1_products_unknown + level_2_products_unknown; i++){
			reader.ReadRow (row);
			master_list[mlist_size] = new Item();
			master_list[mlist_size].set_PID(System.Convert.ToInt32(row[0]));		// Assign Product ID
			master_list[mlist_size].set_LID(System.Convert.ToInt32(row[1]));		// Assign Local ID
			master_list[mlist_size].set_PName(row[2]);								// Assign Product Name
			master_list[mlist_size].set_IMG("image"+master_list[mlist_size].get_LID());	// Assign image file

			mlist_size++;
		}*/

		//Item temp;
		//max_known_size = max_index_known;
		//max_unknown_size = max_index_unknown;
		//temp = next_Item();

		
	}

}
