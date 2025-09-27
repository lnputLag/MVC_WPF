using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WPF.Data.SQL.Cartridges
{
    /// <summary>
    /// Получение списка всех типов картриджей
    /// </summary>
    public static class CartridgeTypesQueries
    {
        public const string GetTypes = @"
            SELECT type_id, type_name 
            FROM cartridge_types";
    }
}
