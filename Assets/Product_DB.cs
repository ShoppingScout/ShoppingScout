using UnityEngine;
using System.Collections;

public class Product_DB : MonoBehaviour {

	// Use this for initialization
	// Need to create product stacks at the beginning of the game
	// Instead of traditional stacks, use Mairtin's modified array
	// So products can be reused without creating another stack

	
	private Item[] known;
	private Item[] unknown;
	private int max_index_known, max_index_unknown; 

	Product_DB(){
		known = new Item[500];	// May need to adjust sizes, keep size large just in case
		unknown = new Item[500];
		max_index_known = 0;	// Initialize to zero
		max_index_unknown = 0;	// After Products filled in these will contain the total number of products
								// in each "stack"
	}

	void Start () {
		// Parse product by product from CSV, placing info into Product objects
		CsvFileReader reader = new CsvFileReader("Sample.csv");	// Use reader object to read in csv file
		CsvRow row = new CsvRow();	// row will take in each row in csv file

		// run while there are still rows in the csv file
		while(reader.ReadRow (row)){
			if(row.Count > 3){ // If row contains > 3 elements, it has some known categories for the product
				known[max_index_known].set_PID(row[0]);		// Assign Product ID
				knwon[max_index_known].set_LID(row[1]);		// Assign Local ID
			}

		}

	}

	
	// Update is called once per frame
	void Update () {
		// If new product needed, pull new product from either known or unknown stack randomly
	}
}
