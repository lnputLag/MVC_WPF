using MVC_WPF.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MVC_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Создание флага для определния типа закрытия
        private bool _isNavigation = false;

        private void Main_Window_Closing(object sender, CancelEventArgs e)
        {
            WindowCloseHelper.ConfirmClose(this, e, _isNavigation);
        }

        private void Radmin_Item_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
