using UnityEngine;
using System.Collections;

public class Product_Stacks : MonoBehaviour {

	// Use this for initialization
	// Need to create product stacks at the beginning of the game
	// Instead of traditional stacks, use Mairtin's modified array
	// So products can be reused without creating another stack

	
	private Item[] known;
	private Item[] unknown;
	private int max_index_known, max_index_unknown; // Not sure if needed, just in case

	Product_Stacks(){
		known = new Item[300];	// May need to adjust sizes
		unknown = new Item[200];
	}

	void Start () {
		// Parse product by product from CSV, placing info into Product objects

		// Create a "stack" of product objects
	}
	
	void startStackKnown(int Lower, Upper){
		Item product;
		
		while( Lower <= Upper && (product = Item.Load(Lower)) != 0)
			i++;
			
	}
	
	// Update is called once per frame
	void Update () {
		// If new product needed, pull new product from either known or unknown stack randomly
	}
}
