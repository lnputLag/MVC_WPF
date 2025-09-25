using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WPF.Models.Cartridges
{
    public class Cartridge
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int Quantity { get; set; }
        public string TypeName { get; set; }
        public string StatusName { get; set; }
    }
}
