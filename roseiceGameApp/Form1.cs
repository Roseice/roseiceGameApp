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
        UdpClient U;
        Thread THI;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        //定義方法FindhostIP查找ip
        private string FindhostIP()
        {
            string hostIP = "";
            string hostName = Dns.GetHostName();//得到主機名稱
            //得到主機ip位置清單
            IPAddress[]iPs= Dns.GetHostEntry(hostName).AddressList;
            //使用foreach迴圈--比對是否有IPV4,如果有就回傳IPv4字串
            foreach(IPAddress x in iPs)
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
    }
}
