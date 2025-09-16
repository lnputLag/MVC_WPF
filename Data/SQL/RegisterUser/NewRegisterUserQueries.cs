using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WPF.Data.SQL.RegisterUser
{
    /// <summary>
    /// Запрос на регистрацию пользователей
    /// Предназначен для добавления новых пользователей в базу данных
    /// в таблицу Users
    /// </summary>
    public static class NewRegisterUserQueries
    {
        public const string NewRegisterUser = @"
        INSERT INTO Users (Username, Password) 
        VALUES (@Username, @Password)";
    }
}
