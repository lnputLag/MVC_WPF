using MVC_WPF.Controllers;
using MVC_WPF.Models.Cartridges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVC_WPF.Helpers
{
    public static class CartridgeHelper
    {
        /// <summary>
        /// Метод для удаления картриджа
        /// </summary>
        /// <param name="selectedCartridge"></param>
        /// <param name="reloadAction">обновляем таблицу (передаём метод как параметр)</param>
        public static void ConfirmDeleteCartridge(CartridgeBase selectedCartridge, System.Action reloadAction)
        {
            var result = MessageBox.Show(
                $"Вы уверены, что хотите удалить картридж {selectedCartridge.ModelName}?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                var controller = new CartridgeController();
                if (controller.DeleteCartridge(selectedCartridge.Id))
                {
                    MessageBox.Show("Картридж удалён");
                    reloadAction?.Invoke(); 
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении картриджа");
                }
            }
        }
    }
}
