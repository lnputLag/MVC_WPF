using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WPF.Data.SQL.RegisterUser
{
    /// <summary>
    /// Запрос для проверки на существование пользователя 
    /// с таким же именем (логином)
    /// </summary>
    public static class RegisterUserQueries
    {
        public const string RegisterUser = @"
        SELECT COUNT(*) 
        FROM Users 
        WHERE Username = @Username";
    }
}
