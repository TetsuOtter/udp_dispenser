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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace udp_dispenser
{
    /// <summary>
    /// datawindow.xaml の相互作用ロジック
    /// </summary>
    public partial class datawindow : Window
    {
        public datawindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (MainWindow.communicationstatus == true)
            {
                Byte[] data = MainWindow.data;
                if (data != null)
                {
                    databox.Text = BitConverter.ToString(data);
                }
                else
                {
                    databox.Text = "There are no data.";
                }
            }
            else
            {
                databox.Text = "The connect has not started yet.";
            }

        }
    }
}
