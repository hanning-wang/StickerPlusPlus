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
using System.Windows.Threading;

namespace Sticker__.Views
{
    /// <summary>
    /// Home.xaml 的交互逻辑
    /// </summary>
    public partial class Home : Page
    {
        private DispatcherTimer ShowTimer;
        public Home()
        {
            InitializeComponent();
            ShowTime();
            ShowTimer = new System.Windows.Threading.DispatcherTimer();
            ShowTimer.Tick += new EventHandler(ShowCurTimer);
            ShowTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            ShowTimer.Start();
        }
        public void ShowCurTimer(object sender, EventArgs e)
        {
            ShowTime();
        }
        private void ShowTime()
        {
            this.tbDateText.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.tbTimeText.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
