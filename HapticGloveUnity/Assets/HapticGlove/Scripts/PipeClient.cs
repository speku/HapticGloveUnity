using UnityEngine;
using System.Collections;
using System.IO;
using System.IO.Pipes;

public static class PipeClient  {

    static NamedPipeClientStream client = new NamedPipeClientStream("HapticGlovePipe");
    static StreamWriter writer;
    static bool closed = false;

    static PipeClient()
    {
        client.Connect();
        writer = new StreamWriter(client);
    }

    public static void Vibrate(string hand, string finger, byte intensity)
    {
        writer.WriteLine(hand + " " + finger + " " + intensity.ToString());
        writer.Flush();
    }

    public static void Close()
    {
        if (!closed)
        {
            client.Close();
            closed = true;
        }
    }

}
