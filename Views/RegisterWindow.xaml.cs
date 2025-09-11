using MVC_WPF.Controllers;
using MVC_WPF.Data.Database;
using MVC_WPF.Helpers;
using System;
using System.ComponentModel;
using System.Windows;


namespace MVC_WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            DBConnection.Instance.Init();
        }

        private bool _isNavigation = false;

        private void Register_Window_Closing(object sender, CancelEventArgs e)
        {
            WindowCloseHelper.ConfirmClose(this, e, _isNavigation);
        }

        private void Reg_Button_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();

            RegisterController controller = new RegisterController();

            if (controller.NewRegisterUser(login, pass))
            {
                MessageBox.Show("Пользователь успешно зарегистрирован!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь с таким логином уже существует!");
            }
        }
    }
}
