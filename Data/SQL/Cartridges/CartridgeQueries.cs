using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WPF.Data.SQL.Cartridges
{
    /// <summary>
    /// Лучше все запросы отдельно?
    /// </summary>
    public static class CartridgeQueries
    {
        public const string InsertCartridge = @"
            INSERT INTO cartridges (model_id, type_id, status_id, quantity)
            VALUES (@ModelId, @TypeId, @StatusId, @Quantity)";

        public const string GetModels = @"
            SELECT model_id, model_name 
            FROM cartridge_models";

        public const string GetTypes = @"
            SELECT type_id, type_name 
            FROM cartridge_types";

        public const string GetStatuses = @"
            SELECT status_id, status_name 
            FROM cartridge_status";
    }
}
