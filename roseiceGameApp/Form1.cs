using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//使用通訊協定和執行此類方法
using System.Net;//網路通訊協定
using System.Net.Sockets;//網路socket方法
using System.Threading;//多執行續方法

namespace roseiceGameApp
{
    public partial class Form1 : Form
    {
        //宣告表單物件
        UdpClient U;//宣告物件來接收and傳輸UDP資料
        Thread Thi;//監聽用執行續
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;//不攔截執行續相互access產生的錯誤
            Thi = new Thread(Listen);//建立監聽執行續執行方法
            Thi.Start();//啟動執行續
            button1.Enabled = false;//防止重複點擊
        }
        //定義方法FindhostIP查找ip
        private string FindhostIP()
        {
            string hostIP = "";
            string hostName = Dns.GetHostName();//得到主機名稱
            //得到主機ip位置清單
            IPAddress[] iPs = Dns.GetHostEntry(hostName).AddressList;
            //使用foreach迴圈--比對是否有IPV4,如果有就回傳IPv4字串
            foreach (IPAddress x in iPs)
            {
                if (x.AddressFamily == AddressFamily.InterNetwork)
                {
                    hostIP = x.ToString();//取得IPv4字串
                    return (hostIP);//傳回本機IPv4字串
                }
            }
            //如果沒有找到IPv4就傳回空字串
            return ("");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //呼叫 FindhostIP方法找到本機ip
            this.Text = "IP:" + FindhostIP();
        }
        //自訂義監聽方法接收並處理UDP傳輸進來的資料
        private void Listen()
        {
            int portNum = int.Parse(textBox1.Text);//將port(textBox1)的文字轉為整數
            U = new UdpClient(portNum);//建立UDP連線服務物件
            int EP_portNum = int.Parse(textBox4.Text);//將port(textBox4)的文字轉為整數
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse(textBox3.Text), EP_portNum);
            //使用迴圈處理接收資料
            while(true)
            { 
            byte[] byteArrray = U.Receive(ref EP);//接收遠端資料
            textBox2.Text = Encoding.Default.GetString(byteArrray);//將byte轉為字串
            }
        }

    }
}
