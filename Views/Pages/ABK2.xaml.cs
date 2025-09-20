using System.Windows.Controls;
using System;
using MVC_WPF.Views.Windows;


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
            NewCartridge newCartridge = new NewCartridge();
            newCartridge.Show();
        }
    }
}
