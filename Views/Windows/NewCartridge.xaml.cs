using System.Windows;
using MVC_WPF.Controllers;
using System;
using System.Data;
using MVC_WPF.Data.Database;

namespace MVC_WPF.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для NewCartridge.xaml
    /// </summary>
    public partial class NewCartridge : Window
    {
        private DataTable _statuses;
        public NewCartridge()
        {
            InitializeComponent();

        }

        

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void StatusComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
