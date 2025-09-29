using MVC_WPF.Data.Database;
using MVC_WPF.Data.SQL.Cartridges;
using MVC_WPF.Data.SQL.Supplier;
using MVC_WPF.Models;
using MVC_WPF.Models.Cartridges;
using MVC_WPF.Models.Factories;
using MVC_WPF.Models.Suppliers;
using System;
using System.Collections.Generic;
using System.Data;


namespace MVC_WPF.Controllers
{
    public class CartridgeController
    {
        /// <summary>
        /// Метод добавления картриджей
        /// </summary>
        public bool AddCartridge(CartridgeBase cartridge)
        {
            if (cartridge == null)
                return false;

            var parameters = new MySql.Data.MySqlClient.MySqlParameter[]
            {
        new MySql.Data.MySqlClient.MySqlParameter("@ModelId", cartridge.ModelId),
        new MySql.Data.MySqlClient.MySqlParameter("@TypeId", cartridge.TypeId),
        new MySql.Data.MySqlClient.MySqlParameter("@StatusId", cartridge.Status.Id),
        new MySql.Data.MySqlClient.MySqlParameter("@SupplierId", cartridge.Supplier.Id),
        new MySql.Data.MySqlClient.MySqlParameter("@Quantity", cartridge.Quantity)
            };

            int result = DBConnection.Instance.ExecuteNonQuery(
                AddCartridgeQueries.InsertCartridge, parameters);

            return result > 0;
        }

        /// <summary>
        /// Метод обновления информации о картриджах
        /// </summary>
        public bool UpdateCartridges(CartridgeBase cartridge)
        {
            var parameters = new MySql.Data.MySqlClient.MySqlParameter[]
            {

                new MySql.Data.MySqlClient.MySqlParameter("@ModelId", cartridge.ModelId),
                new MySql.Data.MySqlClient.MySqlParameter("@TypeId", cartridge.TypeId),
                new MySql.Data.MySqlClient.MySqlParameter("@StatusId", cartridge.Status.Id),
                new MySql.Data.MySqlClient.MySqlParameter("@SupplierId", cartridge.Supplier.Id),
                new MySql.Data.MySqlClient.MySqlParameter("@Quantity", cartridge.Quantity),
                new MySql.Data.MySqlClient.MySqlParameter("@CartridgeId", cartridge.Id)
            };

            int result = DBConnection.Instance.ExecuteNonQuery(
                UpdateCartridgeQueries.UpdateCartridge, parameters);
            return result > 0;
        }

        /// <summary>
        /// Метод удаления картриджей
        /// </summary>
        public bool DeleteCartridge(int cartridgeId)
        {
            var parameters = new MySql.Data.MySqlClient.MySqlParameter[]
            {
                new MySql.Data.MySqlClient.MySqlParameter("@CartridgeId", cartridgeId)
            };

            int result = DBConnection.Instance.ExecuteNonQuery(
                DeleteCartridgeQueries.DeleteCartridge, parameters);

            return result > 0;
        }

        public List<CartridgeModel> GetModels()
        {
            var result = new List<CartridgeModel>();
            var dt = DBConnection.Instance.ExecuteQuery(CartridgeModelQueries.GetModels);

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
            var dt = DBConnection.Instance.ExecuteQuery(CartridgeTypesQueries.GetTypes);

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
            var dt = DBConnection.Instance.ExecuteQuery(CartridgeStatusQueries.GetStatuses);

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

        public List<Supplier> GetSuppliers()
        {
            var result = new List<Supplier>();

            try
            {
                var dt = DBConnection.Instance.ExecuteQuery(SupplierQueries.GetSuppliers);

                foreach (DataRow row in dt.Rows)
                {
                    result.Add(new Supplier
                    {
                        Id = Convert.ToInt32(row["supplier_id"]),
                        Name = row["supplier_name"].ToString(),
                        ContactInfo = row["contact_info"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении поставщиков: " + ex.Message);
            }

            return result;
        }

        public List<CartridgeBase> GetCartridges()
        {
            var result = new List<CartridgeBase>();
            var dt = DBConnection.Instance.ExecuteQuery(CartridgeQueries.GetCartridges);

            foreach (DataRow row in dt.Rows)
            {
                string modelName = row["model_name"].ToString();
                string typeName = row["type_name"].ToString();

                var supplier = new Supplier
                {
                    Id = Convert.ToInt32(row["supplier_id"]),
                    Name = row["supplier_name"].ToString()
                };

                var cartridge = CartridgeFactory.CreateCartridge(typeName, modelName, supplier);

                cartridge.Id = Convert.ToInt32(row["cartridge_id"]);
                cartridge.ModelId = Convert.ToInt32(row["model_id"]);
                cartridge.TypeId = Convert.ToInt32(row["type_id"]);
                cartridge.Quantity = Convert.ToInt32(row["quantity"]);

                cartridge.Status = new CartridgeStatus
                {
                    Id = Convert.ToInt32(row["status_id"]),
                    StatusName = row["status_name"].ToString()
                };

                result.Add(cartridge);
            }

            return result;
        }
    }
}
