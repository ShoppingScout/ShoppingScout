using UnityEngine;
using System.Collections;


public static class CategorySwitch : object {

	public static string getCategoryFromID(int ID){
		switch(ID){
			case 2: return "Pet Supplies";break;
			case 3: return "Beauty &\nPersonal Care";break;
			case 4: return "Baby";break;
			case 5: return "Grocery";break;
			case 6: return "Office Supplies";break;
			case 28242: return "Health & Nutrition";break;
			case 28347: return "Household";break;
			default: return "Error";break;
		}
	}

}
