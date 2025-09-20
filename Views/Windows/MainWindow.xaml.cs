using MVC_WPF.Helpers;
using MVC_WPF.Views.Pages;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;


namespace MVC_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Создание флага для определния типа закрытия
        private bool _isNavigation = false;

        private void Main_Window_Closing(object sender, CancelEventArgs e)
        {
            WindowCloseHelper.ConfirmClose(this, e, _isNavigation);
        }

        private void AddTab(Page page, string title)
        {
            // Проверяем, существует ли уже вкладка с таким заголовком
            foreach (TabItem item in MainTabControl.Items)
            {
                if (item.Tag?.ToString() == title)
                {
                    MainTabControl.SelectedItem = item; // просто активируем её
                    return;
                }
            }

            // Создаём контейнер с кнопкой закрытия
            DockPanel headerPanel = new DockPanel { LastChildFill = false };
            TextBlock headerText = new TextBlock { Text = title, Margin = new Thickness(0, 0, 5, 0) };

            Button closeButton = new Button
            {
                Content = "✕",
                Width = 18,
                Height = 18,
                Padding = new Thickness(0),
                Margin = new Thickness(2, 0, 0, 0)
            };

            // Создаём сам TabItem
            TabItem tabItem = new TabItem
            {
                Tag = title, // чтобы потом найти по имени
                Content = new Frame
                {
                    NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden,
                    Content = page
                }
            };

            // Кнопка закрытия вкладки
            closeButton.Click += (s, e) => MainTabControl.Items.Remove(tabItem);

            headerPanel.Children.Add(headerText);
            headerPanel.Children.Add(closeButton);
            tabItem.Header = headerPanel;

            // Добавляем вкладку и активируем её
            MainTabControl.Items.Add(tabItem);
            MainTabControl.SelectedItem = tabItem;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddTab(new ABK2(), "ABK2");
        }
    }
}
