using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndCategory.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public Int64 CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
