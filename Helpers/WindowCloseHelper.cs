using System;
using System.ComponentModel;
using System.Windows;

namespace MVC_WPF.Helpers
{
    public static class WindowCloseHelper
    {
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
                // Полный выход из приложения
                Application.Current.Shutdown();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
