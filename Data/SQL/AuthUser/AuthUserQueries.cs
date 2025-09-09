using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WPF.Data.SQL.AuthUser
{
    public static class AuthUserQueries
    {
        public const string ValidateUser = @"
            SELECT * 
            FROM users 
            WHERE Username = @Username
            AND Password = @Password";
    }
}
