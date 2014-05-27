/*       Client Program      */

using UnityEngine;
using System;
using System.IO;
using System.Net;
using System.Text;
//using System.Net.Sockets;
using UdpKit;


public class Network : MonoBehaviour{
	UdpSocket socket;

	/*
	Network() {
		
		try {
			TcpClient tcpclnt = new TcpClient();
			Debug.Log("Connecting.....");
			
			tcpclnt.Connect("169.237.5.62",50000);
			// use the ipaddress as in the server program
			
			Debug.Log("Connected");
			Console.Write("Enter the string to be transmitted : ");
			
			String str=Console.ReadLine();
			Stream stm = tcpclnt.GetStream();
			
			ASCIIEncoding asen= new ASCIIEncoding();
			byte[] ba=asen.GetBytes(str);
			Console.WriteLine("Transmitting.....");
			
			stm.Write(ba,0,ba.Length);
			
			byte[] bb=new byte[100];
			int k=stm.Read(bb,0,100);
			
			for (int i=0;i<k;i++)
				Console.Write(Convert.ToChar(bb[i]));
			
			tcpclnt.Close();
		}
		
		catch (Exception e) {
			Console.WriteLine("Error..... " + e.StackTrace);
		}
	}

*/
	
}

