using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MVC_WPF.Helpers
{
    public static class FormHelper
    {
        /// <summary>
        /// Сброс ComboBox и TextBox в переданных элементах
        /// </summary>
        public static void ClearForm(
            ComboBox modelComboBox,
            ComboBox typeComboBox,
            ComboBox statusComboBox,
            ComboBox supplierComboBox,
            TextBox workNameTextBox,
            Button saveButton)
        {
            // Сбрасываем выбранные элементы ComboBox
            if (modelComboBox != null) modelComboBox.SelectedIndex = -1;
            if (typeComboBox != null) typeComboBox.SelectedIndex = -1;
            if (statusComboBox != null) statusComboBox.SelectedIndex = -1;
            if (supplierComboBox != null) supplierComboBox.SelectedIndex = -1;

            // Очищаем текстовое поле
            if (workNameTextBox != null) workNameTextBox.Text = string.Empty;

            // Возвращаем текст кнопки "Сохранить" к исходному состоянию
            if (saveButton != null) saveButton.Content = "Сохранить";
        }
    }
}
