using MVC_WPF.Controllers;
using MVC_WPF.Data.Database;
using MVC_WPF.Data.SQL.RegisterUser;
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
            this.Closing += Register_Window_Closing;
        }

        private bool _isRegistrationSuccess = false;

        private void Register_Window_Closing(object sender, CancelEventArgs e)
        {
            WindowCloseHelper.CloseRegistration(this, e, _isRegistrationSuccess);
        }

        private void Reg_Button_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass_2 = passBox_2.Password.Trim();

            RegisterController controller = new RegisterController();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Логин и пароль обязательны для заполнения!");
                return;
            }
            else if (login.Length <= 3)
            {
                MessageBox.Show("Введите логин длинной больше трёх символов");
            }
            else if (pass.Length <= 4)
            {
                MessageBox.Show("Введите пароль более четырёх символов");
            }
            else if (pass != pass_2)
            {
                MessageBox.Show("Пароли не совпадают!");
            }
            else 
            {
                try
                {
                    if (controller.UserExists(login))
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует!");
                        return;
                    }

                    if (controller.NewRegisterUser(login, pass))
                    {
                        MessageBox.Show("Регистрация успешна!");
                        _isRegistrationSuccess = true;
                        this.Owner?.Show(); // показываем окно авторизации
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при регистрации пользователя!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}
