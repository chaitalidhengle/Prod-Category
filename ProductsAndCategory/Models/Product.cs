using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndCategory.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Int64 ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        [ForeignKey("Category")]
        public Int64 CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
