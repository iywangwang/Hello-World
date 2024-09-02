using System.Configuration;
using System.Data;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace Network
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
#if fause
            //创建客户端
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            try
            {
                socket.Connect("127.0.0.1", 8888);

                socket.Send(Encoding.UTF8.GetBytes("Hellor World"));
            }
            catch (SocketException e)
            {
                MessageBox.Show($"服务器未连接:\n{e.Message}");
            }

#elif fause

            //创建服务器
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Bind(new IPEndPoint(IPAddress.Any, 9999));

            socket.Listen(24);

            byte[] buffer = new byte[1024];

            while (true)
            {
                Socket client = socket.Accept();
                client.Receive(buffer);
                if (client.Connected)
                {
                    MessageBox.Show($"{Encoding.UTF8.GetString(buffer)}");
                }
            }

#elif true

            //UDP，指定接收
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            EndPoint ep1 = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            socket.SendTo(Encoding.UTF8.GetBytes("Hello World - 9999"), ep1);

            EndPoint ep2 = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9998);
            socket.SendTo(Encoding.UTF8.GetBytes("Hello World - 9998"), ep2);

#elif false
            //UDP，广播
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            EndPoint ep = new IPEndPoint(IPAddress.Parse("192.168.1.255"), 9999);

            //允许广播 即在192.168.1.*** 局域网下的所有端口都会收到信息
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);

            socket.SendTo(Encoding.UTF8.GetBytes("Hello Word - 9999"), ep);
#endif
        }
    }
}
