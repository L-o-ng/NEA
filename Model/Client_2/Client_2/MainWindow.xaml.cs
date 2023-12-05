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
            DataContext = new MainViewModel(20, 20);
            (DataContext as MainViewModel)?.Initialize();
        }

        private void btn_drawMaze_Click(object sender, RoutedEventArgs e) {
            
            
            
        }
    }
}
