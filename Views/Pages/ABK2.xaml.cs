using System.Windows.Controls;
using System;
using MVC_WPF.Views.Windows;
using System.Data;
using MVC_WPF.Controllers;


namespace MVC_WPF.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ABK2.xaml
    /// </summary>
    public partial class ABK2 : Page
    {
        public ABK2()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var newCartridge = new Windows.NewCartridge();
            newCartridge.ShowDialog();
        }
    }
}
