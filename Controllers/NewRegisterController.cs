using MVC_WPF.Data.Database;
using MVC_WPF.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WPF.Controllers
{
    public class NewRegisterController
    {
        public bool NewRegisterUser(string login, string password)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@Username", login),
                new MySqlParameter("@Password", PasswordHelper.Hash(password))
            };

            var result = DBConnection.Instance.ExecuteNonQuery(Data.SQL.RegisterUser.NewRegisterUserQueries.NewRegisterUser, parameters);

            return false;
        }
    }
}
