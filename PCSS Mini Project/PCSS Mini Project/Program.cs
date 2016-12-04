using System;
using System.Collections.Generic;
using System.Collections;
using System.IO; 
using System.Net; 
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSS_Mini_Project
{
    class TcpEchoClient
    {
        static void Main(string[] args)
        { 
			//Variables are being assigned
			bool activeOr, startActive = true, stillActive = true, isRunning = true;
			string caseSwitch = "";
			Console.WriteLine("Starting echo client...");
			Console.WriteLine("Type 'x' to play");
			Console.WriteLine("Type 'q' to exit");


			//While-loop for menu using switch cases
			while (startActive == true)
			{
				caseSwitch = Console.ReadLine();
				switch(caseSwitch)
				{
				case "x":
					Console.WriteLine("Connecting to Lobby");
					startActive = false;
					break;
				case "q":
					Environment.Exit(0);
					break;
				default:
					Console.WriteLine("Type 'x' to play, else type 'q' exit");
					break;
				}
			}

            //Connects to the server
            string playerReceive, playerTurn, tempString, placement;
            int eyes, playerPlacement = 0;
            TcpClient client;
            NetworkStream stream;
            StreamReader reader;
            StreamWriter writer;


            int port = 1615;
            client = new TcpClient("localhost", port);
            stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { AutoFlush = true };
            playerReceive = reader.ReadLine();
            playerTurn = playerReceive;


            Random rnd = new Random();

        }
    }
}
