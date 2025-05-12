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
using Modern.ViewModel;

namespace Modern.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            
            
        }

        private void Butonclose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Butonminimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void DeschidereAdaugareAdmin(object sender, RoutedEventArgs e)
        {
            AdaugareAdmin saba= new AdaugareAdmin();
            saba.ShowDialog();
        }
    }
}
