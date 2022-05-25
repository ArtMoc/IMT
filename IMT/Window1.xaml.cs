using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IMT
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        bool CanClose = false;
        public Window1()
        {
            InitializeComponent();
            Thread thread = new Thread(CloseTimer);
            thread.Start();
        }
        void CloseTimer()
        {
            for(int i = 7; i>0; i--)
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    TimerLabel.Content = i.ToString();
                }));
                Thread.Sleep(1000);
            }
            CanClose = true;
            Dispatcher.Invoke(new Action(() =>
            {
                Form.WindowStyle = WindowStyle.ToolWindow;
            }));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(!CanClose)
            {
                e.Cancel = true;
            }
        }
    }
}
