using UnityEngine;
using System.Collections;
using System.IO;
using System.IO.Pipes;
using System.Threading;

public static class PipeClient  {

    static NamedPipeClientStream client = new NamedPipeClientStream("HapticGlovePipe");
    static StreamWriter writer;
    static StreamReader reader;
    static bool closed = false;

    static PipeClient()
    {
        client.Connect();
        writer = new StreamWriter(client);

        //reader = new StreamReader(client);

        //ThreadPool.QueueUserWorkItem(x =>
        //{
        //    for (;;)
        //    {
        //        var args = reader.ReadLine().Split(' ');
        //        if (args[0] == "close") Application.Quit();
        //    }
        //});
    }

    public static void Vibrate(string hand, string finger, byte intensity)
    {
        if (!closed)
        {
            writer.WriteLine(hand + " " + finger + " " + intensity.ToString());
            writer.Flush();
        }
    }

    public static void Close()
    {
        if (!closed)
        {
            closed = true;
            writer.WriteLine("close");
            writer.Flush();
            client.Close();
        }
    }

}
