using MVC_WPF.Data.Database;
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
            // Можно сразу хэшировать пароль
            string passwordHash = Hash(password);

            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@Username", login),
                new MySqlParameter("@Password", passwordHash)
            };

            var result = DBConnection.Instance.ExecuteQuery(Data.SQL.AuthUser.AuthUserQueries.ValidateUser, parameters);

            return result.Rows.Count > 0;
        }

        private string Hash(string password)
        {
            byte[] temp = Encoding.UTF8.GetBytes(password);
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(temp);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
