using System.Collections;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;


public class Client
{

    static int localPort;


    public string IP;  // define in init
    public int port;

    IPEndPoint remoteEndPoint;
    UdpClient client;

    private static void Main()
    {
        Client sendObj = new Client();
        sendObj.initialize();

        // testing via console
        // sendObj.inputFromConsole();

        // as server sending endless
        sendObj.sendEndless(" endless infos \n");

    }


    // Use this for initialization
    void Start()
    {
        initialize();
    }

    // init
    public void initialize()
    {
        // Endpunkt definieren, von dem die Nachrichten gesendet werden.
        Console.WriteLine("Client.init()");

        // define
        IP = "127.0.0.1";
        port = 8051;

        // ----------------------------
        // Senden
        // ----------------------------
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient();

        // status
        Console.WriteLine("Sending to " + IP + " : " + port);
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
        }

    }

    // sendData
    private void sendString(string message)
    {
        try
        {
            //if (message != "")

            byte[] data = Encoding.UTF8.GetBytes(message);

            client.Send(data, data.Length, remoteEndPoint);
        }
        catch (Exception err)
        {
            Console.WriteLine(err.ToString());
        }
    }

    private void sendEndless(string testStr)
    {
        do
        {
            sendString(testStr);

        }
        while (true);

    }
}
