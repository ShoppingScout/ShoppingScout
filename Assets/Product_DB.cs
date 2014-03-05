using UnityEngine;
using System.Collections;

public class Product_DB : MonoBehaviour {

	// Use this for initialization
	// Need to create product stacks at the beginning of the game
	// Instead of traditional stacks, use Mairtin's modified array
	// So products can be reused without creating another stack

	
	private Item[] known;
	private Item[] unknown;
	private int max_index_known, max_index_unknown; // Not sure if needed, just in case

	Product_DB(){
		known = new Item[300];	// May need to adjust sizes
		unknown = new Item[200];
	}

	void Start () {
		// Parse product by product from CSV, placing info into Product objects
		CsvFileReader reader = new CsvFileReader("Sample.csv");	// Use reader object to read in csv file
		CsvRow row = new CsvRow();	// row will take in each row in csv file

		// run while there are still rows in the csv file
		while(reader.ReadRow (row)){

		}

	}

	
	// Update is called once per frame
	void Update () {
		// If new product needed, pull new product from either known or unknown stack randomly
	}
}
