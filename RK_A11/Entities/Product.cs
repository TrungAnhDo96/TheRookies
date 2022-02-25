using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RK_A11.Entities
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Manufacture { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}