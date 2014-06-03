/*       Client Program      */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

public class Client : MonoBehaviour{

	bool needsRunning;

	void Awake(){
		Network.Connect("172.17.4.160", 25000, "SSGame");
		needsRunning = true;

	}

	void Update(){
		if(Network.connections.Length == 1 && needsRunning == true){
			sendData ();
		}
	}

	void sendData(){
		needsRunning = false;
		Debug.Log ("Ran function!");
		// Run this if responses.csv is present and connection to server established
		if(File.Exists(Application.persistentDataPath + "/" + "responses.csv")){
			
			// Read stuff from results csv
			CsvFileReader reader;
			Stream stream;
			WWW tester; 
			if (Application.platform == RuntimePlatform.Android){
				tester = new WWW(Application.persistentDataPath + "/" + "responses.csv");
				while(!tester.isDone){};
				stream = new MemoryStream(tester.bytes);
				
				reader = new CsvFileReader(stream);	// Use reader object to read in csv file
			}
			else
				reader = new CsvFileReader(Application.persistentDataPath + "/" + "responses.csv");
			
			CsvRow row = new CsvRow();	// row will take in each row in csv file
			
			
			NetworkViewID viewID = Network.AllocateViewID();
			
			while(reader.ReadRow (row)){
				int prodid, catid;
				
				prodid = System.Convert.ToInt32(row[0]);
				catid = System.Convert.ToInt32(row[1]);
				networkView.RPC("ProcessResult", RPCMode.Server, prodid, catid);
			}
			
			
			// Clear contents of responses.csv since data was sent to server
			FileStream fileStream = File.Open(Application.persistentDataPath + "/" + "responses.csv", FileMode.Open);
			fileStream.SetLength(0);
			fileStream.Close ();
			
		}
	}
	
	
	
	[RPC]
	void ProcessResult (int productid, int categoryid){

	}







}

