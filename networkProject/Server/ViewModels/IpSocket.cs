using System.Net.Sockets;

namespace Server.ViewModels
{
    internal class IpSocket
    {
        public string ip { get; internal set; }
        public Socket ItemSocket { get; internal set; }
    }
}