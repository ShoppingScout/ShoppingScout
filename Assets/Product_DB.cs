using UnityEngine;
using System.Collections;
using System;

public class Product_DB : MonoBehaviour {

	// Use this for initialization
	// Need to create product stacks at the beginning of the game
	// Instead of traditional stacks, use Mairtin's modified array
	// So products can be reused without creating another stack

	
	public static Item[] known;
	public static Item[] unknown;
	private static int max_index_known, max_index_unknown; 
	private static int max_known_size, max_unknown_size;

	Product_DB(){
		known = new Item[500];	// May need to adjust sizes, keep size large just in case
		unknown = new Item[500];
		max_index_known = 0;	// Initialize to zero
		max_index_unknown = 0;	// After Products filled in these will contain the total number of products
								// in each "stack"
		//Debug.Log ("Hello");
	}

	private Item pop_known(){
		Item temp;
		if(max_index_known <= 0){
			max_index_known = max_known_size;
		}

		int randindex = UnityEngine.Random.Range (0,max_index_known);

		temp = known[randindex];
		known[randindex] = known[max_index_known];
		known[max_index_known] = temp;
		max_index_known--;

		return temp;

	}

	private Item pop_unknown(){
		Item temp;
		if(max_index_unknown <= 0){
			max_index_unknown = max_unknown_size;
		}

		int randindex = UnityEngine.Random.Range (0,max_index_unknown);

		temp = unknown[randindex];
		unknown[randindex] = unknown[max_index_unknown];
		unknown[max_index_unknown] = temp;
		max_index_unknown--;

		return temp;

	}

/*
	public Item next_Item(){
		Item temp;

	}
	*/

	void Awake () {
		// Parse product by product from CSV, placing info into Product objects and filling "stacks"

		CsvFileReader reader = new CsvFileReader("Assets/Sample.csv");	// Use reader object to read in csv file
		CsvRow row = new CsvRow();	// row will take in each row in csv file

		// run while there are still rows in the csv file
		while(reader.ReadRow (row)){
			if(!String.IsNullOrEmpty(row[3])){ // If first column for categories is not empty, put product in known stack
				known[max_index_known] = new Item();
				known[max_index_known].set_PID(System.Convert.ToInt32(row[0]));		// Assign Product ID
				known[max_index_known].set_LID(System.Convert.ToInt32(row[1]));		// Assign Local ID
				known[max_index_known].set_PName(row[2]);							// Assign Product Name
				known[max_index_known].set_IMG("image"+known[max_index_known].get_LID()+".jpg");	// Assign image file
				for(int i = 3; i < row.Count; i++){
					known[max_index_known].set_ctg (i-3, System.Convert.ToInt32(row[i]));					// Assign categories
				}
				max_index_known++;
			}
			else{
				unknown[max_index_unknown] = new Item();
				unknown[max_index_unknown].set_PID(System.Convert.ToInt32(row[0]));		// Assign Product ID
				unknown[max_index_unknown].set_LID(System.Convert.ToInt32(row[1]));		// Assign Local ID
				unknown[max_index_unknown].set_PName(row[2]);							// Assign Product Name
				unknown[max_index_unknown].set_IMG("image"+unknown[max_index_unknown].get_LID()+".jpg");
				//Debug.Log (unknown[max_index_unknown].get_IMG());
				max_index_unknown++;
			}

		}

		max_known_size = max_index_known;
		max_unknown_size = max_index_unknown;
		Item temp;
		temp = pop_known();
		Debug.Log (temp.get_IMG());

	}
	
}
