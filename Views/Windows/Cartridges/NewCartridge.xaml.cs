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
using System.Linq;

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

        private CartridgeBase _editingCartridge = null;
        private CartridgeFactory _factory = new CartridgeFactory();

        /// <summary>
        /// Загрузка всех ComboBox значениями из БД
        /// </summary>
        public void LoadComboBoxes()
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

        /// <summary>
        /// Инициализация формы для редактирования существующего картриджа
        /// </summary>
        /// <param name="cartridge">Картридж для редактирования</param>
        public void LoadCartridgeForEditing(CartridgeBase cartridge)
        {
            if (cartridge == null) return;

            _editingCartridge = cartridge;

            // Устанавливаем выбранные элементы в ComboBox
            ModelComboBox.SelectedItem = ModelComboBox.Items
                .Cast<CartridgeModel>()
                .FirstOrDefault(m => m.Id == cartridge.ModelId);

            TypeComboBox.SelectedItem = TypeComboBox.Items
                .Cast<CartridgeType>()
                .FirstOrDefault(t => t.Id == cartridge.TypeId);

            StatusComboBox.SelectedItem = StatusComboBox.Items
                .Cast<CartridgeStatus>()
                .FirstOrDefault(s => s.Id == cartridge.Status.Id);

            SupplierComboBox.SelectedItem = SupplierComboBox.Items
                .Cast<Supplier>()
                .FirstOrDefault(sup => sup.Id == cartridge.Supplier.Id);

            // Заполняем количество
            WorkNameTextBox1.Text = cartridge.Quantity.ToString();

            // Меняем текст кнопки на "Сохранить изменения"
            SaveButton.Content = "Сохранить изменения";
        }

        /// <summary>
        /// Кнопка сохранения
        /// </summary>
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




                var controller = new CartridgeController();
                bool success = false;

                if (_editingCartridge != null)
                {
                    // Обновляем существующий картридж
                    _editingCartridge.ModelId = selectedModel.Id;
                    _editingCartridge.TypeId = selectedType.Id;
                    _editingCartridge.ModelName = selectedModel.ModelName;
                    _editingCartridge.TypeName = selectedType.TypeName;
                    _editingCartridge.Status = selectedStatus;
                    _editingCartridge.Supplier = selectedSupplier;
                    _editingCartridge.Quantity = quantity;

                    success = controller.UpdateCartridges(_editingCartridge);
                }
                else
                {
                    // Создаём новый картридж через фабрику
                    CartridgeBase newCartridge = null;
                    switch (selectedType.TypeName)
                    {
                        case "BW":
                            newCartridge = new BWCartridge();
                            break;
                        case "Color":
                            newCartridge = new ColorCartridge();
                            break;
                        case "RICOH":
                            newCartridge = new RicohCartridge();
                            break;
                        default:
                            MessageBox.Show("Неизвестный тип картриджа!");
                            return;
                    }

                    newCartridge.ModelId = selectedModel.Id;
                    newCartridge.TypeId = selectedType.Id;
                    newCartridge.ModelName = selectedModel.ModelName;
                    newCartridge.TypeName = selectedType.TypeName;
                    newCartridge.Status = selectedStatus;
                    newCartridge.Supplier = selectedSupplier;
                    newCartridge.Quantity = quantity;

                    success = controller.AddCartridge(newCartridge);
                }

                if (success)
                {
                    MessageBox.Show(_editingCartridge != null ? "Картридж обновлён!" : "Картридж добавлен!");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка при сохранении картриджа.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
