using MVC_WPF.Data.Database;
using MVC_WPF.Data.SQL.Cartridges;
using MVC_WPF.Models;
using MVC_WPF.Models.Cartridges;
using System;
using System.Collections.Generic;
using System.Data;

namespace MVC_WPF.Controllers
{
    public class CartridgeController
    {
        public bool AddCartridge(int modelId, int typeId, int statusId, int quantity)
        {
            var parameters = new MySql.Data.MySqlClient.MySqlParameter[]
            {
                new MySql.Data.MySqlClient.MySqlParameter("@ModelId", modelId),
                new MySql.Data.MySqlClient.MySqlParameter("@TypeId", typeId),
                new MySql.Data.MySqlClient.MySqlParameter("@StatusId", statusId),
                new MySql.Data.MySqlClient.MySqlParameter("@Quantity", quantity)
            };

            int result = DBConnection.Instance.ExecuteNonQuery(
                CartridgeQueries.InsertCartridge, parameters);

            return result > 0;
        }

        public List<CartridgeModel> GetModels()
        {
            var result = new List<CartridgeModel>();
            var dt = DBConnection.Instance.ExecuteQuery(CartridgeQueries.GetModels);

            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CartridgeModel
                {
                    Id = Convert.ToInt32(row["model_id"]),
                    ModelName = row["model_name"].ToString()
                });
            }
            return result;
        }

        public List<CartridgeType> GetTypes()
        {
            var result = new List<CartridgeType>();
            var dt = DBConnection.Instance.ExecuteQuery(CartridgeQueries.GetTypes);

            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CartridgeType
                {
                    Id = Convert.ToInt32(row["type_id"]),
                    TypeName = row["type_name"].ToString()
                });
            }
            return result;
        }

        public List<CartridgeStatus> GetStatuses()
        {
            var result = new List<CartridgeStatus>();
            var dt = DBConnection.Instance.ExecuteQuery(CartridgeQueries.GetStatuses);

            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CartridgeStatus
                {
                    Id = Convert.ToInt32(row["status_id"]),
                    StatusName = row["status_name"].ToString()
                });
            }
            return result;
        }

        public List<Cartridge> GetCartridges()
        {
            var result = new List<Cartridge>();
            var dt = DBConnection.Instance.ExecuteQuery(CartridgeQueries.GetCartridges);

            foreach (DataRow row in dt.Rows)
            {
                result.Add(new Cartridge
                {
                    Id = Convert.ToInt32(row["cartridge_id"]),
                    ModelName = row["model_name"].ToString(),
                    Quantity = Convert.ToInt32(row["quantity"]),
                    TypeName = row["type_name"].ToString(),
                    StatusName = row["status_name"].ToString()
                });
            }
            return result;
        }
    }
}
