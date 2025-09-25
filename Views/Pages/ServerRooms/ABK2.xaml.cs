using MVC_WPF.Controllers;
using MVC_WPF.Views.Windows;
using MySqlX.XDevAPI.Common;
using System;
using System.Data;
using System.Windows.Controls;


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
            LoadCartridges();
        }

        private void LoadCartridges()
        {
            var controller = new CartridgeController();
            ClientsGrid.ItemsSource = controller.GetCartridges();
        }

        private void New_Cartridge_Btn(object sender, System.Windows.RoutedEventArgs e)
        {
            var newCartridge = new Windows.NewCartridge();
            bool? result = newCartridge.ShowDialog();

            // если картридж успешно добавлен, обновляем список
            if (result == true)
            {
                LoadCartridges();
            }
        }
    }
}
