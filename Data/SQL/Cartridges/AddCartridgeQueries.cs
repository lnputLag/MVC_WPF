using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WPF.Data.SQL.Cartridges
{
    /// <summary>
    /// Добавление картриджей
    /// </summary>
    public static class AddCartridgeQueries
    {
        public const string InsertCartridge = @"
            INSERT INTO cartridges (model_id, type_id, status_id, supplier_id, quantity)
            VALUES (@ModelId, @TypeId, @StatusId, @SupplierId, @Quantity)";
    }
}
