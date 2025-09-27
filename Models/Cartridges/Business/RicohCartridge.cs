using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WPF.Models.Cartridges.Business
{
    public class RicohCartridge : CartridgeBase
    {
        public override void Refill()
        {
            System.Windows.MessageBox.Show($"Картридж Ricoh {ModelName} заправляется поставщиком {Supplier.Name}");
        }
    }
}
