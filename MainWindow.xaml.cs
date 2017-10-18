using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Windows.Forms;
using System.Windows.Threading;

namespace udp_dispenser
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        static public bool communicationstatus = false;
        bool udp1 = false;
        bool udp2 = false;
        bool udp3 = false;
        bool udp4 = false;
        bool udp5 = false;
        string udp1_ip;
        string udp1_port;
        string udp2_ip;
        string udp2_port;
        string udp3_ip;
        string udp3_port;
        string udp4_ip;
        string udp4_port;
        string udp5_ip;
        string udp5_port;
        static public Byte[] data;
        public MainWindow()
        {
            InitializeComponent();
            string myhostname = Dns.GetHostName();
            IPAddress[] address = Dns.GetHostAddresses(myhostname);
            foreach(IPAddress addrs in address)
            {
                if (addrs.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    myIPAddr.Text = addrs.ToString();
                    break;
                }
            }
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (communicationstatus == true)
            {
                data = udp_get.GetV();
                if (udp1 == true)
                {
                    udp_get.udpsender(udp1_ip, udp1_port, data);
                }
                if (udp2 == true)
                {
                    udp_get.udpsender(udp2_ip, udp2_port, data);
                }
                if (udp3 == true)
                {
                    udp_get.udpsender(udp3_ip, udp3_port, data);
                }
                if (udp4 == true)
                {
                    udp_get.udpsender(udp4_ip, udp4_port, data);
                }
                if (udp5 == true)
                {
                    udp_get.udpsender(udp5_ip, udp5_port, data);
                }
            }

        }

        private void udp_start(object sender, RoutedEventArgs e)
        {
            if (tf1.IsChecked == true)
            {
                udp1_ip = ip1.Text;
                udp1_port = port1.Text;
                udp1 = true;
                udp1_Tooi.Width = 380;
            }
            else
            {
                udp1_Fooi.Width = 380;
            }
            if (tf2.IsChecked == true)
            {
                udp2_ip = ip2.Text;
                udp2_port = port2.Text;
                udp2 = true;
                udp2_Tooi.Width = 380;
            }
            else
            {
                udp2_Fooi.Width = 380;
            }
            if (tf3.IsChecked == true)
            {
                udp3_ip = ip3.Text;
                udp3_port = port3.Text;
                udp3 = true;
                udp3_Tooi.Width = 380;
            }
            else
            {
                udp3_Fooi.Width = 380;
            }
            if (tf4.IsChecked == true)
            {
                udp4_ip = ip4.Text;
                udp4_port = port4.Text;
                udp4 = true;
                udp4_Tooi.Width = 380;
            }
            else
            {
                udp4_Fooi.Width = 380;
            }
            if (tf5.IsChecked == true)
            {
                udp5_ip = ip5.Text;
                udp5_port = port5.Text;
                udp5 = true;
                udp5_Tooi.Width = 380;
            }
            else
            {
                udp5_Fooi.Width = 380;
            }
            communicationstatus = true;
            //udp communication start
        }

        private void udp_stop(object sender, RoutedEventArgs e)
        {
            udp1 = false;
            udp2 = false;
            udp3 = false;
            udp4 = false;
            udp5 = false;
            udp1_Fooi.Width = 0;
            udp2_Fooi.Width = 0;
            udp3_Fooi.Width = 0;
            udp4_Fooi.Width = 0;
            udp5_Fooi.Width = 0;
            udp1_Tooi.Width = 0;
            udp2_Tooi.Width = 0;
            udp3_Tooi.Width = 0;
            udp4_Tooi.Width = 0;
            udp5_Tooi.Width = 0;
            communicationstatus = false;
            //udp communication stop
        }

        private void datawindow_show(object sender, RoutedEventArgs e)
        {
            datawindow dwin = new datawindow();
            dwin.Show();
        }
    }
}
