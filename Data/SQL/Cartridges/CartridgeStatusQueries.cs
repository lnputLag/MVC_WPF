using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WPF.Data.SQL.Cartridges
{
    /// <summary>
    /// Получение списка всех статусов
    /// </summary>
    public static class CartridgeStatusQueries
    {
        public const string GetStatuses = @"
            SELECT status_id, status_name 
            FROM cartridge_status";
    }
}
