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
                switch (caseSwitch)
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




            //Game is running until it exits loop
            while (isRunning)
            {
                writer.WriteLine("");
                playerTurn = reader.ReadLine();
                //Searching for winning statements
                if (playerTurn == "Player1 Won")
                {
                    Console.WriteLine(playerTurn);
                    isRunning = false;
                }
                if (playerTurn == "Player2 Won")
                {
                    Console.WriteLine(playerTurn);
                    isRunning = false;
                }
                if (playerTurn == "Player3 Won")
                {
                    Console.WriteLine(playerTurn);
                    isRunning = false;
                }
                //If not the player, send the playername of the one that has the turn
                if (playerReceive != playerTurn)
                {
                    Console.WriteLine(playerTurn + " has the turn this round");
                    while (playerReceive != playerTurn)
                    {
                        writer.WriteLine("");
                        tempString = reader.ReadLine();
                        //Check again for winning statement
                        if (tempString == "Player1 Won")
                        {
                            Console.WriteLine(tempString);
                            isRunning = false;
                        }
                        if (tempString == "Player2 Won")
                        {
                            Console.WriteLine(tempString);
                            isRunning = false;
                        }
                        if (tempString == "Player3 Won")
                        {
                            Console.WriteLine(tempString);
                            isRunning = false;
                        }
                        //Check again for if not the current player and get response from server with the current player
                    }
                }
            }
        }
    }
}
