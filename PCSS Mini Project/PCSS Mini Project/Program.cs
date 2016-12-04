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
            string playerReceive, playerTurn, tempString;
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

            //Initializing the lobby
            while (stillActive == true)
            {
                writer.WriteLine("");
                playerTurn = reader.ReadLine();

                //Reads player1 connects
                if (playerTurn == "Player1")
                {
                    Console.Clear();
                    Console.WriteLine("You have been assigned " + playerReceive);
                    Console.WriteLine("");
                    Console.WriteLine("Lobby:");
                    Console.WriteLine("Player1 is in the lobby");
                    while (playerTurn == "Player1")
                    {
                        writer.WriteLine("");
                        playerTurn = reader.ReadLine();
                    }
                }

                //Player1 and player2 reads that player 2 has connected
                if (playerTurn == "Player2")
                {
                    Console.Clear();
                    Console.WriteLine("You have been assigned " + playerReceive);
                    Console.WriteLine("");
                    Console.WriteLine("Lobby:");
                    Console.WriteLine("Player1 is in the lobby");
                    Console.WriteLine("Player2 is in the lobby");
                    while (playerTurn == "Player2")
                    {
                        writer.WriteLine("");
                        playerTurn = reader.ReadLine();
                    }
                }

                //Player1, player2 and player3 reads that player3 has been connected 
                if (playerTurn == "Player3")
                {
                    Console.Clear();
                    Console.WriteLine("You have been assigned " + playerReceive);
                    Console.WriteLine("");
                    Console.WriteLine("Lobby:");
                    Console.WriteLine("Player1 is in the lobby");
                    Console.WriteLine("Player2 is in the lobby");
                    Console.WriteLine("Player3 is in the lobby");
                    while (playerTurn == "Player3")
                    {
                        writer.WriteLine("");
                        playerTurn = reader.ReadLine();
                    }

                }
                stillActive = false;
            }
            startActive = true;
            Console.WriteLine("");
            Console.WriteLine("Starting Game!");
            Console.WriteLine("");

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
                        if (tempString != playerTurn)
                        {
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
                            Console.WriteLine(tempString + " has the turn this round");
                            writer.WriteLine("");
                            tempString = reader.ReadLine();
                            playerTurn = tempString;
                        }
                    }
                }

                //If current player, you can interact with the console   
                if (playerReceive == playerTurn)
                {
                    //New random value for dice roll
                    eyes = rnd.Next(1, 6);
                    activeOr = true;
                    while (activeOr)
                    {
                        writer.WriteLine("");
                        playerTurn = reader.ReadLine();
                        Console.WriteLine("");
                        Console.WriteLine(playerReceive + " it's your turn now!");
                        Console.WriteLine("Press 'd' and then press enter to roll the dice");
                        //if d is written in console, dice has been thrown
                        if (Console.ReadLine() == "d")
                        {
                            playerPlacement += eyes;

                            Console.WriteLine("You have moved " + eyes + " fields to field number " + playerPlacement);
                            Console.WriteLine("");
                            //Ladders with +3 values
                            //Checks for snakes and ladders, for being sent back or forward
                            if (playerPlacement == 42 || playerPlacement == 48)
                            {
                                playerPlacement += 3;
                                Console.WriteLine("You found a ladder! You move 3 fields further! You new postion is" + playerPlacement);
                            }


                            //Ladders with +6 values
                            if (playerPlacement == 2 || playerPlacement == 27)
                            {
                                playerPlacement += 6;
                                Console.WriteLine("You found a ladder! You move 6 fields further! You new postion is " + playerPlacement);
                            }


                            //Snakes with -3 values
                            if (playerPlacement == 11 || playerPlacement == 30)
                            {
                                playerPlacement -= 3;
                                Console.WriteLine("You got attacked by a snake! You move 3 fields back! You new postion is " + playerPlacement);
                            }


                            //Snakes with -6 values
                            if (playerPlacement == 6 || playerPlacement == 20)
                            {
                                playerPlacement -= 6;
                                Console.WriteLine("You got attacked by a snake! You move 6 fields back! You new postion is " + playerPlacement);
                            }
                            //If a certain placement has been reached a winning statement is sent to the server
                            if (playerPlacement >= 50)
                            {
                                if (playerReceive == "Player1")
                                {
                                    writer.WriteLine("Player1 Won");
                                }
                                if (playerReceive == "Player2")
                                {
                                    writer.WriteLine("Player2 Won");
                                }
                                if (playerReceive == "Player3")
                                {
                                    writer.WriteLine("Player3 Won");
                                }
                                activeOr = false;
                            }
                            //Writes name to server to give turn to new player
                            writer.WriteLine(playerReceive);
                            playerTurn = reader.ReadLine();
                            activeOr = false;
                        }                      
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
