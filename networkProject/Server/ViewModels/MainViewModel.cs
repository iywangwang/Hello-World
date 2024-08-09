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

namespace Server.ViewModels
{
    internal class MainViewModel : BindableBase
    {
        private string _title = "服务端";
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

        private string _selectFile;
        public string SelectFile
        {
            get { return _selectFile; }
            set { SetProperty(ref _selectFile, value); }
        }

        private string _logReceive;
        public string LogReceive
        {
            get { return _logReceive; }
            set { SetProperty(ref _logReceive, value); }
        }

        private string _sendtext;
        public string Sendtext
        {
            get { return _sendtext; }
            set { SetProperty(ref _sendtext, value); }
        }

        //SynchronizedCollection 确保对集合的所有操作都是线程安全的，这意味着你可以在多个线程之间安全地共享和修改集合。
        //集合使用一个锁（由 SyncRoot 属性提供）来同步对集合的访问，确保在同一时间只有一个线程可以修改集合。
        //SynchronizedCollection 实现了 IList<T> 接口
        private SynchronizedCollection<IpSocket> _dicSocket;    // 一个集合关于连接到服务端的客户端套接字（IP地址和SOCKET）
        public SynchronizedCollection<IpSocket> DicSocket
        {
            get { return _dicSocket; }
            set
            {
                SetProperty(ref _dicSocket, value);
                RaisePropertyChanged();
            }
        }

        private Socket _selectSocket;
        public Socket SelectSocket
        {
            get { return _selectSocket; }
            set { SetProperty(ref _selectSocket, value); }
        }

        public DelegateCommand StartListen { get; private set; }          // 开始监听命令

        public DelegateCommand StopListen { get; private set; }            // 停止监听命令

        public DelegateCommand SelectCommand { get; private set; }         // 选择文件命令

        public DelegateCommand SendFileCommand { get; private set; }        // 发送文件命令

        public DelegateCommand SendMessageCommand { get; private set; }     // 发送消息命令

        public Socket socketWatch;                     // 用于监听的Socket
        public Socket socketSend;                      // 用于通信的Socket

        Thread AcceptSocketThread;                    // 创建监听连接de线程，接收消息的线程
        Thread threadReceive;                         // 接收客户端发送消息的线程

        public bool AcceptSocketBool;
        public bool ThreadReceiveBool;

        public MainViewModel()
        {
            DicSocket = new SynchronizedCollection<IpSocket>();

            StartListen = new DelegateCommand(startListen);

            StopListen = new DelegateCommand(StopListenFun);

            SelectCommand = new DelegateCommand(SelectFileFun);

            SendFileCommand = new DelegateCommand(SendFilesFun);

            SendMessageCommand = new DelegateCommand(Server2Client);
        }

        // 开始监听并接收客户端发送的消息
        public void startListen()
        {
            ThreadReceiveBool = true;
            AcceptSocketBool = true;
            if (socketWatch == null)
            {
                try
                {
                    // step1: 在服务器端创建一个负责监听IP地址和端口号的Socket
                    socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    //Trim() 是 string 类型的一个方法，用于从字符串的开头和结尾移除空白字符。
                    IPAddress ip = IPAddress.Parse(Ip.Trim());      // step2: 获取IP地址

                    IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(Port.Trim()));    // step3: 获取Port

                    socketWatch.Bind(point);             // step4: 给服务器端的SOCKET绑定IP和Port

                    socketWatch.Listen(10);               // step5: 开始监听，并指定最大监听客户端的个数为10

                    LogReceive += "服务端：监听开启，等待客户端的连接........" + "\r\n";

                    // 等待客户端的连接，如果连接成功，就将客户端的Socket和对应的IP地址加入到监听集合中，并开启消息接收线程

                    //ParameterizedThreadStart
                    // 创建一个可以接收一个参数的线程启动方法。这个参数在调用 Thread.Start 方法时提供给线程函数
                    AcceptSocketThread = new Thread(new ParameterizedThreadStart(StartListenFunc));
                    AcceptSocketThread.IsBackground = true;     //将线程标记为后台线程。当所有前台线程（通常是主线程）退出时，后台线程也会自动退出。
                    AcceptSocketThread.Start(socketWatch);
                }

                catch (SocketException ex)
                {
                    LogReceive += ex.ToString() + "\r\n";
                }
            }
            else
            {
                LogReceive += "服务器端已开启监听：" + "\r\n";
            }


        }
        ///<summary>获取远程连接得Socket和IP地址，同时实现客户端消息的接收</summary>
        private void StartListenFunc(object obj)
        {
            Socket socketWatch = obj as Socket;
            while (AcceptSocketBool)
            {
                try
                {
                    // 等待客户端的连接，并且创建一个用于通信的Socket，这里只能是一个全局唯一变量的Socket类型
                    socketSend = socketWatch.Accept();

                    if (socketSend != null)
                    {
                        // 获取远程主机的ip地址和端口号
                        string strIp = socketSend.RemoteEndPoint.ToString();
                        if (JudgeHave(strIp))
                        {
                            IpSocket perClient = new IpSocket();
                            perClient.ip = strIp;
                            perClient.ItemSocket = socketSend;

                            // 这里要加一个判断条件，如果已经存在的客户端不能够添加进来

                            DicSocket.Add(perClient);

                            LogReceive += "远程主机：" + socketSend.RemoteEndPoint + "连接成功" + "\r\n";

                            // 定义接收客户端消息接收的线程
                            threadReceive = new Thread(new ParameterizedThreadStart(ReceiveMessage));
                            threadReceive.IsBackground = true;
                            threadReceive.Start(socketSend);
                        }
                    }
                    else
                    {
                        LogReceive = "客户端断开连接/服务端停止监听" + "\r\n";
                    }
                }
                catch
                {
                    LogReceive = "客户端断开连接/服务端停止监听" + "\r\n";
                }


            }

        }

