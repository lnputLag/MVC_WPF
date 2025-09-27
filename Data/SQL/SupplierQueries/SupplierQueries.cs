using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WPF.Data.SQL.Supplier
{
    /// <summary>
    /// Запрос для получения всех поставщиков
    /// </summary>
    public static class SupplierQueries
    {
        public const string GetSuppliers = @"
            SELECT supplier_id, supplier_name, contact_info
            FROM suppliers";
    }
}
