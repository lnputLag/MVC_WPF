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
    }
}