        /// <summary>
        /// 用于判断最新监听到的客户端连接请求，在服务端是否已近为其创建了接收消息线程，若存在则不再为其创建接收消息线程
        /// </summary>
        /// <param name="ip">服务端最新监听到的客户端请求连接得ip地址</param>
        /// <returns>true表示不存在，可以创建接收线程。false表示存在，不为其创建接收线程</returns>
        private bool JudgeHave(string ip)
        {
            if (DicSocket.Count > 0)
            {
                foreach (IpSocket PerClient in DicSocket)
                {
                    if (PerClient.ip == ip)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return true;

        }


        /// <summary>服务器端不停的接收客户端发送的消息</summary>
        private void ReceiveMessage(object obj)
        {
            Socket socketSendLocal = obj as Socket;
            while (ThreadReceiveBool)
            {
                //客户端连接成功后，服务器接收客户端发送的消息
                byte[] buffer = new byte[2048];
                //实际接收到的有效字节数
                int count = socketSendLocal.Receive(buffer);
                //count 表示客户端关闭，要退出循环
                if (count == 0)
                {
                    LogReceive += "客户端:" + socketSendLocal.RemoteEndPoint + "断开连接...." + "\r\n";
                    break;
                }
                else
                {
                    string str = Encoding.Default.GetString(buffer, 0, count);
                    string strReceiveMsg = "接收：" + socketSendLocal.RemoteEndPoint + "发送的消息:" + str;
                    LogReceive += strReceiveMsg + "\r\n";

                    if (str == "disconnectNetwork")
                    {
                        // 当客户端与服务器断开连接后，需要更新DicSocket列表数据,下面代码可以更改为条件查询语句进行优化
                        for (int i = 0; i < DicSocket.Count; i++)
                        {
                            if (DicSocket[i].ip == socketSendLocal.RemoteEndPoint.ToString())
                            {
                                DicSocket.RemoveAt(i);
                            }
                        }

                        LogReceive += socketSendLocal.RemoteEndPoint.ToString() + "断开连接" + DicSocket.Count + "\r\n";
                        break;
                    }
                }
            }
        }


        ///<summmary>服务器给客户端发送消息</summmary>>

        private void Server2Client()
        {
            if (Sendtext != null && SelectSocket != null)
            {
                string strMessage = Sendtext.Trim();
                byte[] buffer = Encoding.Default.GetBytes(strMessage);
                List<byte> list = new List<byte>();
                list.Add(0);
                list.AddRange(buffer);
                //将泛型集合转换为数组
                byte[] newBuffer = list.ToArray();

                //获得用户选择的IP地址 ? 如何获取itemControl的选项
                try
                {
                    //string ip = SelectIp.ToString();
                    //DicSocket[SelectIp.ToString()].Send(newBuffer);
                    SelectSocket.Send(newBuffer);
                }
                catch (Exception ex)
                {
                    LogReceive += "向客户端发送消息发生异常：" + ex.ToString() + "\r\n";
                }
            }
            else
            {
                LogReceive += "请输入发送的消息/选择发送客户端对象...." + "\r\n";
            }

        }


        ///<summary>选择要发送的文件</summary>
        private void SelectFileFun()
        {
            //允许用户从文件系统中选择一个或多个文件，并将所选文件的路径返回给应用程序。
            OpenFileDialog dia = new OpenFileDialog();
            //设置初始目录
            dia.InitialDirectory = @"C:\CSharp_Study\Array\networkProject\Server";
            dia.Title = "请选择要发送的文件";
            //过滤文件类型
            dia.Filter = "所有文件|*.*";
            dia.ShowDialog();
            //将选择的文件的全路径赋值给文本框
            SelectFile = dia.FileName;
        }


        ///<summary>发送文件</summary>
        private void SendFilesFun()
        {
            List<byte> list = new List<byte>();
            //获取要发送的文件的路径
            string strPath = SelectFile.Trim();
            using (FileStream sw = new FileStream(strPath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[2048];
                int r = sw.Read(buffer, 0, buffer.Length);
                list.Add(1);
                list.AddRange(buffer);
                byte[] newBuffer = list.ToArray();

                try
                {
                    SelectSocket.Send(newBuffer, 0, r + 1, SocketFlags.None);
                }
                catch (Exception ex)
                {
                    LogReceive += "文件发送异常：" + ex.ToString() + "\r\n";
                }
            }
        }



        ///<summary>停止监听</summary>>
        private void StopListenFun()
        {
            if (ThreadReceiveBool && AcceptSocketBool)
            {

                if (socketWatch == null)
                {
                    LogReceive += "服务器还未启动......" + "\r\n";
                }
                else
                {
                    ThreadReceiveBool = false;
                    AcceptSocketBool = false;
                    if (socketSend != null) socketSend.Close();
                    if (socketWatch != null) socketWatch.Close();
                }
            }
            else
            {
                LogReceive += "服务器还未启动：" + "\r\n";
            }
        }
    }
}
