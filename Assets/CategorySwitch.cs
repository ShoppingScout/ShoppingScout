using UnityEngine;
using System.Collections;


public static class CategorySwitch : object {

	public static string getCategoryFromID(int ID){
		switch(ID){
			case 2: return "Pet Supplies";
			case 3: return "Beauty &\nPersonal Care";
			case 4: return "Baby";
			case 5: return "Grocery";
			case 6: return "Office Supplies";
			case 28242: return "Health & Nutrition";
			case 28347: return "Household";
			default: return "Error";
		}
	}

}
