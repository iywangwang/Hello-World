using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;

namespace Client.ViewModels
{
    internal class MainViewModel : BindableBase
    {
        private string _title = "客户端";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _ip = "127.0.0.1";
        public string Ip
        {
            get { return _ip; }
            set { SetProperty(ref _ip, value); }
        }

        private string _port = "9999";
        public string Port
        {
            get { return _port; }
            set { SetProperty(ref _port, value); }
        }

        private string _logText;
        public string LogText
        {
            get { return _logText; }
            set { SetProperty(ref _logText, value); }
        }

        private string _sendText;
        public string SendText
        {
            get { return _sendText; }
            set { SetProperty(ref _sendText, value); }
        }

        public bool CloseClientThread;   // 用于关闭客户端接收消息线程

        public Socket ClientSocketSend;  //创建连接的Socket

        private Thread CLientThreadReceive;  // 创建客户端接收服务器的线程变量

        public DelegateCommand ConnectedServer { get; private set; }
        public DelegateCommand DisconnectedServer { get; private set; }
        public DelegateCommand SendMessage { get; private set; }

        public MainViewModel()
        {
            ConnectedServer = new DelegateCommand(Client2Server);
            DisconnectedServer = new DelegateCommand(CloseClientFun);
            SendMessage = new DelegateCommand(SendMessageFun);
        }

        ///<summary>客户端连接到服务器</summary>>
        private void Client2Server()
        {
            CloseClientThread = true;
            if (Ip != null && Port != null)
            {
                try
                {
                    ClientSocketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPAddress ip = IPAddress.Parse(Ip.Trim());
                    ClientSocketSend.Connect(ip, Convert.ToInt32(Port.Trim()));
                    LogText += "连接成功......" + "\r\n";

                    // 开启循环接收服务器消息的线程
                    CLientThreadReceive = new Thread(new ThreadStart(Receive));
                    CLientThreadReceive.IsBackground = true;
                    CLientThreadReceive.Start();
                }
                catch (Exception ex)
                {
                    LogText += "连接到服务器失败：" + ex.ToString() + "\r\n";
                }

            }
            else
            {
                LogText += "请输入IP/Port：" + "\r\n";
            }
        }

        private void Receive()
        {
            try
            {
                while (CloseClientThread)
                {
                    byte[] buffer = new byte[2048];
                    //实际接收到的字节数
                    int r = ClientSocketSend.Receive(buffer);
                    if (r == 0)
                    {
                        LogText += "服务端断开连接........." + "\r\n";
                        break;
                    }
                    else
                    {
                        //判断发送的数据的类型
                        if (buffer[0] == 0)  //表示发送的是文字消息
                        {
                            string str = Encoding.Default.GetString(buffer, 1, r - 1);
                            LogText += "接收远程服务器:" + ClientSocketSend.RemoteEndPoint + "发送的消息:" + str + "\r\n";
                        }
                        //表示发送的是文件
                        if (buffer[0] == 1)         // 这里后期改进为WPF中专用的
                        {
                            SaveFileDialog sfd = new SaveFileDialog();
                            sfd.InitialDirectory = @"";
                            sfd.Title = "请选择要保存的文件";
                            sfd.Filter = "所有文件|*.*";
                            sfd.ShowDialog();

                            string strPath = sfd.FileName;
                            using (FileStream fsWrite = new FileStream(strPath, FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                fsWrite.Write(buffer, 1, r - 1);
                            }
                            LogText += "保存文件成功" + "\r\n";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogText += "接收服务端发送的消息出错/与服务器断开连接:" + "\r\n";
            }
        }

        private void SendMessageFun()
        {
            if (ClientSocketSend != null)
            {
                if (SendText != null)
                    try
                    {
                        string strMsg = SendText.Trim();
                        byte[] buffer = new byte[2048];
                        buffer = Encoding.Default.GetBytes(strMsg);
                        int receive = ClientSocketSend.Send(buffer);
                    }
                    catch (Exception ex)
                    {
                        LogText += "发送消息失败:" + ex.Message + "\r\n";
                    }
                else
                {
                    LogText += "请先输入要发送的信息:" + "\r\n";
                }
            }
            else
            {
                LogText += "请先连接到服务端:" + "\r\n";
            }
        }


        private void SendMessageDisconnect()
        {
            try
            {
                string strMsg = "disconnectNetwork";
                byte[] buffer = new byte[2048];
                buffer = Encoding.Default.GetBytes(strMsg);
                int receive = ClientSocketSend.Send(buffer);
            }
            catch (Exception ex)
            {
                LogText += "发送断开连接消息出错:" + ex.Message + "\r\n";
            }
        }


        private void CloseClientFun()
        {
            // 发送消息告诉服务端，我将断开连接；如果客户端主动断开与服务端的连接，
            // 最好实现让服务端接收消息的线程函数退出循环阻塞状态，不然会引发服务端异常：

            // System.Net.Sockets.SocketException: 您的主机中的软件中止了一个已建立的连接。   
            //An established connection was aborted by the software in your host machine

            SendMessageDisconnect();

            if (ClientSocketSend != null)
            {
                //终止线程
                CloseClientThread = false;

                //关闭socket
                ClientSocketSend.Close();
            }
            else
            {
                LogText += "客户端未开启" + "\r\n";
            }
        }
    }
}
