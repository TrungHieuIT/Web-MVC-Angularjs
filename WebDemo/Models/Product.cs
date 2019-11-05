using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDemo.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        [MaxLength(256)]
        public string Alias { set; get; }
      

        public decimal Price { set; get; }

        public decimal PromotionPrice { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

      

        public int Invetory { set; get; }


        public decimal OriginalPrice { set; get; }
        public bool Status { set; get; }
        public string CategoryName { get; set; }

        [Required]
        public int CategoryID { set; get; }

        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategory { set; get; }
    }
}