using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WPF.Data.SQL.Cartridges
{
    /// <summary>
    /// Запрос на обновление данных
    /// </summary>
    public static class UpdateCartridgeQueries
    {
        public const string UpdateCartridge = @"
            UPDATE cartridges
            SET model_id = @ModelId,
                type_id = @TypeId,
                status_id = @StatusId,
                supplier_id = @SupplierId,
                quantity = @Quantity
            WHERE cartridge_id = @CartridgeId";
    }
}
