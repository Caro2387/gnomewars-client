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

    //GameObject players 
    public GameObject enemy;

    //TCP Client 
    static void Connect(String server, string message)
    {
        try
        {
            Int32 port = 1615;
            TcpClient client = new TcpClient(server, port);

            //Translating the passed message into ASCII and storing it in a byte array
            //Should be made so it takes all the other information instead of only a string
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

            //Get a client stream for reading and writing
            NetworkStream stream = client.GetStream();

            stream.Write(data, 0, data.Length);
            Console.WriteLine("sent: {0}", message);

            //Getting response from Tcp Server
            //Buffer to store the response bytes from the Tcp Server
            data = new Byte[256];

            //string to store the response ASCII representation
            String responseData = String.Empty;

            //Reading the first batch
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("received: {0}", responseData);
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: {0}", e);
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
            throw;
        }
    }

    private static void Main()
    {

    }

    void start()
    {
        //Making multiple gameobjects, fill out so it is for each of the connected players 
        for (int i = 0; i < 3; i++)
        {
            //instantiate(player);
        }
    }
}