using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class Client : MonoBehaviour
{
    //GameObject players 
    public Sprite GameObject;

    void Start()
     {
        //playerTransform = GameObject.Find("GamePiece").GetComponent(typeof(Transform)) as transform;
        GameObject player = new GameObject("GamePiece");
        SpriteRenderer renderer = player.AddComponent<SpriteRenderer>();
        renderer.sprite = GameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space key is pressed");
            RandomDiceRoll();
        }
    }
    
    //The randome dice roll 
    public void RandomDiceRoll()
    {
        int moveDistance = 0;
        moveDistance = UnityEngine.Random.Range(1, 7);
        //playerTransform.transform.position.x += moveDistance;
    }

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
}