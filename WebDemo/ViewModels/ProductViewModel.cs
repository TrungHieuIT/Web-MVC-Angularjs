namespace WebDemo.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }

        public decimal Price { set; get; }

        public decimal PromotionPrice { set; get; }

        public string Description { set; get; }
    

        public int Invetory { set; get; }
        
        public decimal OriginalPrice { set; get; }

        public int CategoryID { set; get; }

        public bool Status { set; get; }
        public string CategoryName { get; set; }
        public ProductCategoryViewModel Category { get; set; }
    }
}