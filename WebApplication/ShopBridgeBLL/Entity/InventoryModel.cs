namespace ShopBridgeBLL.Entity
{
    public class InventoryModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int DiscountAvailable { get; set; }
        public int IsStockAvailable { get; set; }
        public int IsActive { get; set; }
        public string Category { get; set; }
        public string Images { get; set; }

    }
}
