using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text;

public class Product_DB : MonoBehaviour {

    // Use this for initialization
    // Need to create product stacks at the beginning of the game
    // Instead of traditional stacks, use Mairtin's modified array
    // So products can be reused without creating another stack


    public static Item[] known;
    public static Item[] unknown;
    public GameObject product;
    private static int max_index_known, max_index_unknown;
    private static int max_known_size, max_unknown_size;


    Product_DB() {
        known = new Item[500];	// May need to adjust sizes, keep size large just in case
        unknown = new Item[500];
        max_index_known = 0;	// Initialize to zero
        max_index_unknown = 0;	// After Products filled in these will contain the total number of products
        // in each "stack"
        //Debug.Log ("Hello");
    }

    private Item pop_known() {
        Item temp;
        if (max_index_known <= 0) {
            max_index_known = max_known_size;
        }

        int randindex = UnityEngine.Random.Range (0,max_index_known);

        temp = known[randindex];
        known[randindex] = known[max_index_known];
        known[max_index_known] = temp;
        max_index_known--;

        return temp;

    }

    private Item pop_unknown() {
        Item temp;
        if (max_index_unknown <= 0) {
            max_index_unknown = max_unknown_size;
        }

        int randindex = UnityEngine.Random.Range (0,max_index_unknown);

        temp = unknown[randindex];
        unknown[randindex] = unknown[max_index_unknown];
        unknown[max_index_unknown] = temp;
        max_index_unknown--;

        return temp;

    }


    public Item next_Item() {
        Item temp;
        double r, decision = 0.0;
        int MyStreak;

        // Assign random value
        r = UnityEngine.Random.Range(0.0F,1.0F);
        // Obtain player streak of correct categories
        GameObject scorer = GameObject.Find ("PlayerBalance");
        MyStreak = scorer.GetComponent<Scoring_Money> ().streak;

        // Set chance of getting an unknown product
        if (MyStreak > 5 && MyStreak < 10)
            decision = 0.15;
        else if (MyStreak >= 10 && MyStreak < 25)
            decision = 0.30;
        else if (MyStreak >= 25)
            decision = 0.60;

        Debug.Log (r);
        Debug.Log (MyStreak);
        if (r < decision) {
            temp = pop_unknown();
            Debug.Log ("unknown");
        }
        else {
            temp = pop_known ();
            Debug.Log ("known");
        }

        Debug.Log ("Sample_pictures/"+temp.get_IMG ());

        //UnityEngine.Object otemp = Resources.Load ("Sample_pictures/"+temp.get_IMG ());
        //if(otemp == null)
        //	Debug.Log ("Load Object Fail");
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
        if (Application.platform == RuntimePlatform.Android) {
            tester = new WWW(Application.streamingAssetsPath + "/Sample.csv");
            while (!tester.isDone) {};
            stream = new MemoryStream(tester.bytes);

            reader = new CsvFileReader(stream);	// Use reader object to read in csv file
        }
        else
            reader = new CsvFileReader("Assets/StreamingAssets/Sample.csv");
        CsvRow row = new CsvRow();	// row will take in each row in csv file

        // run while there are still rows in the csv file
        while (reader.ReadRow (row)) {
            if (!String.IsNullOrEmpty(row[3])) { // If first column for categories is not empty, put product in known stack
                known[max_index_known] = new Item();
                known[max_index_known].set_PID(System.Convert.ToInt32(row[0]));		// Assign Product ID
                known[max_index_known].set_LID(System.Convert.ToInt32(row[1]));		// Assign Local ID
                known[max_index_known].set_PName(row[2]);							// Assign Product Name
                known[max_index_known].set_IMG("image"+known[max_index_known].get_LID());	// Assign image file
                for (int i = 3; i < row.Count; i++) {
                    known[max_index_known].set_ctg (i-3, System.Convert.ToInt32(row[i]));					// Assign categories
                }
                max_index_known++;
            }
            else {
                unknown[max_index_unknown] = new Item();
                unknown[max_index_unknown].set_PID(System.Convert.ToInt32(row[0]));		// Assign Product ID
                unknown[max_index_unknown].set_LID(System.Convert.ToInt32(row[1]));		// Assign Local ID
                unknown[max_index_unknown].set_PName(row[2]);							// Assign Product Name
                //unknown[max_index_unknown].set_IMG("image"+unknown[max_index_unknown].get_LID()+".jpg");
                unknown[max_index_unknown].set_IMG("image"+unknown[max_index_unknown].get_LID());
                //Debug.Log (unknown[max_index_unknown].get_IMG());
                max_index_unknown++;
            }

        }

        //Item temp;
        max_known_size = max_index_known;
        max_unknown_size = max_index_unknown;
        //temp = next_Item();


    }

}

