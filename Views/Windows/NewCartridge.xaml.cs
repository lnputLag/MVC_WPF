using System.Windows;
using System.Data;
using System;
using MVC_WPF.Controllers;
using MVC_WPF.Data.Database;
using MVC_WPF.Models;

namespace MVC_WPF.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для NewCartridge.xaml
    /// </summary>
    public partial class NewCartridge : Window
    {
        public NewCartridge()
        {
            InitializeComponent();
            LoadComboBoxes();
        }

        

        private void LoadComboBoxes()
        {
            var controller = new CartridgeController();

            // Модели
            ModelComboBox.ItemsSource = controller.GetModels();
            ModelComboBox.DisplayMemberPath = "ModelName";
            ModelComboBox.SelectedValuePath = "Id";

            // Типы
            TypeComboBox.ItemsSource = controller.GetTypes();
            TypeComboBox.DisplayMemberPath = "TypeName";
            TypeComboBox.SelectedValuePath = "Id";

            // Статусы
            StatusComboBox.ItemsSource = controller.GetStatuses();
            StatusComboBox.DisplayMemberPath = "StatusName";
            StatusComboBox.SelectedValuePath = "Id";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string quantityText = WorkNameTextBox1.Text.Trim();

                if (string.IsNullOrEmpty(quantityText))
                {
                    MessageBox.Show("Укажите количество!");
                    return;
                }

                if (!int.TryParse(quantityText, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Количество должно быть положительным числом!");
                    return;
                }

                // Проверка, что выбраны модель, тип и статус
                if (ModelComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Выберите модель картриджа!");
                    return;
                }

                if (TypeComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Выберите тип картриджа!");
                    return;
                }

                if (StatusComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Выберите статус картриджа!");
                    return;
                }

                int modelId = Convert.ToInt32(ModelComboBox.SelectedValue);
                int typeId = Convert.ToInt32(TypeComboBox.SelectedValue);
                int statusId = Convert.ToInt32(StatusComboBox.SelectedValue);

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
    }
}
