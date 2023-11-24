using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Client_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private unsafe void btn_hello_Click(object sender, RoutedEventArgs e)
        {
            txb_hello.Text = "Hello World";
            ThreadPool.QueueUserWorkItem((state) =>
            {
                Thread.Sleep(1000);
                Dispatcher.Invoke(() => txb_hello.Text = string.Empty);
            });
            
        }
    }
}
