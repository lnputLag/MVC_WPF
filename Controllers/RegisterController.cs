using MVC_WPF.Data.Database;
using MVC_WPF.Helpers;
using MySql.Data.MySqlClient;
using System;

namespace MVC_WPF.Controllers
{
    public class RegisterController
    {
        ///<summary>
        /// Проверяем существует ли пользователь
        ///</summary>
        
        public bool UserExists(string login)
        {
            MySqlParameter[] checkParams = 
                { 
                new MySqlParameter("@Username", login)
            };

            object result = DBConnection.Instance.ExecuteScalar(
                Data.SQL.RegisterUser.RegisterUserQueries.RegisterUser, checkParams);

            // ExecuteScalar вернет количество (COUNT(*))
            int count = Convert.ToInt32(result);
            return count > 0; //true если пользователь существует
        }

        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>

        public bool NewRegisterUser(string login, string password)
        {
            // Если пользователь уже есть — не добавляем
            if (UserExists(login))
                return false;

            MySqlParameter[] parameters =
{
                new MySqlParameter("@Username", login),
                new MySqlParameter("@Password", PasswordHelper.Hash(password))
            };

            int result = DBConnection.Instance.ExecuteNonQuery(
                Data.SQL.RegisterUser.NewRegisterUserQueries.NewRegisterUser, parameters);

            return result > 0; // true если регистрация прошла успешно
        }
    }
}
