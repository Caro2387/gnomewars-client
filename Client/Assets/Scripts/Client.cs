using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class Client : MonoBehaviour
{

    //The randome dice roll 
    public void RandomDiceRoll()
    {
        int DiceRoll = 0;
        DiceRoll = UnityEngine.Random.Range(1, 6);
        Console.WriteLine();

    }


    //The client server 
    static int localPort;

    public int IP;
    public int port;

    IPEndPoint remoteEndPoint;
    TcpClient client;

    private static void Main()
    {
        Client sendObj = new Client();
        sendObj.initialize();

    }

    void start()
    {
        initialize();
    }

    public void initialize()
    {
        Console.WriteLine("Client.intit()");

        //Should be change 
        IP = "127.0.0.1";
        port = 8051;

        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new TcpClient();

        Console.WriteLine("sending to " + IP + " : " + port);
        Console.WriteLine("Testing: nc -lu " + IP + " : " + port);
    }

    public void inputFromConsole()
    {
        try
        {
            string text;
            do
            {
                text = Console.ReadLine();
                if (text != "")
                {
                    byte[] data = Encoding.UTF8.GetBytes(text);

                    client.Send(data, data.Length, remoteEndPoint);
                }
            } while (text != "");
        }
        catch (Exception err)
        {
            Console.WriteLine(err.ToString());
            throw;
        }
    }

    //SendData
    private void sendString(string message)
    {
        try
        {
            //if (message != " ")

            byte[] data = Encoding.UTF8.GetBytes(message);

            client.Send(data, data.Length, remoteEndPoint);
        }
        catch (Exception err)
        {
            Console.WriteLine(err.ToString());
            throw;
        }
    }
}