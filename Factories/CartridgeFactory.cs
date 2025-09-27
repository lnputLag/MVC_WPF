using MVC_WPF.Controllers;
using MVC_WPF.Models.Cartridges.Business;
using MVC_WPF.Models.Cartridges;
using MVC_WPF.Models.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WPF.Factories
{
    public class CartridgeFactory
    {
        /// <summary>
        /// Создание объекта картриджа в зависимости от типа
        /// </summary>
        /// <param name="typeName">Тип картриджа (BW, Color, RICOH)</param>
        /// <param name="modelName">Модель картриджа</param>
        /// <param name="supplier">Поставщик картриджа</param>
        /// <returns>Конкретный объект CartridgeBase</returns>
        public CartridgeBase CreateCartridge(string typeName, string modelName, Supplier supplier)
        {
            CartridgeBase cartridge = null;

            switch (typeName)
            {
                case "BW":
                    cartridge = new BWCartridge
                    {
                        ModelName = modelName,
                        TypeName = typeName,
                        Supplier = supplier
                    };
                    break;

                case "Color":
                    cartridge = new ColorCartridge
                    {
                        ModelName = modelName,
                        TypeName = typeName,
                        Supplier = supplier
                    };
                    break;

                case "RICOH":
                    cartridge = new RicohCartridge
                    {
                        ModelName = modelName,
                        TypeName = typeName,
                        Supplier = supplier
                    };
                    break;

                default:
                    // Можно выбросить исключение или оставить null
                    cartridge = null;
                    break;
            }

            return cartridge;
        }
    }
}
