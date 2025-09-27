using MVC_WPF.Controllers;
using MVC_WPF.Data.Database;
using MVC_WPF.Helpers;
using MVC_WPF.Models;
using System;
using System.ComponentModel;
using System.Windows;
using MVC_WPF.Models.Cartridges;
using MVC_WPF.Models.Cartridges.Business;
using MVC_WPF.Models.Suppliers;
using MVC_WPF.Models.Factories;

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

        private CartridgeFactory _factory = new CartridgeFactory();

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

            // Поставщики
            SupplierComboBox.ItemsSource = controller.GetSuppliers();
            SupplierComboBox.DisplayMemberPath = "Name";
            SupplierComboBox.SelectedValuePath = "Id";

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

                if (ModelComboBox.SelectedItem == null ||
                    TypeComboBox.SelectedItem == null ||
                    StatusComboBox.SelectedItem == null ||
                    SupplierComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Выберите модель, тип, статус и поставщика картриджа!");
                    return;
                }

                // Получаем данные с формы
                var selectedModel = ModelComboBox.SelectedItem as CartridgeModel;
                var selectedType = TypeComboBox.SelectedItem as CartridgeType;
                var selectedStatus = StatusComboBox.SelectedItem as CartridgeStatus;
                var selectedSupplier = SupplierComboBox.SelectedItem as Supplier;

                // Создаём объект картриджа через фабрику
                CartridgeBase newCartridge = null;
                string typeName = selectedType.TypeName;

                if (typeName == "BW")
                    newCartridge = new BWCartridge
                    {
                        ModelId = selectedModel.Id,
                        TypeId = selectedType.Id,
                        ModelName = selectedModel.ModelName,
                        TypeName = typeName,
                        Supplier = selectedSupplier,
                        Status = selectedStatus,
                        Quantity = quantity
                    };
                else if (typeName == "Color")
                    newCartridge = new ColorCartridge
                    {
                        ModelId = selectedModel.Id,
                        TypeId = selectedType.Id,
                        ModelName = selectedModel.ModelName,
                        TypeName = typeName,
                        Supplier = selectedSupplier,
                        Status = selectedStatus,
                        Quantity = quantity
                    };
                else if (typeName == "RICOH")
                    newCartridge = new RicohCartridge
                    {
                        ModelId = selectedModel.Id,
                        TypeId = selectedType.Id,
                        ModelName = selectedModel.ModelName,
                        TypeName = typeName,
                        Supplier = selectedSupplier,
                        Status = selectedStatus,
                        Quantity = quantity
                    };
                else
                {
                    MessageBox.Show("Неизвестный тип картриджа!");
                    return;
                }

                // Сохраняем через контроллер
                var controller = new CartridgeController();
                bool success = controller.AddCartridge(newCartridge);

                if (success)
                {
                    //Вызов бизнес-логики
                    newCartridge.Refill();

                    MessageBox.Show("Картридж успешно добавлен!");
                    this.DialogResult = true;
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
