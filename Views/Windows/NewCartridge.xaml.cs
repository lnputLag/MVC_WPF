using System.Windows;
using System.Data;
using System;
using MVC_WPF.Controllers;
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
            LoadTypes();
            LoadStatuses();
        }

        private void LoadTypes()
        {
            string query = "SELECT type_id, type_name FROM cartridge_types";
            DataTable dt = DBConnection.Instance.ExecuteQuery(query);
            TypeComboBox.ItemsSource = dt.DefaultView;
            TypeComboBox.DisplayMemberPath = "type_name";
            TypeComboBox.SelectedValuePath = "type_id";
        }

        private void LoadStatuses()
        {
            string query = "SELECT status_id, status_name FROM cartridge_status";
            DataTable dt = DBConnection.Instance.ExecuteQuery(query);
            StatusComboBox.ItemsSource = dt.DefaultView;
            StatusComboBox.DisplayMemberPath = "status_name";
            StatusComboBox.SelectedValuePath = "status_id";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Читаем значения
                string modelName = WorkNameTextBox.Text.Trim();
                string quantityText = WorkNameTextBox1.Text.Trim();

                if (string.IsNullOrEmpty(modelName) || string.IsNullOrEmpty(quantityText))
                {
                    MessageBox.Show("Заполните все поля!");
                    return;
                }

                if (!int.TryParse(quantityText, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Количество должно быть положительным числом!");
                    return;
                }

                if (TypeComboBox.SelectedValue == null || StatusComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Выберите тип и статус картриджа!");
                    return;
                }

                int typeId = Convert.ToInt32(TypeComboBox.SelectedValue);
                int statusId = Convert.ToInt32(StatusComboBox.SelectedValue);

                // ⚡ На данный момент модель мы не сохраняем в отдельной таблице cartridge_models
                // Для теста можно сделать так:
                int modelId = 1; // временно хардкод, потом сделаем добавление модели в таблицу cartridge_models

                var controller = new CartridgeController();
                bool success = controller.AddCartridge(modelId, typeId, statusId, quantity);

                if (success)
                {
                    MessageBox.Show("Картридж успешно добавлен!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка при добавлении картриджа.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void StatusComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
