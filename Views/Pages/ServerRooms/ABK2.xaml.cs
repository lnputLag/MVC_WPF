using MVC_WPF.Controllers;
using MVC_WPF.Helpers;
using MVC_WPF.Models;
using MVC_WPF.Models.Cartridges;
using MVC_WPF.Views.Windows;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Controls;


namespace MVC_WPF.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ABK2.xaml
    /// </summary>
    public partial class ABK2 : Page
    {
        private List<CartridgeBase> _allCartridges = new List<CartridgeBase>();

        public ABK2()
        {
            InitializeComponent();
            LoadCartridges();
            LoadStatusFilter();
        }

        /// <summary>
        /// Загрузка картриджей
        /// </summary>
        private void LoadCartridges()
        {
            var controller = new CartridgeController();
            _allCartridges = controller.GetCartridges();
            ListCartridges.ItemsSource = _allCartridges;
        }

        /// <summary>
        /// Загрузка фильтра статусов
        /// </summary>
        private void LoadStatusFilter()
        {
            var controller = new CartridgeController();
            var statuses = controller.GetStatuses();

            statuses.Insert(0, new CartridgeStatus { Id = 0, StatusName = "Все" });

            StatusFilterComboBox.ItemsSource = statuses;
            StatusFilterComboBox.DisplayMemberPath = "StatusName";
            StatusFilterComboBox.SelectedValuePath = "Id";
            StatusFilterComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Применение фильтра по статусу
        /// </summary>
        private void ApplyStatusFilter()
        {
            if (_allCartridges == null) return;

            var selectedStatus = StatusFilterComboBox.SelectedItem as CartridgeStatus;
            if (selectedStatus == null || selectedStatus.Id == 0)
            {
                ListCartridges.ItemsSource = _allCartridges;
            }
            else
            {
                ListCartridges.ItemsSource = _allCartridges
                    .Where(c => c.Status != null && c.Status.Id == selectedStatus.Id)
                    .ToList();
            }
        }

        /// <summary>
        /// Обработчик изменения выбранного статуса
        /// </summary>
        private void StatusFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyStatusFilter();
        }

        private void New_Cartridge_Btn(object sender, System.Windows.RoutedEventArgs e)
        {
            var newCartridge = new Windows.NewCartridge();
            bool? result = newCartridge.ShowDialog();

            if (result == true)
            {
                LoadCartridges();
            }
        }

        /// <summary>
        /// Редактирование
        /// </summary>
        private void EditCartridge_Btn(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ListCartridges.SelectedItem is CartridgeBase selectedCartridge)
            {
                var editWindow = new NewCartridge();
                editWindow.LoadComboBoxes(); 
                editWindow.LoadCartridgeForEditing(selectedCartridge); 
                bool? result = editWindow.ShowDialog();
                if (result == true)
                {
                    LoadCartridges(); 
                }
            }
            else
            {
                MessageBox.Show("Выберите картридж для редактирования.");
            }
        }

        /// <summary>
        /// Удаление
        /// </summary>
        private void DeleteCartridge_Btn(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ListCartridges.SelectedItem is CartridgeBase selectedCartridge)
            {
                CartridgeHelper.ConfirmDeleteCartridge(selectedCartridge, LoadCartridges);
            }
            else
            {
                MessageBox.Show("Выберите картридж для удаления");
            }
        }
    }
}
