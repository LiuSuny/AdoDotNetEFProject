
using System.Windows;


namespace AdoDotNetEFProject.WPF.Windows.MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.Resources.Add("Owner", this);
        }
    }
}