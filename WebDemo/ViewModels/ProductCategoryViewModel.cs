namespace WebDemo.ViewModels
{
    public class ProductCategoryViewModel
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Alias { set; get; }
        public string Description { set; get; }
        public int DisplayOrder { set; get; }
        public string Image { set; get; }
        public bool Status { get; set; }
    }
}