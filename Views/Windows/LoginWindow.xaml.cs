using MVC_WPF.Controllers;
using MVC_WPF.Data.Database;
using MVC_WPF.Helpers;
using System;
using System.ComponentModel;
using System.Windows;


namespace MVC_WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DBConnection.Instance.Init(); // вызываем Init через Singleton
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Логин и пароль обязательны для заполнения!");
                return;
            }
            if (login.Length <= 3)
            {
                MessageBox.Show("Введите логин длинной больше трёх символов");
                return;
            }
            if (pass.Length <= 4)
            {
                MessageBox.Show("Введите пароль более четырёх символов");
                return;
            }

            try
            {
                var authController = new AuthController();
                if (authController.ValidateUser(login, pass))
                {
                    MessageBox.Show("Авторизация успешна!");
                    _isNavigation = true;
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Owner = this;
            registerWindow.Show();
        }

        //Создание флага для определния типа закрытия
        private bool _isNavigation = false;

        private void Login_Window_Closing(object sender, CancelEventArgs e)
        {
            WindowCloseHelper.ConfirmClose(this, e, _isNavigation);
        }
    }
}
