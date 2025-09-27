using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WPF.Data.SQL.Cartridges
{
    /// <summary>
    /// Получение полной информации о картридже
    /// полученной из нескольких таблиц
    /// </summary>
    public static class CartridgeQueries
    {
        public const string GetCartridges = @"
            SELECT c.cartridge_id,
            m.model_name,
            c.quantity,
            t.type_name,
            s.status_name,
            sup.supplier_name
            FROM cartridges c
            JOIN cartridge_models m ON c.model_id = m.model_id
            JOIN cartridge_types t ON c.type_id = t.type_id
            JOIN cartridge_status s ON c.status_id = s.status_id
            JOIN suppliers sup ON c.supplier_id = sup.supplier_id";
    }
}
