using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WPF.Data.SQL.Cartridges
{
    /// <summary>
    /// Получение списка всех моделей картриджей
    /// </summary>
    public static class CartridgeModelQueries
    {
        public const string GetModels = @"
            SELECT model_id, model_name 
            FROM cartridge_models";
    }
}
