using System;
using System.ComponentModel;
using System.Windows;

namespace MVC_WPF.Helpers
{
    public static class WindowCloseHelper
    {
        /// <summary>
        /// Основной метод для закртия окон
        /// </summary>
        public static void ConfirmClose(Window window, CancelEventArgs e, bool isNavigation)
        {
            if (isNavigation) return;

            if (window.OwnedWindows.Count > 0)
                return;

            MessageBoxResult result = MessageBox.Show(
                "Вы уверены, что хотите выйти?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            e.Cancel = (result == MessageBoxResult.No);
        }

        /// <summary>
        /// Метод для закрытия окна регистрации
        /// </summary>
        public static void CloseRegistration(Window window, CancelEventArgs e, bool _isRegistrationSuccess)
        {
            if (_isRegistrationSuccess) return;

            if (window.OwnedWindows.Count > 0)
                return;

            MessageBoxResult result = MessageBox.Show(
                "Вы уверены, что хотите выйти?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
