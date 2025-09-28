using MVC_WPF.Controllers;
using MVC_WPF.Models.Cartridges;
using MVC_WPF.Views.Windows;
using MySqlX.XDevAPI.Common;
using System;
using System.Data;
using System.Windows;
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
            var cartridges = controller.GetCartridges();
            ListCartridges.ItemsSource = cartridges;
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

        private void EditCartridge_Btn(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ListCartridges.SelectedItem is CartridgeBase selectedCartridge)
            {
                var editWindow = new NewCartridge();
                editWindow.LoadComboBoxes(); // сначала загружаем все ComboBox
                editWindow.LoadCartridgeForEditing(selectedCartridge); // затем заполняем данные
                bool? result = editWindow.ShowDialog();
                if (result == true)
                {
                    LoadCartridges(); // обновляем таблицу
                }
                else
                {
                    MessageBox.Show("Выберите картридж для редактирования.");
                }
            }
        }

        private void DeleteCartridge_Btn(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ListCartridges.SelectedItem is CartridgeBase selectedCartridge)
            {
                var result = MessageBox.Show(
                    $"Вы уверена, что хотите удалить картридж {selectedCartridge.ModelName}?",
                    "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    var controller = new CartridgeController();
                    if (controller.DeleteCartridge(selectedCartridge.Id))
                    {
                        MessageBox.Show("Картридж удалён");
                        LoadCartridges(); // обновляем таблицу
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при удалении картриджа");
                    }
                }
            }
        }
    }
}
