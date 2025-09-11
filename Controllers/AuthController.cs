using MVC_WPF.Data.Database;
using MVC_WPF.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WPF.Controllers
{
    public class AuthController
    {
        /// <summary>
        /// Проверка логина и пароля
        /// </summary>
        public bool ValidateUser(string login, string password)
        {

            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@Username", login),
                new MySqlParameter("@Password", PasswordHelper.Hash(password))
            };

            var result = DBConnection.Instance.ExecuteQuery(Data.SQL.AuthUser.AuthUserQueries.ValidateUser, parameters);

            return result.Rows.Count > 0;
        }

    }
}
