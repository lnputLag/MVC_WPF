using MVC_WPF.Data.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WPF.Controllers
{
    public class RegisterController
    {
        ///<summary>
        /// Проверяем существует ли пользователь
        ///</summary>
        
        public bool RegisterUsers(string login)
        {
            MySqlParameter[] checkParams = { new MySqlParameter("@Username", login)};

            var result = DBConnection.Instance.ExecuteScalar(Data.SQL.RegisterUser.RegisterUserQueries.RegisterUser, checkParams);

            return false; // Ранний выход, если пользователь существует
        }
    }
}
