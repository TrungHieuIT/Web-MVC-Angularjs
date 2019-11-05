namespace WebDemo.ViewModels
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public int ProductID { set; get; }
        public int OrderID { get; set; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public string ProductName { get; set; }
        public ProductViewModel Product { get; set; }
        public OrderViewModel Order { get; set; }
    }
}