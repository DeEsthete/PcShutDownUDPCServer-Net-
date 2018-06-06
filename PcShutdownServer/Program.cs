using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PcShutdownServer
{
    class Program
    {
        private const string SERVER_IP = "233.0.0.0";
        private const int SERVER_PORT = 3535;

        static void Main(string[] args)
        {
            UdpClient udpSender = new UdpClient();

            udpSender.JoinMulticastGroup(IPAddress.Parse(SERVER_IP), 50);

            IPAddress broadcast = IPAddress.Parse("233.0.0.0");
            IPEndPoint endPoint = new IPEndPoint(broadcast, SERVER_PORT);

            while (true)
            {
                string key = Console.ReadLine();
                if (key == "t")
                {
                    byte[] data = Encoding.Default.GetBytes("t");
                    udpSender.Send(data, data.Length, endPoint);
                }
            }
        }
    }
}
