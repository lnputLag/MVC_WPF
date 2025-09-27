using MVC_WPF.Models.Suppliers;

namespace MVC_WPF.Models.Cartridges
{
    public abstract class CartridgeBase
    {
        public int ModelId { get; set; }
        public int TypeId { get; set; }
        public string ModelName { get; set; }
        public string TypeName { get; set; }
        public CartridgeStatus Status { get; set; }
        public Supplier Supplier { get; set; }
        public int Quantity { get; set; }

        // Метод, который будет выполнять действие заправки
        public abstract void Refill();
    }
}
