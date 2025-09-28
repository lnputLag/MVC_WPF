using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WPF.Data.SQL.Cartridges
{
    /// <summary>
    /// Запрос на удаление данных
    /// </summary>
    public static class DeleteCartridgeQueries
    {
        public const string DeleteCartridge = @"
            DELETE FROM cartridges
            WHERE cartridge_id = @CartridgeId";
    }
}
