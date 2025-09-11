using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WPF.Data.SQL.RegisterUser
{
    public static class NewRegisterUserQueries
    {
        public const string NewRegisterUser = @"
        INSERT INTO Users (Username, Password) 
        VALUES (@Username, @Password)";
    }
}
