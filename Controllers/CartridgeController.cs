using MVC_WPF.Data.Database;
using MVC_WPF.Data.SQL.Cartridges;
using MySql.Data.MySqlClient;

namespace MVC_WPF.Controllers
{
    public class CartridgeController
    {
        /// <summary>
        /// Добавление нового картриджа
        /// </summary>
        public bool AddCartridge(int modelId, int typeId, int statusId, int quantity)
        {
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@ModelId", modelId),
                new MySqlParameter("@TypeId", typeId),
                new MySqlParameter("@StatusId", statusId),
                new MySqlParameter("@Quantity", quantity)
            };

            int result = DBConnection.Instance.ExecuteNonQuery(
                CartridgeQueries.InsertCartridge, parameters);

            return result > 0; // true, если добавилась хотя бы одна строка
        }
    }
}
